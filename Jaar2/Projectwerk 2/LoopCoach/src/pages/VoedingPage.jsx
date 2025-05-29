import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";

const VoedingPage = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const voedingId = location.state?.voedingId;

  const [formData, setFormData] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);

  // Fetch data bij component mount
  useEffect(() => {
    if (!voedingId) {
      setError("Geen voedingId gevonden.");
      setIsLoading(false);
      return;
    }

    const fetchVoeding = async () => {
      try {
        const response = await fetch(
          `https://localhost:7119/VoedingViaId/${voedingId}`
        );
        if (!response.ok) {
          throw new Error("Fout bij ophalen van de voeding.");
        }
        const data = await response.json();
        setFormData(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setIsLoading(false);
      }
    };

    fetchVoeding();
  }, [voedingId]);

  // Handler voor "Home" knop
  const handleHome = () => {
    navigate(-1); // Navigeer naar de vorige pagina
  };

  if (isLoading) {
    return <div className="text-center">Gegevens laden...</div>;
  }

  if (error) {
    return <div className="text-center text-red-500">{error}</div>;
  }

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col items-center p-4">
      {/* Titel sectie */}
      <div className="bg-teal-700 text-white text-center py-4 px-6 w-full max-w-4xl rounded-t-md">
        <h1 className="text-xl font-bold">
          Dieet : {formData.datum || "Onbekend"}
        </h1>
      </div>

      {/* Inhoud sectie */}
      <div className="bg-white shadow-lg p-6 grid grid-cols-2 gap-4 w-full max-w-4xl rounded-b-md mt-4">
        {/* Ontbijt sectie */}
        <div className="flex flex-col">
          <h2 className="font-bold text-teal-700">Ontbijt</h2>
          <input
            type="text"
            value={formData.ontbijt || ""}
            className="border border-teal-700 rounded p-2 w-full bg-gray-100"
            readOnly
          />
        </div>
        <div className="flex flex-col">
          <h2 className="font-bold text-teal-700">Extra info ontbijt</h2>
          <input
            type="text"
            value={formData.infoOntbijt || ""}
            className="border border-teal-700 rounded p-2 w-full bg-gray-100"
            readOnly
          />
        </div>

        {/* Middag sectie */}
        <div className="flex flex-col">
          <h2 className="font-bold text-teal-700">Middag</h2>
          <input
            type="text"
            value={formData.middagmaal || ""}
            className="border border-teal-700 rounded p-2 w-full bg-gray-100"
            readOnly
          />
        </div>
        <div className="flex flex-col">
          <h2 className="font-bold text-teal-700">Extra info middag</h2>
          <input
            type="text"
            value={formData.infoMiddagmaal || ""}
            className="border border-teal-700 rounded p-2 w-full bg-gray-100"
            readOnly
          />
        </div>

        {/* Avond sectie */}
        <div className="flex flex-col">
          <h2 className="font-bold text-teal-700">Avond</h2>
          <input
            type="text"
            value={formData.avondmaal || ""}
            className="border border-teal-700 rounded p-2 w-full bg-gray-100"
            readOnly
          />
        </div>
        <div className="flex flex-col">
          <h2 className="font-bold text-teal-700">Extra info avond</h2>
          <input
            type="text"
            value={formData.infoAvondmaal || ""}
            className="border border-teal-700 rounded p-2 w-full bg-gray-100"
            readOnly
          />
        </div>

        {/* Snacks sectie */}
        <div className="flex flex-col">
          <h2 className="font-bold text-teal-700">Snacks</h2>
          <input
            type="text"
            value={formData.snacks || ""}
            className="border border-teal-700 rounded p-2 w-full bg-gray-100"
            readOnly
          />
        </div>
        <div className="flex flex-col">
          <h2 className="font-bold text-teal-700">Extra info snacks</h2>
          <input
            type="text"
            value={formData.infoSnacks || ""}
            className="border border-teal-700 rounded p-2 w-full bg-gray-100"
            readOnly
          />
        </div>
      </div>

      {/* Home knop */}
      <button
        onClick={handleHome}
        className="bg-teal-700 text-white font-bold py-2 px-6 mt-4 rounded hover:bg-teal-800"
      >
        Home
      </button>
    </div>
  );
};

export default VoedingPage;
