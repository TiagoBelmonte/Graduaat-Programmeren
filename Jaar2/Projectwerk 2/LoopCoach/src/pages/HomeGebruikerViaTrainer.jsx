import React, { useRef, useState, useEffect } from "react";
import legeFoto from "../assets/Legepersoonfoto.png";
import { useNavigate, useLocation } from "react-router-dom";
import FullCalendar from "@fullcalendar/react";
import dayGridPlugin from "@fullcalendar/daygrid";
import { FaArrowLeft, FaArrowRight } from "react-icons/fa";
import Button from "../components/Button";

const HomeGebruikerViaTrainer = () => {
  const [currentDate, setCurrentDate] = useState(new Date());
  const [events, setEvents] = useState([]);
  const calendarRef = useRef(null);
  const navigate = useNavigate();
  const location = useLocation();
  const { user } = location.state || {}; // Haal de user uit de state
  const [schemas, setSchemas] = useState([]);
  const [trainingen, setTrainingen] = useState([]);
  const [selectedSchemaId, setSelectedSchemaId] = useState(null);

  // Nieuwe state voor het toevoegen van een training
  const [isAddingTraining, setIsAddingTraining] = useState(false);
  const [trainingNaam, setTrainingNaam] = useState("");
  const [trainingDatum, setTrainingDatum] = useState("");
  const [trainingType, setTrainingType] = useState("");
  const [trainingSchema, setTrainingSchema] = useState("");

  // Nieuwe state voor het toevoegen van een voeding
  const [isAddingVoeding, setIsAddingVoeding] = useState(false);
  const [voedingDatum, setVoedingDatum] = useState("");
  const [ontbijt, setOntbijt] = useState("");
  const [infoOntbijt, setInfoOntbijt] = useState("");
  const [middagmaal, setMiddagmaal] = useState("");
  const [infoMiddagmaal, setInfoMiddagmaal] = useState("");
  const [avondmaal, setAvondmaal] = useState("");
  const [infoAvondmaal, setInfoAvondmaal] = useState("");
  const [snacks, setSnacks] = useState("");
  const [infoSnacks, setInfoSnacks] = useState("");

  useEffect(() => {
    if (!user) {
      console.error("Geen gebruiker meegegeven in state!");
      navigate("/"); // Redirect naar een veilige pagina
    }
  }, [user, navigate]);

  const handleMonthChange = (direction) => {
    const newDate = new Date(currentDate);
    newDate.setMonth(currentDate.getMonth() + direction);
    setCurrentDate(newDate);

    const calendarApi = calendarRef.current.getApi();
    calendarApi.gotoDate(newDate);
  };

  useEffect(() => {
    if (user && user.id) {
      const fetchTrainingAndSchemasAndVoedingen = async () => {
        try {
          const [trainingResponse, schemaResponse, voedingResponse] =
            await Promise.all([
              fetch(
                `https://localhost:7119/TrainingenOpvragenViaGebruikerId/${user.id}`
              ),
              fetch(`https://localhost:7119/LijstSchemas`),
              fetch(`https://localhost:7119/voedingenGebruiker/${user.id}`),
            ]);

          if (
            !trainingResponse.ok ||
            !schemaResponse.ok ||
            !voedingResponse.ok
          ) {
            throw new Error(
              `HTTP error! status: ${trainingResponse.status}, ${schemaResponse.status}, ${voedingResponse.status}`
            );
          }

          const trainings = await trainingResponse.json();
          const schemasData = await schemaResponse.json();
          let voedingen = [];

          // Probeer voedingen op te halen, maar faal niet als er geen resultaten zijn
          try {
            voedingen = await voedingResponse.json();
          } catch (voedingError) {
            console.warn("Geen voedingen gevonden:", voedingError);
          }

          // Combineer de schema's met de bijbehorende trainingen
          const updatedSchemas = schemasData.map((schema) => ({
            ...schema,
            trainingen: trainings.filter(
              (training) => training.schemaID === schema.id
            ),
          }));

          setSchemas(updatedSchemas);

          // Maak evenementen voor trainingen
          const trainingEvents = trainings.map((training) => ({
            title: training.naam,
            date: new Date(training.datum).toISOString().split("T")[0],
            type: "training",
            trainingId: training.trainingId,
          }));

          // Maak evenementen voor voedingen (indien aanwezig)
          const voedingEvents = voedingen.map((voeding) => ({
            title: "Voeding",
            date: new Date(voeding.datum).toISOString().split("T")[0],
            type: "voeding",
            voedingId: voeding.voedingId,
            color: "orange", // Gebruik een andere kleur voor voedingen
          }));

          setTrainingen(trainings); // Zet alle trainingen in de staat
          setEvents([...trainingEvents, ...voedingEvents]); // Combineer beide types evenementen
        } catch (error) {
          console.error("Fout bij het ophalen van gegevens:", error);
        }
      };

      fetchTrainingAndSchemasAndVoedingen();
    }
  }, [user]);

  const calculateAge = (birthDate) => {
    const birth = new Date(birthDate);
    const today = new Date();
    let age = today.getFullYear() - birth.getFullYear();
    const month = today.getMonth();
    const day = today.getDate();

    if (
      month < birth.getMonth() ||
      (month === birth.getMonth() && day < birth.getDate())
    ) {
      age--;
    }

    return age;
  };

  const age = user ? calculateAge(user.geboorteDatum) : null;

  const handleSchemaChange = (event) => {
    const selectedId = parseInt(event.target.value, 10);
    setSelectedSchemaId(selectedId);
  };

  // Filter trainingen op basis van geselecteerd schema
  const selectedSchema = schemas.find(
    (schema) => schema.id === selectedSchemaId
  );
  const filteredTrainings = selectedSchema ? selectedSchema.trainingen : [];

  const handleEventClick = (info) => {
    info.jsEvent.preventDefault();

    // Check het type van het evenement
    if (info.event.extendedProps.type === "voeding") {
      const voedingId = info.event.extendedProps.voedingId;
      navigate("/Dieet", { state: { voedingId } });
      // Navigeer naar de Dieet-pagina
    } else if (info.event.extendedProps.type === "training") {
      const trainingId = info.event.extendedProps.trainingId;
      navigate("/Training", { state: { trainingId } });
    } else {
      console.warn("Onbekend type evenement:", info.event.extendedProps.type);
    }
  };

  const buttonEventClickTraining = () => {
    navigate("/NewTraining");
  };

  const buttonEventClickVoeding = () => {
    navigate("/NieuwDieet", { state: { userId: user.id } }); // Gebruik de juiste key voor userId
  };

  const handleSaveTraining = async () => {
    try {
      // Zet de huidige datum en tijd
      const huidigeDatum = new Date().toISOString();

      // Maak de data die naar de API moet worden verzonden
      const apiData = {
        naam: trainingNaam,
        datum: trainingDatum || huidigeDatum,
        type: parseInt(trainingType) || 0,
        schemaId: parseInt(trainingSchema),
      };

      console.log("Verzonden data naar API:", apiData);

      // Verstuur de data naar de API
      const response = await fetch("https://localhost:7119/TrainingAanmaken", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(apiData),
      });

      if (!response.ok) {
        throw new Error("Fout bij het aanmaken van training");
      }

      // Reset de velden en verberg de invoervelden
      setIsAddingTraining(false);
      setTrainingNaam("");
      setTrainingDatum("");
      setTrainingType("");
      setTrainingSchema("");

      // Je kunt hier eventueel de opgehaalde data van de API gebruiken om de lijst van trainingen bij te werken
      console.log("Training succesvol aangemaakt!");

      // Herlaad de pagina
      window.location.reload();
    } catch (error) {
      console.error("Fout bij het versturen van gegevens naar de API:", error);
    }
  };
  const handleSaveVoeding = async () => {
    try {
      // Maak de data die naar de API moet worden verzonden
      const apiData = {
        datum: voedingDatum,
        ontbijt: ontbijt,
        infoOntbijt: infoOntbijt,
        middagmaal: middagmaal,
        infoMiddagmaal: infoMiddagmaal,
        avondmaal: avondmaal,
        infoAvondmaal: infoAvondmaal,
        snacks: snacks,
        infoSnacks: infoSnacks,
      };

      console.log("Verzonden data naar API:", apiData);

      // Verstuur de data naar de API
      const response = await fetch(
        `https://localhost:7119/VoedingGebruikerToevoegen/${user.id}`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(apiData),
        }
      );

      if (!response.ok) {
        throw new Error("Fout bij het aanmaken van training");
      }

      // Reset de velden en verberg de invoervelden
      setIsAddingVoeding(false);
      setVoedingDatum("");
      setOntbijt("");
      setInfoOntbijt("");
      setMiddagmaal("");
      setInfoMiddagmaal("");
      setAvondmaal("");
      setInfoAvondmaal("");
      setSnacks("");
      setInfoSnacks("");

      // Je kunt hier eventueel de opgehaalde data van de API gebruiken om de lijst van trainingen bij te werken
      console.log("Voeding succesvol aangemaakt!");

      // Herlaad de pagina
      window.location.reload();
    } catch (error) {
      console.error("Fout bij het versturen van gegevens naar de API:", error);
    }
  };

  return user ? (
    <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100">
      <div className="flex items-center justify-between w-96 mb-4">
        <button
          onClick={() => handleMonthChange(-1)}
          className="p-2 bg-gray-300 rounded hover:bg-gray-400"
        >
          <FaArrowLeft />
        </button>
        <h2 className="text-xl font-bold">
          {currentDate.toLocaleString("default", {
            month: "long",
            year: "numeric",
          })}
        </h2>
        <button
          onClick={() => handleMonthChange(1)}
          className="p-2 bg-gray-300 rounded hover:bg-gray-400"
        >
          <FaArrowRight />
        </button>
      </div>
      <div className="flex w-full max-w-7xl">
        {/* Linker kolom */}
        <div className="flex-1 bg-gray-200 p-4 rounded shadow">
          <h3 className="text-lg font-semibold">Persoonlijke gegevens</h3>
          <p>Naam: {user.naam}</p>
          <p>Email: {user.email}</p>
          <p>Leeftijd: {age}</p>
          <p style={{ marginBottom: "20px" }}>Geslacht: {user.geslacht}</p>
          <h3 className="text-lg font-semibold">Sportieve gegevens</h3>
          <p>Gewicht: {user.gewicht} Kg</p>
          <p>Lengte: {user.lengte} cm</p>
          <p>Recuperatie: {user.recuperatie}</p>
          <p>Lsd: {user.lsd}</p>
          <p>Ext: {user.ext}</p>
          <p>Interval: {user.interval}</p>
          <p style={{ marginBottom: "20px" }}>Weerstand: {user.weerstand}</p>
          <Button
            style={{ width: "100%" }}
            onClick={() => navigate(`/Profile`, { state: { user } })}
          >
            gegevens aanpassen
          </Button>
          <br />

          <br />
          <Button eventclick={buttonEventClickTraining}>
            Training toevoegen
          </Button>
          <Button eventclick={buttonEventClickVoeding}>
            Voeding toevoegen
          </Button>

          {/* Velden voor training toevoegen */}
          {isAddingTraining && (
            <div className="mt-4">
              <input
                type="text"
                placeholder="Naam van de training"
                value={trainingNaam}
                onChange={(e) => setTrainingNaam(e.target.value)}
                className="w-full p-2 mb-4 border rounded"
              />
              <input
                type="date"
                value={trainingDatum}
                onChange={(e) => setTrainingDatum(e.target.value)}
                className="w-full p-2 mb-4 border rounded"
              />
              <input
                type="number"
                placeholder="Type (int)"
                value={trainingType}
                onChange={(e) => setTrainingType(e.target.value)}
                className="w-full p-2 mb-4 border rounded"
              />
              <select
                onChange={(e) => setTrainingSchema(e.target.value)}
                value={trainingSchema}
                className="w-full p-2 mb-4 border rounded"
              >
                <option value="" disabled>
                  -- Kies een schema --
                </option>
                {schemas.map((schema) => (
                  <option key={schema.id} value={schema.id}>
                    {schema.naam}
                  </option>
                ))}
              </select>
              <Button eventclick={handleSaveTraining}>Opslaan</Button>
            </div>
          )}
          {/* Velden voor voeding toevoegen */}
          {isAddingVoeding && (
            <div className="mt-4">
              <input
                type="date"
                value={voedingDatum}
                onChange={(e) => setVoedingDatum(e.target.value)}
                className="w-full p-2 mb-4 border rounded"
              />
              <input
                type="string"
                placeholder="ontbijt"
                value={ontbijt}
                onChange={(e) => setOntbijt(e.target.value)}
                className="w-full p-2 mb-4 border rounded"
              />
              <input
                type="string"
                placeholder="Info ontbijt"
                value={infoOntbijt}
                onChange={(e) => setInfoOntbijt(e.target.value)}
                className="w-full p-2 mb-4 border rounded"
              />
              <input
                type="string"
                placeholder="middaagmaal"
                value={middagmaal}
                onChange={(e) => setMiddagmaal(e.target.value)}
                className="w-full p-2 mb-4 border rounded"
              />
              <input
                type="string"
                placeholder="Info middagmaal"
                value={infoMiddagmaal}
                onChange={(e) => setInfoMiddagmaal(e.target.value)}
                className="w-full p-2 mb-4 border rounded"
              />
              <input
                type="string"
                placeholder="avondmaal"
                value={avondmaal}
                onChange={(e) => setAvondmaal(e.target.value)}
                className="w-full p-2 mb-4 border rounded"
              />
              <input
                type="string"
                placeholder="Info avondmaal"
                value={infoAvondmaal}
                onChange={(e) => setInfoAvondmaal(e.target.value)}
                className="w-full p-2 mb-4 border rounded"
              />
              <input
                type="string"
                placeholder="snacks"
                value={snacks}
                onChange={(e) => setSnacks(e.target.value)}
                className="w-full p-2 mb-4 border rounded"
              />
              <input
                type="string"
                placeholder="Info snacks"
                value={infoSnacks}
                onChange={(e) => setInfoSnacks(e.target.value)}
                className="w-full p-2 mb-4 border rounded"
              />

              <Button eventclick={handleSaveVoeding}>Opslaan</Button>
            </div>
          )}
        </div>
        {/* Midden kolom (Kalender) */}
        <div className="lg:flex-[2] bg-white p-4 mx-0 lg:mx-4 rounded shadow">
          <div className="w-full">
            <FullCalendar
              ref={calendarRef}
              plugins={[dayGridPlugin]}
              initialView="dayGridMonth"
              events={events.map((event) => ({
                ...event,
                color: event.type === "training" ? "blue" : "green",
              }))}
              headerToolbar={false}
              initialDate={currentDate}
              eventClick={handleEventClick}
            />
          </div>
        </div>
        {/* Rechter kolom */}
        <div className="flex-1 bg-gray-200 p-4 rounded shadow">
          <h3 className="text-lg font-semibold">Schemas en Trainingen</h3>
          <select
            onChange={handleSchemaChange}
            value={selectedSchemaId || ""}
            className="w-full p-2 mb-4 border rounded"
          >
            <option value="" disabled>
              -- Kies een schema --
            </option>
            {schemas.map((schema) => (
              <option key={schema.id} value={schema.id}>
                {schema.naam}
              </option>
            ))}
          </select>
          {selectedSchemaId === null ? (
            <p>Selecteer een schema om de trainingen te bekijken.</p>
          ) : filteredTrainings.length > 0 ? (
            <ul>
              {filteredTrainings.map((training) => (
                <li key={training.trainingId}>
                  <strong>{training.naam}</strong> -{" "}
                  {new Date(training.datum).toLocaleDateString()}
                </li>
              ))}
            </ul>
          ) : (
            <p>Geen trainingen beschikbaar voor dit schema.</p>
          )}
        </div>
      </div>
    </div>
  ) : (
    <div>Gebruiker wordt geladen...</div>
  );
};

export default HomeGebruikerViaTrainer;
