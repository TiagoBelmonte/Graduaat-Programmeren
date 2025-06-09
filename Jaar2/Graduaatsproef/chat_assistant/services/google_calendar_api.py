# services/google_calendar_api.py

from __future__ import print_function
import datetime
import os
from google.oauth2.credentials import Credentials
from google_auth_oauthlib.flow import InstalledAppFlow
from googleapiclient.discovery import build
from google.auth.transport.requests import Request

class CalendarService:
    SCOPES = ['https://www.googleapis.com/auth/calendar.readonly']

    def __init__(self, credentials_path=None, token_path=None):
        base_dir = os.path.dirname(os.path.abspath(__file__))
        root_dir = os.path.dirname(base_dir)

        self.credentials_path = credentials_path or os.path.join(root_dir, "credentials.json")
        self.token_path = token_path or os.path.join(root_dir, "token.json")
        self.service = self._get_calendar_service()

    def _get_calendar_service(self):
        creds = None

        if os.path.exists(self.token_path):
            creds = Credentials.from_authorized_user_file(self.token_path, self.SCOPES)

        if not creds or not creds.valid:
            if creds and creds.expired and creds.refresh_token:
                creds.refresh(Request())
            else:
                flow = InstalledAppFlow.from_client_secrets_file(self.credentials_path, self.SCOPES)
                creds = flow.run_local_server(port=0)

            with open(self.token_path, "w") as token:
                token.write(creds.to_json())

        return build("calendar", "v3", credentials=creds)

    def get_events(self, day="today"):
        now = datetime.datetime.utcnow()

        if day == "tomorrow":
            start_time = now + datetime.timedelta(days=1)
            end_time = now + datetime.timedelta(days=2)
        elif day == "week":
            start_time = now
            end_time = now + datetime.timedelta(days=7)
        else:
            start_time = now
            end_time = now + datetime.timedelta(days=1)

        time_min = start_time.isoformat() + 'Z'
        time_max = end_time.isoformat() + 'Z'

        events_result = self.service.events().list(
            calendarId='primary',
            timeMin=time_min,
            timeMax=time_max,
            singleEvents=True,
            orderBy='startTime'
        ).execute()

        return events_result.get('items', [])
