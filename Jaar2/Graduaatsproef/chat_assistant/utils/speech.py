import speech_recognition as sr

def get_voice_input():
    recognizer = sr.Recognizer()
    with sr.Microphone() as source:
        print("🎤 Spreek nu...")
        audio = recognizer.listen(source)
        try:
            text = recognizer.recognize_google(audio, language="nl-NL")
            print(f"🗣️ Jij zei: {text}")
            return text
        except sr.UnknownValueError:
            print("❌ Ik kon je spraak niet verstaan. Probeer het opnieuw.")
            return ""
        except sr.RequestError as e:
            print(f"⚠️ Fout bij spraakherkenning: {e}")
            return ""
