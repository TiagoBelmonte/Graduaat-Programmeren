import re
import webbrowser

# Importeert de controllers en services
from controllers.calendar_controller import CalendarController
from controllers.news_controller import NewsController
from controllers.weahter_controller import WeatherController
from controllers.gmail_controller import GmailController
from services.ollama_api import AIAssistantService

# Importeert hulpfuncties voor intentiedetectie
from utils.nlp_utils import detect_weather_question, detect_news_question, detect_email_question


class ChatbotController:
    def __init__(self):
        # Initialiseert de verschillende controllers
        self.agenda_controller = CalendarController()
        self.nieuws_controller = NewsController()
        self.weer_controller = WeatherController()
        self.gmail_controller = GmailController()
        self.ai_assistent = AIAssistantService()

        # Houdt de laatst opgehaalde nieuwslinks en mails bij
        self.laaste_nieuws_links = []
        self.laatste_mails = []

        # Mapping van woord naar index (voor gebruik in spraak zoals "open de derde mail")
        self.woord_to_index = {
            "eerste": 0,
            "tweede": 1,
            "derde": 2,
            "vierde": 3,
            "vijfde": 4
        }

    def behandel_vraag(self, vraag: str) -> str:
        vraag_lc = vraag.lower()
        print(f"DEBUG >> Ontvangen vraag: {vraag_lc}")

        # Check of gebruiker vraagt om een specifieke mail te openen (via nummer of woord)
        match_mail_num = re.search(r"(open|toon|lees)\s+(?:de\s+)?(?:mail|e-mail)\s*(\d+)", vraag_lc)
        match_mail_woord = re.search(r"(open|toon|lees)\s+(?:de\s+)?(eerste|tweede|derde|vierde|vijfde)(?:\s+mail|\s+e-mail)?", vraag_lc)

        index = None
        if match_mail_num:
            index = int(match_mail_num.group(2)) - 1
        elif match_mail_woord:
            index = self.woord_to_index.get(match_mail_woord.group(2))

        print(f"DEBUG >> Mail openen gevraagd: index={index}, aantal mails={len(self.laatste_mails)}")
        # Als er geldige mailindex is en er zijn eerder mails opgehaald
        if index is not None and self.laatste_mails:
            if 0 <= index < len(self.laatste_mails):
                inhoud = self.laatste_mails[index].get("body", "(geen inhoud)")
                return f"Inhoud van mail {index + 1}:{inhoud}"
            else:
                return "⚠️ Ik heb dat mailnummer niet gevonden in de vorige e-mailresultaten."

        # Intentie: agenda opvragen (vandaag, morgen of komende week)
        if "afspraken" in vraag_lc or "agenda" in vraag_lc:
            if "morgen" in vraag_lc:
                return self.agenda_controller.verwerk_agendavraag("tomorrow")
            elif "week" in vraag_lc or "komende dagen" in vraag_lc:
                return self.agenda_controller.verwerk_agendavraag("week")
            else:
                return self.agenda_controller.verwerk_agendavraag("today")

        # Intentie: weervraag herkennen en doorsturen
        stad = detect_weather_question(vraag)
        if stad:
            return self.weer_controller.verwerk_weervraag(vraag, stad)

        # Intentie: nieuws opvragen op basis van onderwerp of land
        nieuws_info = detect_news_question(vraag)
        if nieuws_info:
            topic = nieuws_info.get("topic", "algemeen")
            zin, links = self.nieuws_controller.verwerk_nieuwsvraag(topic)
            self.laaste_nieuws_links = links
            return zin + "\n\nWil je dat ik een van de artikels voor je open?"

        # Intentie: specifiek artikel openen (via nummer of woord)
        match_artikel_num = re.search(r"(open|toon).*?artikel\s*(\d+)", vraag_lc)
        match_artikel_woord = re.search(r"(open|toon).*?(eerste|tweede|derde|vierde|vijfde).*?artikel", vraag_lc)

        artikel_index = None
        if match_artikel_num:
            artikel_index = int(match_artikel_num.group(2)) - 1
        elif match_artikel_woord:
            artikel_index = self.woord_to_index.get(match_artikel_woord.group(2))

        print(f"DEBUG >> Artikel openen gevraagd: index={artikel_index}, aantal links={len(self.laaste_nieuws_links)}")
        # Als er een geldig artikelnummer is en links beschikbaar zijn
        if artikel_index is not None:
            if 0 <= artikel_index < len(self.laaste_nieuws_links):
                link = self.laaste_nieuws_links[artikel_index]
                webbrowser.open(link)
                return f"📰 Ik open artikel {artikel_index + 1} voor je."
            else:
                return "⚠️ Ik heb dat artikelnummer niet gevonden in het laatste nieuws."

        # Intentie: e-mails opzoeken via onderwerp
        onderwerp = detect_email_question(vraag)
        if onderwerp:
            print(f"DEBUG >> Gedetecteerde e-mailvraag over: {onderwerp}")
            zin, mails = self.gmail_controller.verwerk_emailvraag(onderwerp)
            self.laatste_mails = mails
            print(f"DEBUG >> {len(mails)} mails gevonden en opgeslagen.")
            return zin

        # Geen intentie herkend → doorsturen naar AI-assistent (fallback)
        print("DEBUG >> Geen intentie herkend. Stuur door naar Ollama.")
        return self.ai_assistent.stel_vraag(vraag)
