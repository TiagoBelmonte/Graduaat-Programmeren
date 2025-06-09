from googleapiclient.discovery import build
from google.oauth2.credentials import Credentials
from google_auth_oauthlib.flow import InstalledAppFlow
from google.auth.transport.requests import Request

import os
import base64

SCOPES = [
    "https://www.googleapis.com/auth/calendar.readonly",
    "https://www.googleapis.com/auth/gmail.readonly"
]


class GmailService:
    def __init__(self):
        base_dir = os.path.dirname(os.path.abspath(__file__))
        root_dir = os.path.dirname(base_dir)
        self.credentials_path = os.path.join(root_dir, "credentials.json")
        self.token_path = os.path.join(root_dir, "token.json")
        self.service = self._get_service()

    def _get_service(self):
        creds = None
        if os.path.exists(self.token_path):
            creds = Credentials.from_authorized_user_file(self.token_path, SCOPES)
        if not creds or not creds.valid:
            if creds and creds.expired and creds.refresh_token:
                creds.refresh(Request())
            else:
                flow = InstalledAppFlow.from_client_secrets_file(self.credentials_path, SCOPES)
                creds = flow.run_local_server(port=0)
            with open(self.token_path, 'w') as token:
                token.write(creds.to_json())
        return build('gmail', 'v1', credentials=creds)

    def zoek_mails(self, zoekterm="stage", max_mails=5):
        results = self.service.users().messages().list(
            userId='me',
            q=zoekterm,
            maxResults=max_mails
        ).execute()
        messages = results.get('messages', [])

        mails = []
        for msg in messages:
            msg_data = self.service.users().messages().get(userId='me', id=msg['id'], format='full').execute()
            payload = msg_data.get("payload", {})
            headers = payload.get("headers", [])

            subject = sender = "(onbekend)"
            for h in headers:
                name = h["name"].lower()
                if name == "subject":
                    subject = h["value"]
                elif name == "from":
                    sender = h["value"]

            # ➕ Haal body hier ook op
            body = self._extract_body(payload)

            mails.append({
                "id": msg["id"],
                "onderwerp": subject,
                "van": sender,
                "body": body
            })

        return mails

    def _extract_body(self, payload):
        parts = payload.get('parts', [])
        data = ""

        # Probeer 'text/plain' eerst
        for part in parts:
            if part.get('mimeType') == 'text/plain':
                body_data = part['body'].get('data')
                if body_data:
                    try:
                        data = base64.urlsafe_b64decode(body_data).decode()
                    except Exception:
                        data = "(Fout bij decoderen van inhoud)"
                    break

        return data.strip() if data else "(Geen inhoud gevonden)"
