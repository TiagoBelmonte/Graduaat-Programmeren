# services/google_calendar_api.py

from __future__ import print_function
import datetime
import os
# Google API-bibliotheken voor authenticatie en toegang tot Calendar
from google.oauth2.credentials import Credentials
from google_auth_oauthlib.flow import InstalledAppFlow
from googleapiclient.discovery import build
from google.auth.transport.requests import Request

class CalendarService:
    # Vereiste machtigingen voor agenda en e-mail (alleen-lezen)
    SCOPES = [
        "https://www.googleapis.com/auth/calendar.readonly",
        "https://www.googleapis.com/auth/gmail.readonly"
    ]

    def __init__(self, credentials_path=None, token_path=None):
        # Bepaal standaardpad naar credentials en token
        base_dir = os.path.dirname(os.path.abspath(__file__))
        root_dir = os.path.dirname(base_dir)

        self.credentials_path = credentials_path or os.path.join(root_dir, "credentials.json")
        self.token_path = token_path or os.path.join(root_dir, "token.json")

        # Maak verbinding met Google Calendar API
        self.service = self._get_calendar_service()

    def _get_calendar_service(self):
        # Laad bestaande token als beschikbaar
        creds = None
        if os.path.exists(self.token_path):
            creds = Credentials.from_authorized_user_file(self.token_path, self.SCOPES)

        # Als token ongeldig is, vernieuw of vraag opnieuw toestemming
        if not creds or not creds.valid:
            if creds and creds.expired and creds.refresh_token:
                creds.refresh(Request())
            else:
                flow = InstalledAppFlow.from_client_secrets_file(self.credentials_path, self.SCOPES)
                creds = flow.run_local_server(port=0)
            # Sla nieuw token op
            with open(self.token_path, "w") as token:
                token.write(creds.to_json())

        # Retourneer een werkende calendar service
        return build("calendar", "v3", credentials=creds)

    def get_events(self, day="today"):
        now = datetime.datetime.utcnow()

        # Bepaal start- en eindtijd op basis van gevraagde periode
        if day == "tomorrow":
            start_time = now + datetime.timedelta(days=1)
            end_time = now + datetime.timedelta(days=2)
        elif day == "week":
            start_time = now
            end_time = now + datetime.timedelta(days=7)
        else:  # today
            start_time = now
            end_time = now + datetime.timedelta(days=1)

        # Zet tijdsgrenzen om naar ISO-formaat
        time_min = start_time.isoformat() + 'Z'
        time_max = end_time.isoformat() + 'Z'

        # Haal gebeurtenissen op uit de primaire agenda
        events_result = self.service.events().list(
            calendarId='primary',
            timeMin=time_min,
            timeMax=time_max,
            singleEvents=True,
            orderBy='startTime'
        ).execute()

        # Geef lijst van afspraken terug
        return events_result.get('items', [])
