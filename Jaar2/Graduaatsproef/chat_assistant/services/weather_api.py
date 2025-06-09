# services/weather_api.py

import os
import requests
from dotenv import load_dotenv

load_dotenv()

class WeatherService:
    def __init__(self, api_key=None):
        self.api_key = api_key or os.getenv("OPENWEATHER_API_KEY")
        self.base_url = "https://api.openweathermap.org/data/2.5/weather"

    def get_weather(self, city: str, raw: bool = False):
        if not self.api_key:
            return "⚠️ Geen API-sleutel gevonden voor OpenWeather."

        params = {
            "q": city,
            "appid": self.api_key,
            "units": "metric",
            "lang": "nl"
        }

        try:
            response = requests.get(self.base_url, params=params)
            response.raise_for_status()
            data = response.json()

            if raw:
                return data

            temp = data["main"]["temp"]
            desc = data["weather"][0]["description"]
            return f"In {city.capitalize()} is het {temp}°C met {desc}."

        except requests.RequestException:
            return "⚠️ Er is iets misgegaan bij het ophalen van het weer."
        except KeyError:
            return "⚠️ Ongeldige stad of onverwacht antwoord van de API."
