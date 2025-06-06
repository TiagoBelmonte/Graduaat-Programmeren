import os
import requests
from dotenv import load_dotenv

# .env laden
load_dotenv()

NEWS_API_KEY = os.getenv("NEWS_API_KEY")

TOPIC_MAPPING = {
    "sport": "sports",
    "gezondheid": "health",
    "technologie": "technology",
    "entertainment": "entertainment",
    "wetenschap": "science",
    "economie": "business",
    "wereld": "top",  # newsdata.io gebruikt 'top' als algemene categorie
}

def fetch_news(topic=None):
    if not NEWS_API_KEY:
        return "⚠️ Geen API-sleutel gevonden voor newsdata.io."

    base_url = "https://newsdata.io/api/1/latest"

    TOPIC_QUERIES = {
        "sport": "sports",
        "gezondheid": "health",
        "technologie": "technology",
        "entertainment": "entertainment",
        "wetenschap": "science",
        "economie": "business",
        "wereld": "world",
        "politiek": "politics"
    }

    try:
        zoekterm = TOPIC_QUERIES.get((topic or "").lower(), "nieuws")

        # ❌ 'page' parameter mag niet meegegeven worden bij eerste oproep
        params = [
            ("q", zoekterm),
            ("apikey", NEWS_API_KEY),
            ("language", "nl"),
            ("country", "be")
        ]

        response = requests.get(base_url, params=params)
        response.raise_for_status()
        data = response.json()
        articles = data.get("results", [])

        if not articles:
            return f"❌ Geen nieuws gevonden voor het onderwerp '{topic or 'algemeen'}'."

        return articles[:3]

    except requests.exceptions.RequestException as e:
        return f"⚠️ Fout bij het ophalen van nieuws: {e}"
