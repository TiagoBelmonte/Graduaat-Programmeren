from __future__ import print_function
import datetime
import os
from google.oauth2.credentials import Credentials
from google_auth_oauthlib.flow import InstalledAppFlow
from googleapiclient.discovery import build
from google.auth.transport.requests import Request
from utils.google_calendar_response_builder import maak_agendazinnen

# ✅ Absoluut pad naar credentials en token
BASE_DIR = os.path.dirname(os.path.abspath(__file__))  # => pad tot services/
ROOT_DIR = os.path.dirname(BASE_DIR)  # => pad tot chat_assistant/
CREDENTIALS_PATH = os.path.join(ROOT_DIR, "credentials.json")
TOKEN_PATH = os.path.join(ROOT_DIR, "token.json")

# Alleen lezen uit agenda
SCOPES = ['https://www.googleapis.com/auth/calendar.readonly']

def get_calendar_service():
    creds = None

    # ✅ Token ophalen (veilig pad)
    if os.path.exists(TOKEN_PATH):
        creds = Credentials.from_authorized_user_file(TOKEN_PATH, SCOPES)

    # ✅ Zo niet: vernieuwen of nieuwe login
    if not creds or not creds.valid:
        if creds and creds.expired and creds.refresh_token:
            creds.refresh(Request())
        else:
            flow = InstalledAppFlow.from_client_secrets_file(CREDENTIALS_PATH, SCOPES)
            creds = flow.run_local_server(port=0)

        # ✅ Token opslaan
        with open(TOKEN_PATH, "w") as token:
            token.write(creds.to_json())

    service = build("calendar", "v3", credentials=creds)
    return service

def get_events_for_day(day="today"):
    service = get_calendar_service()

    now = datetime.datetime.utcnow()
    if day == "tomorrow":
        start_time = now + datetime.timedelta(days=1)
        end_time = now + datetime.timedelta(days=2)
    elif day == "week":
        start_time = now
        end_time = now + datetime.timedelta(days=7)
    else:  # today
        start_time = now
        end_time = now + datetime.timedelta(days=1)

    time_min = start_time.isoformat() + 'Z'
    time_max = end_time.isoformat() + 'Z'

    events_result = service.events().list(
        calendarId='primary',
        timeMin=time_min,
        timeMax=time_max,
        singleEvents=True,
        orderBy='startTime'
    ).execute()

    events = events_result.get('items', [])

    return maak_agendazinnen(events, day)

