# controllers/news_controller.py

from services.news_api import NewsService
from utils.news__response_builder import maak_nieuwszin

class NewsController:
    def __init__(self):
        self.service = NewsService()

    def verwerk_nieuwsvraag(self, onderwerp):
        artikelen = self.service.fetch_news(topic=onderwerp)
        if isinstance(artikelen, list):
            links = [a.get("link") for a in artikelen]
            zin = maak_nieuwszin(artikelen, onderwerp)
            return zin, links
        else:
            return artikelen, []
