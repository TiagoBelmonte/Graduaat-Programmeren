
from services.gmail_service import GmailService
from utils.gmail_response_builder import maak_email_zinnen

class GmailController:
    def __init__(self):
        self.gmail_service = GmailService()

    def verwerk_emailvraag(self, zoekterm):
        mails = self.gmail_service.zoek_mails(zoekterm)

        if not mails:
            return f"Ik vond geen mails over '{zoekterm}'.", []

        # ✅ Geef onderwerp mee aan de builderfunctie
        zin = maak_email_zinnen(mails, zoekterm)
        return zin, mails
