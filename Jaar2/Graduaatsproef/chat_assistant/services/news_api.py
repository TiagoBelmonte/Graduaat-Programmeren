# services/news_api.py

import os
import requests
from dotenv import load_dotenv

load_dotenv()

class NewsService:
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

    def __init__(self, api_key=None):
        self.api_key = api_key or os.getenv("NEWS_API_KEY")
        self.base_url = "https://newsdata.io/api/1/latest"

    def fetch_news(self, topic=None):
        if not self.api_key:
            return "⚠️ Geen API-sleutel gevonden voor newsdata.io."

        zoekterm = self.TOPIC_QUERIES.get((topic or "").lower(), "nieuws")

        params = {
            "q": zoekterm,
            "apikey": self.api_key,
            "language": "nl",
            "country": "be"
        }

        try:
            response = requests.get(self.base_url, params=params)
            response.raise_for_status()
            data = response.json()
            articles = data.get("results", [])

            if not articles:
                return f"❌ Geen nieuws gevonden voor het onderwerp '{topic or 'algemeen'}'."

            return articles[:3]

        except requests.exceptions.RequestException as e:
            return f"⚠️ Fout bij het ophalen van nieuws: {e}"
