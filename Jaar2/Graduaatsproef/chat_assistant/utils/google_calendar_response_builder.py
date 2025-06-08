import datetime
import locale
from collections import defaultdict

# 🇧🇪 Probeer NL-weergave voor dagnamen
try:
    locale.setlocale(locale.LC_TIME, "nl_BE.utf8")
except:
    try:
        locale.setlocale(locale.LC_TIME, "nld")  # Windows fallback
    except:
        pass

def format_dag(datum: datetime.datetime) -> str:
    return datum.strftime("%A").capitalize()  # bv. "Maandag"

def maak_agendazinnen(events: list, periode: str) -> str:
    if not events:
        return {
            "week": "Je hebt deze week geen afspraken.",
            "tomorrow": "Je hebt morgen geen afspraken.",
            "today": "Je hebt vandaag geen afspraken."
        }.get(periode, "Je hebt geen afspraken.")

    # Alle afspraken per dag bundelen
    dagen = defaultdict(list)

    for event in events:
        start_raw = event['start'].get('dateTime', event['start'].get('date'))
        titel = event.get('summary', 'een afspraak')

        if "T" in start_raw:
            dt = datetime.datetime.fromisoformat(start_raw.replace("Z", "+00:00"))
            tijd = f"{int(dt.strftime('%H'))}u"
        else:
            dt = datetime.datetime.fromisoformat(start_raw)
            tijd = "de hele dag"

        dagnaam = format_dag(dt)
        dagen[dagnaam].append((tijd, titel))

    # Bouw output per dag op
    zinnen = []

    for dag in sorted(dagen.keys(), key=lambda d: ["Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag", "Zaterdag", "Zondag"].index(d)):
        afspraken = dagen[dag]
        if len(afspraken) == 1:
            tijd, titel = afspraken[0]
            zinnen.append(f"{dag} heb je één afspraak: om {tijd}: {titel}.")
        else:
            dagzin = f"{dag} heb je {len(afspraken)} afspraken:"
            for i, (tijd, titel) in enumerate(afspraken):
                if i == 0:
                    dagzin += f" om {tijd}: {titel}."
                elif i == len(afspraken) - 1:
                    dagzin += f" Tot slot om {tijd}: {titel}."
                else:
                    dagzin += f" Daarna om {tijd}: {titel}."
            zinnen.append(dagzin)

    return " ".join(zinnen)
