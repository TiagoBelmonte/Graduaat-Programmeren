from services.google_calendar_api import get_events_for_day
from services.weather_api import get_weather
from services.news_api import fetch_news
from services.ollama_api import ask_ollama

from utils.nlp_utils import detect_weather_question, detect_news_question
from utils.weather_response_builder import maak_weer_zin
from utils.news__response_builder import maak_nieuwszin




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
            return maak_nieuwszin(articles, onderwerp=topic)
        else:
            return articles  # foutmelding als string


    # Fallback: LLM
    return ask_ollama(vraag)
