import re

def maak_weer_zin(data: dict, vraag: str, stad: str) -> str:
    temperatuur = round(data["main"]["temp"])
    beschrijving = data["weather"][0]["description"].lower()

    # Simpele kernwoorden herkennen
    vraag_lc = vraag.lower()

    if "regen" in vraag_lc:
        if "regen" in beschrijving:
            return f"Ja, het zal regenen in {stad.capitalize()} met een temperatuur van {temperatuur}°C."
        else:
            return f"Nee, het zal niet regenen in {stad.capitalize()}, maar het wordt {beschrijving} met {temperatuur}°C."
    
    elif "warm" in vraag_lc:
        if temperatuur >= 20:
            return f"Ja, het is vandaag lekker warm in {stad.capitalize()} met {temperatuur}°C en {beschrijving}."
        else:
            return f"Nee, het is niet echt warm in {stad.capitalize()} – het is {beschrijving} en {temperatuur}°C."
    
    elif "koud" in vraag_lc:
        if temperatuur < 10:
            return f"Ja, het is koud in {stad.capitalize()} met slechts {temperatuur}°C en {beschrijving}."
        else:
            return f"Nee, het is niet echt koud in {stad.capitalize()}, het is {beschrijving} en {temperatuur}°C."

    elif "graden" in vraag_lc or "temperatuur" in vraag_lc:
        return f"In {stad.capitalize()} is het momenteel {temperatuur}°C met {beschrijving}."

    else:
        # Algemene fallback
        return f"In {stad.capitalize()} is het {temperatuur}°C met {beschrijving}."
