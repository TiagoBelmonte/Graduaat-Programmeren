import React, { useRef, useState, useEffect } from "react";
import legeFoto from "../assets/Legepersoonfoto.png";
import { useNavigate, useLocation } from "react-router-dom";
import FullCalendar from "@fullcalendar/react";
import dayGridPlugin from "@fullcalendar/daygrid";
import { FaArrowLeft, FaArrowRight } from "react-icons/fa";
import Button from "../components/Button";

const Home = () => {
  const [currentDate, setCurrentDate] = useState(new Date());
  const [events, setEvents] = useState([]);
  const [quotes, setQuotes] = useState([]);
  const calendarRef = useRef(null);
  const navigate = useNavigate();
  const location = useLocation();
  const [user, setUser] = useState(null);
  const [schemas, setSchemas] = useState([]);
  const [trainingen, setTrainingen] = useState([]);
  const [selectedSchemaId, setSelectedSchemaId] = useState(null);

  useEffect(() => {
    const storedData = sessionStorage.getItem("userData");
    if (storedData) {
      setUser(JSON.parse(storedData));
    } else if (location.state?.user) {
      setUser(location.state.user);
    } else {
      console.error("Geen gebruiker gevonden!");
      navigate("/");
    }
  }, [location.state, navigate]);

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

          try {
            voedingen = await voedingResponse.json();
          } catch (voedingError) {
            console.warn("Geen voedingen gevonden:", voedingError);
          }

          const updatedSchemas = schemasData.map((schema) => ({
            ...schema,
            trainingen: trainings.filter(
              (training) => training.schemaID === schema.id
            ),
          }));

          setSchemas(updatedSchemas);

          const trainingEvents = trainings.map((training) => ({
            title: training.naam,
            date: new Date(training.datum).toISOString().split("T")[0],
            type: "training",
            trainingId: training.trainingId,
          }));

          const voedingEvents = voedingen.map((voeding) => ({
            title: "Voeding",
            date: new Date(voeding.datum).toISOString().split("T")[0],
            type: "voeding",
            voedingId: voeding.voedingId,
            color: "orange",
          }));

          setTrainingen(trainings);
          setEvents([...trainingEvents, ...voedingEvents]);
        } catch (error) {
          console.error("Fout bij het ophalen van gegevens:", error);
        }
      };

      fetchTrainingAndSchemasAndVoedingen();
    }
  }, [user]);

  const fetchQuotes = async () => {
    try {
      const responses = await Promise.all([
        fetch("http://api.quotable.io/quotes/random?tags=Motivational"),
        fetch("http://api.quotable.io/quotes/random?tags=Motivational"),
        fetch("http://api.quotable.io/quotes/random?tags=Motivational"),
      ]);
      const data = await Promise.all(responses.map((res) => res.json()));
      setQuotes(data.map((item) => item[0]));
    } catch (error) {
      console.error("Fout bij het ophalen van quotes:", error);
    }
  };

  useEffect(() => {
    fetchQuotes();
  }, []);

  if (!user) {
    return <div>Loading...</div>;
  }

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

  const selectedSchema = schemas.find(
    (schema) => schema.id === selectedSchemaId
  );
  const filteredTrainings = selectedSchema ? selectedSchema.trainingen : [];

  const handleEventClick = (info) => {
    info.jsEvent.preventDefault();

    if (info.event.extendedProps.type === "voeding") {
      const voedingId = info.event.extendedProps.voedingId;
      navigate("/Dieet", { state: { voedingId } });
    } else if (info.event.extendedProps.type === "training") {
      const trainingId = info.event.extendedProps.trainingId;
      navigate("/Training", { state: { trainingId } });
    } else {
      console.warn("Onbekend type evenement:", info.event.extendedProps.type);
    }
  };

  return user ? (
    <div className="flex flex-col items-center justify-center min-h-screen bg-red-600 px-4">
      <div className="flex items-center justify-between w-full max-w-xl mb-4">
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

      <div className="flex flex-col lg:flex-row w-full max-w-7xl">
        <div className="lg:flex-1 bg-gray-200 p-4 rounded shadow mb-4 lg:mb-0">
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
            Gegevens aanpassen
          </Button>
        </div>

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

        <div className="lg:flex-1 bg-gray-200 p-4 rounded shadow">
          <h3 className="text-lg font-semibold mb-4">Dagelijkse Motivatie</h3>
          {quotes.length > 0 ? (
            quotes.map((quote, index) => (
              <div key={index} className="mb-4 p-3 bg-white rounded shadow">
                <p className="italic">{quote.content}</p>
                <p className="text-right font-semibold">- {quote.author}</p>
              </div>
            ))
          ) : (
            <p>Quotes worden geladen...</p>
          )}
        </div>
      </div>
    </div>
  ) : (
    <div>Gebruiker wordt geladen...</div>
  );
};

export default Home;
