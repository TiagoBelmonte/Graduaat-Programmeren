# controllers/chatbot_controller.py

import re
import webbrowser

from controllers.calendar_controller import CalendarController
from controllers.news_controller import NewsController
from controllers.weahter_controller import WeatherController
from services.ollama_api import AIAssistantService
from utils.nlp_utils import detect_weather_question, detect_news_question

class ChatbotController:
    def __init__(self):
        self.agenda_controller = CalendarController()
        self.nieuws_controller = NewsController()
        self.weer_controller = WeatherController()
        self.ai_assistent = AIAssistantService()
        self.laaste_nieuws_links = []

        self.woord_to_index = {
            "eerste": 0,
            "tweede": 1,
            "derde": 2,
            "vierde": 3,
            "vijfde": 4
        }

    def behandel_vraag(self, vraag: str) -> str:
        vraag_lc = vraag.lower()

        # Intentie: afspraken
        if "afspraken" in vraag_lc or "agenda" in vraag_lc:
            if "morgen" in vraag_lc:
                return self.agenda_controller.verwerk_agendavraag("tomorrow")
            elif "week" in vraag_lc or "komende dagen" in vraag_lc:
                return self.agenda_controller.verwerk_agendavraag("week")
            else:
                return self.agenda_controller.verwerk_agendavraag("today")

        # Intentie: weer
        stad = detect_weather_question(vraag)
        if stad:
            return self.weer_controller.verwerk_weervraag(vraag, stad)

        # Intentie: nieuws
        nieuws_info = detect_news_question(vraag)
        if nieuws_info:
            topic = nieuws_info.get("topic", "algemeen")
            zin, links = self.nieuws_controller.verwerk_nieuwsvraag(topic)
            self.laaste_nieuws_links = links
            return zin + "\n\nWil je dat ik een van de artikels voor je open?"

        # Intentie: artikel openen
        match_nummer = re.search(r"(open|toon).*?artikel\s*(\d+)", vraag_lc)
        match_woord = re.search(r"(open|toon).*?(eerste|tweede|derde|vierde|vijfde)", vraag_lc)

        index = None
        if match_nummer:
            index = int(match_nummer.group(2)) - 1
        elif match_woord:
            index = self.woord_to_index.get(match_woord.group(2))

        if index is not None:
            if 0 <= index < len(self.laaste_nieuws_links):
                link = self.laaste_nieuws_links[index]
                webbrowser.open(link)
                return f"Ik open artikel {index + 1} voor je."
            else:
                return "Ik heb dat artikelnummer niet gevonden in het laatste nieuws."

        # Fallback: AI-assistent
        return self.ai_assistent.stel_vraag(vraag)
