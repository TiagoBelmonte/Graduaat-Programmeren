# controllers/calendar_controller.py

from services.google_calendar_api import CalendarService
from utils.google_calendar_response_builder import maak_agendazinnen

class CalendarController:
    def __init__(self):
        self.service = CalendarService()

    def verwerk_agendavraag(self, dag):
        events = self.service.get_events(day=dag)
        return maak_agendazinnen(events, dag)
