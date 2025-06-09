# services/ollama_api.py

import requests

class AIAssistantService:
    def __init__(self, model="llama3", url="http://localhost:11434/api/chat"):
        self.model = model
        self.url = url
        self.system_prompt = (
            "Beantwoord alle vragen in het Nederlands, ook als de vraag in het Engels wordt gesteld."
        )

    def stel_vraag(self, prompt):
        payload = {
            "model": self.model,
            "messages": [
                {"role": "system", "content": self.system_prompt},
                {"role": "user", "content": prompt}
            ],
            "stream": False
        }

        try:
            response = requests.post(self.url, json=payload)
            response.raise_for_status()
            return response.json()["message"]["content"]
        except requests.RequestException as e:
            return f"⚠️ Fout van Ollama: {e}"
