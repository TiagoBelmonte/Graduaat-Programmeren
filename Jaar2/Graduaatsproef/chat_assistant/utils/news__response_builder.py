def maak_nieuwszin(articles, onderwerp=None):
    zinnen = []

    for artikel in articles:
        titel = artikel.get("title", "Geen titel beschikbaar")
        bron = artikel.get("source_id", "een nieuwsbron")

        zin = f"- Volgens {bron} lees ik: '{titel}."  # persoonlijker en spraakvriendelijk
        zinnen.append(zin)

    if onderwerp:
        intro = f"Ik heb het laatste nieuws over {onderwerp} voor je opgezocht. Hier komt het:"
    else:
        intro = "Hier is het belangrijkste nieuws van vandaag:"

    resultaat = intro + "\n\n" + "\n".join(zinnen)
    return resultaat
