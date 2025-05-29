import os
import requests
from dotenv import load_dotenv

load_dotenv()  # ✅ Laadt .env in

def get_weather(city: str, raw: bool = False):  # ✅ raw-parameter toegevoegd
    api_key = os.getenv("OPENWEATHER_API_KEY")
    if not api_key:
        return "⚠️ Geen API-sleutel gevonden voor OpenWeather."

    url = (
        f"https://api.openweathermap.org/data/2.5/weather"
        f"?q={city}&appid={api_key}&units=metric&lang=nl"
    )

    try:  # ✅ correcte inspringing
        response = requests.get(url)
        response.raise_for_status()
        data = response.json()

        if raw:
            return data  # ✅ geef volledige data terug

        temp = data["main"]["temp"]
        desc = data["weather"][0]["description"]
        return f"In {city.capitalize()} is het {temp}°C met {desc}."
    except requests.RequestException:
        return "⚠️ Er is iets misgegaan bij het ophalen van het weer."
    except KeyError:
        return "⚠️ Ongeldige stad of onverwacht antwoord van de API."
