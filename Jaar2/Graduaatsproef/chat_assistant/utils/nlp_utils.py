import re

def detect_weather_question(vraag: str):
    """
    Detecteert of een vraag over het weer gaat en haalt de stad uit de zin.
    Ondersteunt formuleringen zoals:
    - "Wat is het weer in Gent?"
    - "Hoeveel graden is het in Barcelona?"
    - "Gaat het regenen in Tielt vandaag?"
    - "Hoe warm is het in Parijs?"
    - "Is het koud in Madrid?"
    """
    vraag = vraag.lower()

    # Brede regex voor weer-gerelateerde vragen met een locatie
    match = re.search(
        r"(?:weer|temperatuur|graden|warm|koud|regen|droog|klimaat|zon).*?(?:in\s+)([a-zA-Z\u00C0-\u017F\s\-]+?)(?:\s+vandaag|\s+\?|$)",
        vraag
    )

    if match:
        stad = match.group(1).strip()
        return stad

    return None
