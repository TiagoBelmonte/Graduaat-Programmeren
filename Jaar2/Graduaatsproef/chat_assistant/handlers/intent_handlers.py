from services.google_calendar_api import get_events_for_day
from services.weather_api import get_weather
from utils.nlp_utils import detect_weather_question
from utils.weather_response_builder import maak_weer_zin
from services.ollama_api import ask_ollama

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

    # Fallback: vraag aan LLM
    return ask_ollama(vraag)
