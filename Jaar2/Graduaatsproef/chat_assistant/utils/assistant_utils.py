import asyncio
import edge_tts  # Text-to-speech via Microsoft Edge Voices
import pygame    # Voor audio afspelen
import os
import re

# Globale vlag om spraak vroegtijdig te stoppen
stop_generatie = False

# Verwijdert ongewenste tekens uit de tekst voordat die wordt uitgesproken
def clean_text(text):
    return re.sub(r'[*_`"]', "", text).strip()

# Asynchrone functie om tekst om te zetten naar spraak en af te spelen
async def speak_async(text):
    global stop_generatie
    stop_generatie = False

    output_file = "temp.mp3"

    # Zet tekst om naar audio met Edge TTS (Nederlandse stem Maarten)
    communicate = edge_tts.Communicate(text, voice="nl-NL-MaartenNeural")
    await communicate.save(output_file)

    # Start Pygame mixer om het audiobestand af te spelen
    pygame.mixer.init()
    pygame.mixer.music.load(output_file)
    pygame.mixer.music.play()

    # Blijf wachten tot het afspelen klaar is, tenzij gebruiker het onderbreekt
    while pygame.mixer.music.get_busy():
        if stop_generatie:
            pygame.mixer.music.stop()
            break
        await asyncio.sleep(0.1)

    # Sluit Pygame mixer af
    pygame.mixer.quit()
    # Verwijder tijdelijk MP3-bestand
    try:
        os.remove(output_file)
    except:
        pass

# Synchronous wrapper om `speak_async` eenvoudig aan te roepen
def speak(text):
    asyncio.run(speak_async(text))

# Hiermee kan het afspelen van spraak vroegtijdig gestopt worden
def stop_speech():
    global stop_generatie
    stop_generatie = True
