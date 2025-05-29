import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

const NewTrainingPage = () => {
  const navigate = useNavigate();
  const [schemas, setSchemas] = useState([]);
  const [formData, setFormData] = useState({
    typeTraining: "",
    gemHartslag: "",
    afstand: "",
    persoonlijkeScore: "",
    duur: "",
    zelfEvaluatie: "",
    beschrijving: "",
    feedbackCoach: "",
    extraOefening: "",
    naam: "",
    datum: "",
    schema: "",
    type: "",
  });

  // Ophalen van schemas bij component load
  useEffect(() => {
    const fetchSchemas = async () => {
      try {
        const response = await fetch("https://localhost:7119/LijstSchemas");
        if (response.ok) {
          const data = await response.json();
          setSchemas(data);
        } else {
          console.error("Fout bij ophalen van schemas:", response.statusText);
        }
      } catch (error) {
        console.error("Error bij ophalen van schemas:", error);
      }
    };

    fetchSchemas();
  }, []);

  // Handler voor wijzigingen in de invoervelden
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  // Opslaan functionaliteit
  const handleSave = async () => {
    try {
      const huidigeDatum = new Date().toISOString();
      const apiData = {
        naam: formData.naam,
        datum: formData.datum || huidigeDatum,
        type: parseInt(formData.persoonlijkeScore) || 0,
        schemaId: parseInt(formData.schema) || 0,
      };

      const response = await fetch("https://localhost:7119/TrainingAanmaken", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(apiData),
      });

      if (response.ok) {
        alert("Training succesvol opgeslagen!");
        setFormData({
          typeTraining: "",
          gemHartslag: "",
          afstand: "",
          persoonlijkeScore: "",
          duur: "",
          zelfEvaluatie: "",
          beschrijving: "",
          feedbackCoach: "",
          extraOefening: "",
          naam: "",
          datum: "",
          schema: "",
          type: "",
        });
        navigate("/homegebruiker");
      } else {
        const errorData = await response.json();
        console.error("Fout bij opslaan:", errorData);
        alert("Er is iets misgegaan bij het opslaan van de training.");
      }
    } catch (error) {
      console.error("Error tijdens opslaan:", error);
      alert("Er is een fout opgetreden tijdens het opslaan.");
    }
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col items-center p-4">
      <div className="bg-teal-700 text-white text-center py-4 px-6 w-full max-w-4xl rounded-t-md">
        <h1 className="text-xl font-bold">Nieuwe Training Toevoegen</h1>
      </div>

      <div className="bg-white shadow-lg p-6 grid grid-cols-4 gap-4 w-full max-w-4xl rounded-b-md mt-4">
        <div className="col-span-1">
          <h2 className="font-bold text-teal-700">Naam</h2>
          <input
            type="text"
            name="naam"
            value={formData.naam}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
            placeholder="Vul in"
          />
        </div>

        <div className="col-span-1">
          <h2 className="font-bold text-teal-700">Datum</h2>
          <input
            type="date"
            name="datum"
            value={formData.datum}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
          />
        </div>

        <div className="col-span-1">
          <h2 className="font-bold text-teal-700">Schema</h2>
          <select
            name="schema"
            value={formData.schema}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
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
        </div>

        <div className="col-span-1">
          <h2 className="font-bold text-teal-700">Type</h2>
          <select
            name="type"
            value={formData.type}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
          >
            <option value="" disabled>
              -- Kies een type --
            </option>
            <option value="Recuperatie">Recuperatie</option>
            <option value="LSD">LSD</option>
            <option value="EXT">EXT</option>
            <option value="Interval">Interval</option>
            <option value="Weerstand">Weerstand</option>
          </select>
        </div>

        <div className="col-span-4">
          <h2 className="font-bold text-teal-700">Beschrijving</h2>
          <textarea
            name="beschrijving"
            value={formData.beschrijving}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
            placeholder="Geef een beschrijving van de training"
          />
        </div>

        <div className="col-span-4">
          <button
            onClick={handleSave}
            className="bg-teal-700 text-white font-bold py-2 px-6 mt-4 rounded hover:bg-teal-800"
          >
            Opslaan
          </button>
        </div>
      </div>
    </div>
  );
};

export default NewTrainingPage;
