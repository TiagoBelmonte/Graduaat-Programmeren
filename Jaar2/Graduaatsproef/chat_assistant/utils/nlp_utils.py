import re

# Herkent vragen over het weer in een specifieke stad
def detect_weather_question(vraag: str):
    vraag = vraag.lower()
    # Zoek naar woorden zoals "weer", "temperatuur" enz. gevolgd door "in [stad]"
    match = re.search(
        r"(?:weer|temperatuur|graden|warm|koud|regen|droog|klimaat|zon).*?(?:in\s+)([a-zA-Z\u00C0-\u017F\s\-]+?)(?:\s+vandaag|\s+\?|$)",
        vraag
    )
    if match:
        stad = match.group(1).strip()
        return stad
    return None

# Herkent vragen over nieuws, inclusief categorieën en landen
def detect_news_question(vraag: str):
    vraag = vraag.lower()

    # Ondersteunde categorieën
    categorieën = [
        "politiek", "economie", "sport", "gezondheid", "technologie",
        "entertainment", "wetenschap", "business", "wereld"
    ]

    # Mapping van landen naar landcodes
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

    # Kijk of een bekende categorie voorkomt in de vraag
    for c in categorieën:
        if c in vraag:
            category = c
            break

    # Kijk of een land voorkomt in de vraag en vertaal naar landcode
    for l in landen_map:
        if l in vraag:
            country = landen_map[l]
            break

    # Woorden die duiden op een nieuwsgerelateerde vraag
    nieuws_woorden = ["nieuws", "nieuwsitems", "nieuwsberichten", "gebeurd", "gebeurtenissen", "laatste berichten"]

    # Als de vraag een nieuwswoord bevat, return topic en land
    if any(w in vraag for w in nieuws_woorden):
        return {
            "topic": category or "wereld",  # fallback naar 'wereld' als geen categorie gevonden
            "country": country
        }

    return None

# Herkent vragen naar e-mails over een bepaald onderwerp
def detect_email_question(vraag: str):
    vraag = vraag.lower()

    # Controleer of de vraag over e-mails gaat
    if any(w in vraag for w in ["mail", "mails", "e-mail", "e-mails", "inbox"]):
        # Zoek onderwerp na "over", "met (als) onderwerp", enz.
        patroon = r"(?:over|met(?:\s+als)?(?:\s+onderwerp)?|onderwerp)\s+(?:\"|')?([\w\s\-]+)(?:\"|')?"
        match = re.search(patroon, vraag)
        if match:
            onderwerp = match.group(1).strip()
            return onderwerp

    return None
