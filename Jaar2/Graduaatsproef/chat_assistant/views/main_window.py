import tkinter as tk
from PIL import Image, ImageTk
import speech_recognition as sr
import threading
import pyttsx3
import asyncio
import edge_tts
import pygame

import sys, os
sys.path.append(os.path.abspath(os.path.join(os.path.dirname(__file__), "..")))

from utils.speech import get_voice_input
from utils.assistant_utils import speak, clean_text, stop_speech
from handlers.intent_handlers import behandel_vraag



# Spraaksynthese engine
engine = pyttsx3.init()

# UI instellen
root = tk.Tk()
root.title("GraPro Assistent")
root.configure(bg="black")
root.geometry("400x600")

# Logo
logo_img = Image.open("../GraPro_logo_zwart.png")
logo_img = logo_img.resize((250, 250))
logo_photo = ImageTk.PhotoImage(logo_img)
logo_label = tk.Label(root, image=logo_photo, bg="black")
logo_label.pack(pady=30)

# Vraaglabel
vraag_label = tk.Label(root, text="", fg="white", bg="black", font=("Helvetica", 12), wraplength=350, justify="left")
vraag_label.pack(pady=5)

# Antwoordlabel
response_label = tk.Label(root, text="", fg="white", bg="black", font=("Helvetica", 14), wraplength=350, justify="left")
response_label.pack(pady=20)

# Voor annulering
stop_generatie = False
animation_job = None


# Functie om de knopstatus in te stellen
# Globale animatie-ID
animation_job = None

def set_button_state(text, enabled):
    global animation_job

    # Stop eventuele animatie
    if animation_job:
        root.after_cancel(animation_job)

    speak_button.config(text=text)
    if enabled:
        speak_button.config(state="normal", bg="#800080", fg="white", font=("Helvetica", 16, "bold"),
                            relief="flat", padx=20, pady=10, bd=0, cursor="hand2")
    else:
        speak_button.config(state="disabled", bg="gray", fg="white", font=("Helvetica", 16, "bold"),
                            relief="flat", padx=20, pady=10, bd=0, cursor="arrow")

def animate_dots(base_text, step=0, max_steps=3, interval=500):
    global animation_job

    dots = '.' * (step % (max_steps + 1))
    speak_button.config(text=f"{base_text}{dots}")
    animation_job = root.after(interval, lambda: animate_dots(base_text, step + 1))

# Typewriter effect
def typewriter_effect(text, index=0):
    global stop_generatie

    if stop_generatie or index >= len(text):
        return

    current = response_label.cget("text")
    response_label.config(text=current + text[index])
    root.after(30, lambda: typewriter_effect(text, index + 1))


async def speak_with_edge_tts(text):
    try:
        communicate = edge_tts.Communicate(text, voice="nl-NL-MaartenNeural")
        await communicate.play()
    except Exception as e:
        print(f"⚠️ Fout bij spreken: {e}")


def annuleer_generatie():
    global stop_generatie, animation_job

    stop_generatie = True
    stop_speech()  # stop edge-tts spraak

    # Stop animatie als die bezig is
    if animation_job:
        root.after_cancel(animation_job)

    # Reset UI
    response_label.config(text="")  # ⬅️ verwijder het antwoord
    vraag_label.config(text="❌ Generatie geannuleerd.")
    set_button_state("🎤 Spreek", enabled=True)

    


# Microfoon luisteren en verwerken
def luister_en_verwerk():
    global stop_generatie
    stop_generatie = False

    
    try:
        # Disable knop & toon luisteren
        set_button_state("🎙️ Aan het luisteren", enabled=False)
        animate_dots("🎙️ Aan het luisteren")


        # Vraag opnemen
        vraag = get_voice_input()
        if not vraag:
            response_label.config(text="⚠️ Niets verstaan.")
            set_button_state("🎤 Spreek", enabled=True)
            return

        # Vraag tonen
        vraag_label.config(text="🗣️ Jij zei: " + vraag)

        # 🔁 Zet knop op "verwerken"
        set_button_state("💭 Vraag aan het verwerken", enabled=False)
        animate_dots("💭 Vraag aan het verwerken")
        root.update_idletasks()

        # Vraag tonen
        vraag_label.config(text="🗣️ Jij zei: " + vraag)
        root.update_idletasks()

        # Vraag verwerken
        antwoord = behandel_vraag(vraag)
        print("🤖 Antwoord:", antwoord)

        # Antwoord tonen en spreken
        response_label.config(text="")
        threading.Thread(target=typewriter_effect, args=(antwoord,)).start()

        spreektekst = clean_text(antwoord)
        def spreek_en_reset():
            speak(spreektekst)
            set_button_state("🎤 Spreek", enabled=True)

        threading.Thread(target=spreek_en_reset).start()

    except Exception as e:
        response_label.config(text=f"⚠️ Fout: {e}")
        set_button_state("🎤 Spreek", enabled=True)


# Spreek-knop
speak_button = tk.Button(
    root,
    text="🎤 Spreek",
    font=("Helvetica", 16, "bold"),
    bg="#8A2BE2",
    fg="white",
    activebackground="#6a1bbf",
    activeforeground="white",
    padx=20,
    pady=10,
    bd=0,
    relief="flat",
    cursor="hand2",
    command=lambda: threading.Thread(target=luister_en_verwerk).start()
)
speak_button.pack(pady=10)

cancel_button = tk.Button(
    root,
    text="❌ Annuleer",
    font=("Helvetica", 12),
    bg="darkred",
    fg="white",
    activebackground="#b22222",
    activeforeground="white",
    padx=10,
    pady=5,
    bd=0,
    relief="flat",
    cursor="hand2",
    command=annuleer_generatie
)
cancel_button.pack(pady=5)



root.mainloop()
