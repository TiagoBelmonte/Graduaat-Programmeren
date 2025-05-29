from __future__ import print_function
import datetime
import os.path
from google.oauth2.credentials import Credentials
from google_auth_oauthlib.flow import InstalledAppFlow
from googleapiclient.discovery import build

# Als je alleen wilt LEZEN
SCOPES = ['https://www.googleapis.com/auth/calendar.readonly']

def get_calendar_service():
    creds = None
    if os.path.exists("token.json"):
        creds = Credentials.from_authorized_user_file("token.json", SCOPES)
    if not creds or not creds.valid:
        if creds and creds.expired and creds.refresh_token:
            creds.refresh(Request())
        else:
            flow = InstalledAppFlow.from_client_secrets_file(
                "credentials.json", SCOPES)
            creds = flow.run_local_server(port=0)

        # Token opslaan voor de volgende keer
        with open("token.json", "w") as token:
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

    if not events:
        return f"Je hebt geen afspraken {('deze week' if day == 'week' else 'morgen' if day == 'tomorrow' else 'vandaag')}."

    antwoord = f"Je hebt {len(events)} afspraak{'pen' if len(events) > 1 else ''} "
    antwoord += "deze week:\n" if day == "week" else "morgen:\n" if day == "tomorrow" else "vandaag:\n"

    for event in events:
        start = event['start'].get('dateTime', event['start'].get('date'))
        tijd = start.split("T")[1][:5] if "T" in start else "Hele dag"
        titel = event.get('summary', 'Zonder titel')
        antwoord += f"- om {tijd}: {titel}\n"

    return antwoord.strip()

