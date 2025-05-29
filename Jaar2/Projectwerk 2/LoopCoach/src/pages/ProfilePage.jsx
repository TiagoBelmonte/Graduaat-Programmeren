import { useLocation, useNavigate } from "react-router-dom";
import { useState, useEffect } from "react";

const ProfilePage = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const { user } = location.state || {};
  const [lactaatTests, setLactaatTests] = useState([]);
  const [formData, setFormData] = useState({
    naam: user?.naam || "",
    email: user?.email || "",
    gewicht: user?.gewicht || "",
    lengte: user?.lengte || "",
    recuperatie: user?.recuperatie || "",
    LSD: user?.lsd || "",
    EXT: user?.ext || "",
    Interval: user?.interval || "",
    Weerstand: user?.weerstand || "",
  });

  useEffect(() => {
    if (user?.id) {
      fetch(
        `https://localhost:7119/LactaattestOpzoekenViaGebruikerId/${user.id}`
      )
        .then((response) => response.json())
        .then((data) => setLactaatTests(data))
        .catch((error) =>
          console.error("Fout bij ophalen lactaattests:", error)
        );
    }
  }, [user]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleLactaatChange = (index, field, value) => {
    setLactaatTests((prev) => {
      const updatedTests = [...prev];
      if (!updatedTests[index]) {
        // Voeg een nieuw leeg object toe als het niet bestaat
        updatedTests[index] = {};
      }
      updatedTests[index][field] = value;
      return updatedTests;
    });
  };

  const handleSave = async () => {
    try {
      // PATCH: Persoonlijke gegevens
      await fetch(`https://localhost:7119/SportieveInfoAanpassen/${user.id}`, {
        method: "PATCH",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(formData),
      });

      // POST: Lactaattesten
      const lactaatData = lactaatTests.map((test) => ({
        gebruikerId: user.id,
        tijd: test.tijd || 0,
        helling: test.helling || 0,
        snelheid: test.snelheid || 0,
        hartslag: test.hartslag || 0,
        lactaat: test.lactaat || 0,
        rPE: test.rPE || 0,
      }));

      await fetch("https://localhost:7119/LactaattestenToevoegen", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(lactaatData),
      });

      alert("Gegevens succesvol opgeslagen!");
      navigate(-1); // Navigeer terug naar de vorige pagina
    } catch (error) {
      console.error("Fout bij het opslaan:", error);
      alert("Er is een fout opgetreden bij het opslaan.");
    }
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col items-center p-4">
      <div className="bg-teal-700 text-white text-center py-4 px-6 w-full max-w-4xl rounded-t-md">
        <h1 className="text-xl font-bold">Persoonlijke gegevens</h1>
      </div>

      <div className="bg-white shadow-lg p-6 grid grid-cols-4 gap-4 w-full max-w-4xl rounded-b-md mt-4">
        {[
          { label: "Naam", name: "naam", value: formData.naam },
          { label: "Email", name: "email", value: formData.email },
          {
            label: "Oud wachtwoord",
            name: "nieuw wachtwoord",
          },
          {
            label: "Nieuw wachtwoord",
            name: "nieuw wachtwoord",
          },
          {
            label: "Bevestiging wachtwoord",
            name: "nieuw wachtwoord",
          },
        ].map(({ label, name, value }) => (
          <div key={name} className="col-span-1">
            <h2 className="font-bold text-teal-700">{label}</h2>
            <input
              type="text"
              name={name}
              value={value}
              onChange={handleChange}
              className="border border-teal-700 rounded p-2 w-full"
              placeholder="Vul in"
            />
          </div>
        ))}
      </div>

      <div className="bg-teal-700 text-white text-center mt-4 py-4 px-6 w-full max-w-4xl rounded-t-md">
        <h1 className="text-xl font-bold">Sportieve gegevens</h1>
      </div>

      <div className="bg-white shadow-lg p-6 grid grid-cols-4 gap-4 w-full max-w-4xl rounded-b-md mt-4">
        {[
          {
            label: "Recuperatie",
            name: "recuperatie",
            value: formData.recuperatie,
          },
          { label: "LSD", name: "LSD", value: formData.LSD },
          { label: "EXT", name: "EXT", value: formData.EXT },
          { label: "Interval", name: "Interval", value: formData.Interval },
          { label: "Weerstand", name: "Weerstand", value: formData.Weerstand },
        ].map(({ label, name, value }) => (
          <div key={name} className="col-span-1">
            <h2 className="font-bold text-teal-700">{label}</h2>
            <input
              type="text"
              name={name}
              value={value}
              onChange={handleChange}
              className="border border-teal-700 rounded p-2 w-full"
              placeholder="Vul in"
            />
          </div>
        ))}
      </div>

      <div className="bg-white shadow-lg p-6 w-full max-w-4xl rounded-md mt-6">
        <h2 className="text-lg font-bold text-teal-700 mb-4">Lactaattests</h2>
        <table className="w-full border-collapse border border-gray-300">
          <thead className="bg-teal-700 text-white">
            <tr>
              {[
                "Tijd",
                "Helling",
                "Snelheid",
                "Hartslag",
                "Lactaat",
                "RPE",
              ].map((header) => (
                <th key={header} className="border border-gray-300 px-4 py-2">
                  {header}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {Array.from({ length: 5 }).map((_, index) => (
              <tr key={index} className="even:bg-gray-100">
                {[
                  "tijd",
                  "helling",
                  "snelheid",
                  "hartslag",
                  "lactaat",
                  "rPE",
                ].map((field) => (
                  <td key={field} className="border border-gray-300 px-4 py-2">
                    <input
                      type="text"
                      value={
                        (lactaatTests[index] && lactaatTests[index][field]) ||
                        ""
                      }
                      onChange={(e) =>
                        handleLactaatChange(index, field, e.target.value)
                      }
                      className="border border-gray-300 rounded w-full p-2"
                      placeholder={field}
                    />
                  </td>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
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

export default ProfilePage;
