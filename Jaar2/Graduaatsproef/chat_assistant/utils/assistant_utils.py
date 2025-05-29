import asyncio
import edge_tts
import pygame
import time
import os
import re

def clean_text(text):
    # Verwijder ongewenste tekens zoals asterisks
    text = re.sub(r'[*_`"]', "", text)
    return text.strip()

async def speak_async(text):
    output_file = "temp.mp3"
    communicate = edge_tts.Communicate(text, voice="nl-NL-MaartenNeural")
    await communicate.save(output_file)

    pygame.mixer.init()
    pygame.mixer.music.load(output_file)
    pygame.mixer.music.play()

    while pygame.mixer.music.get_busy():
        time.sleep(0.1)

    pygame.mixer.music.stop()
    pygame.mixer.quit()
    time.sleep(0.2)
    os.remove(output_file)

def speak(text):
    asyncio.run(speak_async(text))
