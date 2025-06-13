# services/ollama_api.py

import requests

class AIAssistantService:
    def __init__(self, model="llama3", url="http://localhost:11434/api/chat"):
        # Stelt het standaardmodel en de URL van de Ollama API in
        self.model = model
        self.url = url
        # Prompt die aangeeft dat antwoorden altijd in het Nederlands moeten zijn
        self.system_prompt = (
            "Beantwoord alle vragen in het Nederlands, ook als de vraag in het Engels wordt gesteld."
        )

    def stel_vraag(self, prompt):
        # Stelt de payload samen voor de API-call
        payload = {
            "model": self.model,
            "messages": [
                {"role": "system", "content": self.system_prompt},
                {"role": "user", "content": prompt}
            ],
            "stream": False  # Geen streaming, enkel volledig antwoord
        }

        try:
            # Verstuur POST-verzoek naar Ollama server
            response = requests.post(self.url, json=payload)
            response.raise_for_status()
            # Haal het antwoord van de AI op
            return response.json()["message"]["content"]
        except requests.RequestException as e:
            # Geef foutmelding terug als de API faalt
            return f"⚠️ Fout van Ollama: {e}"
