from services.google_calendar_api import get_events_for_day
from services.weather_api import get_weather
from services.news_api import fetch_news
from services.ollama_api import ask_ollama

from utils.nlp_utils import detect_weather_question, detect_news_question
from utils.weather_response_builder import maak_weer_zin
from utils.news__response_builder import maak_nieuwszin

import webbrowser
import re

laatste_nieuwszin_links = []  # Globale cache

woord_to_index = {
    "eerste": 0,
    "tweede": 1,
    "derde": 2,
    "vierde": 3,
    "vijfde": 4
}

def behandel_vraag(vraag: str) -> str:
    vraag_lc = vraag.lower()

    # Intentie: afspraken
    if "afspraken" in vraag_lc or "agenda" in vraag_lc:
        if "morgen" in vraag_lc:
            return get_events_for_day("tomorrow")
        elif "week" in vraag_lc or "komende dagen" in vraag_lc:
            return get_events_for_day("week")
        else:
            return get_events_for_day("today")

    # Intentie: weer
    stad = detect_weather_question(vraag)
    if stad:
        data = get_weather(stad, raw=True)
        if isinstance(data, dict):
            return maak_weer_zin(data, vraag, stad)
        else:
            return data

    # Intentie: nieuws
    nieuws_info = detect_news_question(vraag)
    if nieuws_info:
        topic = nieuws_info.get("topic", "algemeen")
        articles = fetch_news(topic=topic)
        if isinstance(articles, list):
            global laatste_nieuwszin_links
            laatste_nieuwszin_links = [a.get("link") for a in articles]
            return maak_nieuwszin(articles, onderwerp=topic) + "\n\nWil je dat ik een van de artikels voor je open?"
        else:
            return articles  # foutmelding als string

    # Intentie: artikel openen
    match_nummer = re.search(r"(open|toon).*?artikel\s*(\d+)", vraag_lc)
    match_woord = re.search(r"(open|toon).*?(eerste|tweede|derde|vierde|vijfde)", vraag_lc)

    index = None
    if match_nummer:
        index = int(match_nummer.group(2)) - 1
    elif match_woord:
        index = woord_to_index.get(match_woord.group(2))

    if index is not None:
        if 0 <= index < len(laatste_nieuwszin_links):
            link = laatste_nieuwszin_links[index]
            webbrowser.open(link)
            return f"Ik open artikel {index + 1} voor je."
        else:
            return "Ik heb dat artikelnummer niet gevonden in het laatste nieuws."

    # Fallback: LLM
    return ask_ollama(vraag)
