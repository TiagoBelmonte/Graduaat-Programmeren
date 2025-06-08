import asyncio
import edge_tts
import pygame
import time
import os
import re

stop_generatie = False  # globale vlag

def clean_text(text):
    return re.sub(r'[*_`"]', "", text).strip()

async def speak_async(text):
    global stop_generatie
    stop_generatie = False

    output_file = "temp.mp3"
    communicate = edge_tts.Communicate(text, voice="nl-NL-MaartenNeural")
    await communicate.save(output_file)

    pygame.mixer.init()
    pygame.mixer.music.load(output_file)
    pygame.mixer.music.play()

    while pygame.mixer.music.get_busy():
        if stop_generatie:
            pygame.mixer.music.stop()
            break
        await asyncio.sleep(0.1)

    pygame.mixer.quit()
    try:
        os.remove(output_file)
    except:
        pass

def speak(text):
    asyncio.run(speak_async(text))

def stop_speech():
    global stop_generatie
    stop_generatie = True
