from utils.speech import get_voice_input
from utils.assistant_utils import speak, clean_text
from handlers.intent_handlers import behandel_vraag



def main():
    while True:
        vraag = get_voice_input()
        if vraag.lower() in ["stop", "exit", "afsluiten"]:
            print("👋 Tot de volgende keer!") 
            break

        print(f"📥 Gekregen input: {vraag}")

        if not vraag:
            continue

        antwoord = behandel_vraag(vraag)
        print(f"🤖 Antwoord: {antwoord}")
        spreektekst = clean_text(antwoord)
        speak(spreektekst)


if __name__ == "__main__":
    main()

