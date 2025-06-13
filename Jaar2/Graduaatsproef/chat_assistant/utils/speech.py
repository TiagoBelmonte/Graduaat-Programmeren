import speech_recognition as sr

# Functie om Nederlandse spraak van de gebruiker om te zetten naar tekst
def get_voice_input():
    recognizer = sr.Recognizer()  # Maak een herkenner-object aan

    with sr.Microphone() as source:
        print("🎤 Spreek nu...")  # Vraag de gebruiker om te spreken
        audio = recognizer.listen(source)  # Luister naar de microfooninput

        try:
            # Gebruik Google’s gratis spraakherkenning API (herkent Nederlands)
            text = recognizer.recognize_google(audio, language="nl-NL")
            print(f"🗣️ Jij zei: {text}")
            return text

        except sr.UnknownValueError:
            # Geen verstaanbare spraak gedetecteerd
            print("❌ Ik kon je spraak niet verstaan. Probeer het opnieuw.")
            return ""

        except sr.RequestError as e:
            # Fout bij het verbinden met de API
            print(f"⚠️ Fout bij spraakherkenning: {e}")
            return ""
