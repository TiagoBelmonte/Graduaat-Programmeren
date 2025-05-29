import React, { useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";

const NewVoedingPage = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const { userId } = location.state || {};

  // Hooks moeten bovenaan staan
  const [formData, setFormData] = useState({
    ontbijt: "",
    infoOntbijt: "",
    middagmaal: "",
    infoMiddagmaal: "",
    avondmaal: "",
    infoAvondmaal: "",
    snacks: "",
    infoSnacks: "",
  });

  // Als userId ontbreekt, toon een waarschuwing en keer terug
  if (!userId) {
    return (
      <div className="min-h-screen flex items-center justify-center">
        <div className="text-center">
          <p className="text-red-500 font-bold">User ID ontbreekt!</p>
          <button
            onClick={() => navigate(-1)}
            className="bg-teal-700 text-white font-bold py-2 px-6 mt-4 rounded hover:bg-teal-800"
          >
            Ga terug
          </button>
        </div>
      </div>
    );
  }

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSave = async () => {
    try {
      const response = await fetch(
        `https://localhost:7119/VoedingGebruikerToevoegen/${userId}`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(formData),
        }
      );

      if (response.ok) {
        alert("Voeding succesvol opgeslagen!");
        navigate(-1); // Navigeer naar de vorige pagina
      } else {
        const errorData = await response.json();
        console.error("Fout bij opslaan:", errorData);
        alert("Er is iets misgegaan bij het opslaan van de voeding.");
      }
    } catch (error) {
      console.error("Error tijdens opslaan:", error);
      alert("Er is een fout opgetreden tijdens het opslaan.");
    }
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col items-center p-4">
      <div className="bg-teal-700 text-white text-center py-4 px-6 w-full max-w-4xl rounded-t-md">
        <h1 className="text-xl font-bold">Nieuw dieet invullen</h1>
      </div>
      <div className="bg-white shadow-lg p-6 grid grid-cols-2 gap-4 w-full max-w-4xl rounded-b-md mt-4">
        {[
          "ontbijt",
          "infoOntbijt",
          "middagmaal",
          "infoMiddagmaal",
          "avondmaal",
          "infoAvondmaal",
          "snacks",
          "infoSnacks",
        ].map((field) => (
          <div className="flex flex-col" key={field}>
            <h2 className="font-bold text-teal-700">
              {field.charAt(0).toUpperCase() +
                field.slice(1).replace(/([A-Z])/g, " $1")}
            </h2>
            <input
              type="text"
              name={field}
              value={formData[field] || ""}
              onChange={handleChange}
              className="border border-teal-700 rounded p-2 w-full"
            />
          </div>
        ))}
      </div>
      <button
        onClick={handleSave}
        className="bg-teal-700 text-white font-bold py-2 px-6 mt-4 rounded hover:bg-teal-800"
      >
        Opslaan
      </button>
    </div>
  );
};

export default NewVoedingPage;
