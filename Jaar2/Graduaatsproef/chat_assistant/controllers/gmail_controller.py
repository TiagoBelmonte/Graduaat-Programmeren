from services.gmail_service import GmailService
# Importeert een helperfunctie om e-mails om te zetten naar natuurlijke zinnen
from utils.gmail_response_builder import maak_email_zinnen

# Controllerklasse die e-mailgerelateerde vragen verwerkt
class GmailController:
    def __init__(self):
        # Initialiseert de GmailService om met de Gmail API te communiceren
        self.gmail_service = GmailService()

    def verwerk_emailvraag(self, zoekterm):
        # Zoekt e-mails die overeenkomen met de zoekterm
        mails = self.gmail_service.zoek_mails(zoekterm)

        # Als er geen mails zijn gevonden, geef een melding en lege lijst terug
        if not mails:
            return f"Ik vond geen mails over '{zoekterm}'.", []

        # Zet de gevonden e-mails om in natuurlijke zinnen
        zin = maak_email_zinnen(mails, zoekterm)
        return zin, mails
