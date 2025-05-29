import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";

const TrainingPage = () => {
  const location = useLocation(); // Haal de locatie op
  const { trainingId } = location.state || {}; // Haal de trainingId uit de state
  console.log(trainingId);

  const [trainingData, setTrainingData] = useState(null);
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
  });

  // Handler voor wijzigingen in de invoervelden
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  // Opslaan functionaliteit
  const handleSave = () => {
    console.log("Opgeslagen gegevens:", formData);
    alert("Gegevens succesvol opgeslagen!");
  };

  useEffect(() => {
    if (trainingId) {
      // Haal de training details op met de trainingId
      const fetchTrainingData = async () => {
        try {
          const response = await fetch(
            `https://localhost:7119/TrainingenOpvragenViaTrainingId/${trainingId}`
          );
          const data = await response.json();
          setTrainingData(data);

          // Vul de formData met de gegevens van de training
          setFormData({
            typeTraining: data.type || "",
            gemHartslag: data.gemiddeldeHartslag || "",
            afstand: data.afstand || "",
            persoonlijkeScore: data.score || "",
            duur: data.duur || "",
            zelfEvaluatie: data.zelfEvalutie || "",
            beschrijving: data.feedback || "",
            feedbackCoach: data.feedback || "", // Dit veld is bewerkbaar
            extraOefening: data.externeLink || "",
          });
        } catch (error) {
          console.error("Error fetching training data:", error);
        }
      };

      fetchTrainingData();
    }
  }, [trainingId]);

  if (!trainingData) {
    return <div>Loading training data...</div>;
  }
  console.log(trainingData);

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col items-center p-4">
      {/* Titel sectie */}
      <div className="bg-teal-700 text-white text-center py-4 px-6 w-full max-w-4xl rounded-t-md">
      <h1 className="text-xl font-bold">
        {`${trainingData.naam} : ${(() => {
          const date = new Date(trainingData.datum);
          date.setDate(date.getDate() - 1);
          return date.toLocaleDateString();
        })()}`}
      </h1>
      </div>

      {/* Inhoud sectie */}
      <div className="bg-white shadow-lg p-6 grid grid-cols-4 gap-4 w-full max-w-4xl rounded-b-md mt-4">
        {/* Typetraining */}
        <div className="col-span-1">
          <h2 className="font-bold text-teal-700">Typetraining</h2>
          <input
            type="text"
            name="typeTraining"
            value={formData.typeTraining}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
            placeholder="Vul in"
          />
        </div>
        {/* Gemiddelde hartslag */}
        <div className="col-span-1">
          <h2 className="font-bold text-teal-700">Gemhartslag</h2>
          <input
            type="text"
            name="gemHartslag"
            value={formData.gemHartslag}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
            placeholder="Vul in"
          />
        </div>
        {/* Afstand */}
        <div className="col-span-1">
          <h2 className="font-bold text-teal-700">Afstand</h2>
          <input
            type="text"
            name="afstand"
            value={formData.afstand}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
            placeholder="Vul in"
          />
        </div>
        {/* Persoonlijke score */}
        <div className="col-span-1">
          <h2 className="font-bold text-teal-700">Persoonlijke score</h2>
          <input
            type="text"
            name="persoonlijkeScore"
            value={formData.persoonlijkeScore}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
            placeholder="Vul in"
          />
        </div>
        {/* Duur */}
        <div className="col-span-1">
          <h2 className="font-bold text-teal-700">Duur</h2>
          <input
            type="text"
            name="duur"
            value={formData.duur}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
            placeholder="Vul in"
          />
        </div>
        {/* Zelfevaluatie */}
        <div className="col-span-1">
          <h2 className="font-bold text-teal-700">Zelf evaluatie</h2>
          <input
            type="text"
            name="zelfEvaluatie"
            value={formData.zelfEvaluatie}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
            placeholder="Vul in"
          />
        </div>
        {/* Beschrijving */}
        <div className="col-span-2">
          <h2 className="font-bold text-teal-700">Beschrijving</h2>
          <textarea
            name="beschrijving"
            value={formData.beschrijving}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
            placeholder="Vul in"
          />
        </div>
        {/* Feedback coach */}
        <div className="col-span-4">
          <h2 className="font-bold text-teal-700">Feedback coach</h2>
          <textarea
            name="feedbackCoach"
            value={formData.feedbackCoach}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
            placeholder="Vul in"
          />
        </div>
        {/* Extra oefening */}
        <div className="col-span-4">
          <h2 className="font-bold text-teal-700">Link naar Strava/Garmin</h2>
          <textarea
            name="LinkStrava/Garmin"
            value={formData.extraOefening}
            onChange={handleChange}
            className="border border-teal-700 rounded p-2 w-full"
            placeholder="Vul in"
          />
        </div>
      </div>

      {/* Opslaan knop */}
      <button
        onClick={handleSave}
        className="bg-teal-700 text-white font-bold py-2 px-6 mt-4 rounded hover:bg-teal-800"
      >
        Opslaan
      </button>
    </div>
  );
};

export default TrainingPage;
