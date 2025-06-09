# controllers/weather_controller.py

from services.weather_api import WeatherService
from utils.weather_response_builder import maak_weer_zin

class WeatherController:
    def __init__(self):
        self.service = WeatherService()

    def verwerk_weervraag(self, vraag, stad):
        data = self.service.get_weather(stad, raw=True)
        if isinstance(data, dict):
            return maak_weer_zin(data, vraag, stad)
        else:
            return data  # foutmelding als string
