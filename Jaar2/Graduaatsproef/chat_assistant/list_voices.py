import asyncio
import edge_tts

async def list_voices():
    voices = await edge_tts.list_voices()
    for voice in voices:
        if "nl-" in voice["ShortName"].lower():
            print(f'{voice["ShortName"]} – {voice["Gender"]} – {voice["FriendlyName"]}')

asyncio.run(list_voices())
