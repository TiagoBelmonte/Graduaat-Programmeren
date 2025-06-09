import re

def detect_weather_question(vraag: str):
    vraag = vraag.lower()
    match = re.search(
        r"(?:weer|temperatuur|graden|warm|koud|regen|droog|klimaat|zon).*?(?:in\s+)([a-zA-Z\u00C0-\u017F\s\-]+?)(?:\s+vandaag|\s+\?|$)",
        vraag
    )
    if match:
        stad = match.group(1).strip()
        return stad
    return None


def detect_news_question(vraag: str):
    vraag = vraag.lower()

    categorieën = [
        "politiek", "economie", "sport", "gezondheid", "technologie",
        "entertainment", "wetenschap", "business", "wereld"
    ]

    landen_map = {
        "belgië": "be",
        "nederland": "nl",
        "frankrijk": "fr",
        "duitsland": "de",
        "vs": "us",
        "amerika": "us",
        "china": "cn"
    }

    category = None
    country = None

    for c in categorieën:
        if c in vraag:
            category = c
            break

    for l in landen_map:
        if l in vraag:
            country = landen_map[l]
            break

    nieuws_woorden = ["nieuws", "nieuwsitems", "nieuwsberichten", "gebeurd", "gebeurtenissen", "laatste berichten"]

    if any(w in vraag for w in nieuws_woorden):
        return {
            "topic": category or "wereld",  # ✅ fallback naar 'wereld' i.p.v. 'general'
            "country": country
        }

    return None

