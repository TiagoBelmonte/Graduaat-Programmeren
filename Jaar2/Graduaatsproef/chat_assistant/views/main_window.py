import tkinter as tk
from PIL import Image, ImageTk

# Venster aanmaken
root = tk.Tk()
root.title("GraPro Assistent")
root.configure(bg="black")
root.geometry("400x600")

# Logo laden
logo_img = Image.open("../GraPro_logo_zwart.png")
logo_img = logo_img.resize((250, 250))
logo_photo = ImageTk.PhotoImage(logo_img)

# Logo weergeven
logo_label = tk.Label(root, image=logo_photo, bg="black")
logo_label.pack(pady=30)

# Antwoordlabel (komt later)
response_label = tk.Label(root, text="", fg="white", bg="black", font=("Helvetica", 14), wraplength=350)
response_label.pack(pady=20)

# Spreek-knop
def start_listening():
    print("👂 Hier komt straks de spraakinput...")

speak_button = tk.Button(root, text="🎤 Spreek", command=start_listening, font=("Helvetica", 16), bg="purple", fg="white", padx=20, pady=10)
speak_button.pack(pady=10)

root.mainloop()
