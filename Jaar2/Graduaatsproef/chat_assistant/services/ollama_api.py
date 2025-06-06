import requests

def ask_ollama(prompt):
    response = requests.post(
        "http://localhost:11434/api/chat",
        json={
            "model": "llama3",
            "messages": [
                {"role": "system", "content": "Beantwoord alle vragen in het Nederlands, ook als de vraag in het Engels wordt gesteld."},
                {"role": "user", "content": prompt}
                ],
            "stream": False
        }
    )

    if response.status_code == 200:
        return response.json()["message"]["content"]
    else:
        return f"⚠️ Fout van Ollama: {response.status_code} – {response.text}"
