# utils/gmail_response_builder.py

def maak_email_zinnen(mails: list, onderwerp: str) -> str:
    if not mails:
        return f"Ik vond geen mails over '{onderwerp}'."

    zinnen = [f"📬 Ik heb deze mails gevonden over '{onderwerp}':\n"]
    for i, mail in enumerate(mails):
        van = mail.get("van", "onbekend")
        onderwerp_mail = mail.get("onderwerp", "geen onderwerp")
        zinnen.append(f"{i+1}. Van: {van}\n   Onderwerp: {onderwerp_mail}\n")

    zinnen.append("Wil je dat ik een van deze mails voorlees of open?")
    return "\n".join(zinnen)
