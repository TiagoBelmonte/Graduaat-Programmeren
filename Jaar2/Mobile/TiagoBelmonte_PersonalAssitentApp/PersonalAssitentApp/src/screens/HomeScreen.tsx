import React, { useState } from "react";
import { View, Button, Text } from "react-native";
import { loginWithGoogle } from "../api/GoogleAuth"; // (niet uit dia’s, maar past bij Firebase OAuth integratie)
import { getCalendarEvents } from "../api/getEventsFromCalendar"; // (eigen fetch-call naar Google Calendar API)

type CalendarEvent = {
  summary: string;
  // add other properties if needed
};

export default function HomeScreen() {
  const [events, setEvents] = useState<CalendarEvent[]>([]); // (basis React hook, geen specifieke dia)

  const handleConnect = async () => {
    try {
      const token = await loginWithGoogle(); // (auth flow – gerelateerd aan dia 26–28 Firebase)
      const calendarEvents = await getCalendarEvents(token); // (dia 143–144) data ophalen via fetch()
      setEvents(calendarEvents); // resultaten opslaan in local state
    } catch (e) {
      console.error("❌ Login of fetch fout:", e); // eenvoudige foutafhandeling
    }
  };

  return (
    <View
      style={{
        flex: 1,
        justifyContent: "center",
        alignItems: "center",
        padding: 20,
      }}
    >
      {/* (dia 110, 115) Button en Text componenten gebruiken */}
      <Button title="Verbind met Google Agenda" onPress={handleConnect} />
      {events.map((event, i) => (
        <Text key={i}>{event.summary}</Text> // (dynamic rendering van data)
      ))}
    </View>
  );
}
