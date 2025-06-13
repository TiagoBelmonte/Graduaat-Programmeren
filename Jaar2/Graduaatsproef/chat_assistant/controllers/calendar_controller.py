# controllers/calendar_controller.py

# Importeert de Google Calendar service om afspraken op te halen
from services.google_calendar_api import CalendarService
# Importeert een helperfunctie om de afspraken om te zetten naar begrijpbare zinnen
from utils.google_calendar_response_builder import maak_agendazinnen

# Controllerklasse die verantwoordelijk is voor het verwerken van agendavragen
class CalendarController:
    def __init__(self):
        # Initialiseert de CalendarService om met de Google Calendar API te werken
        self.service = CalendarService()

    def verwerk_agendavraag(self, dag):
        # Haalt de afspraken op voor de opgegeven dag
        events = self.service.get_events(day=dag)
        # Zet de lijst van afspraken om in natuurlijke zinnen
        return maak_agendazinnen(events, dag)
