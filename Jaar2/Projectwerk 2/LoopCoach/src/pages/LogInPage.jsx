import React, { useState } from "react";
import { useNavigate } from "react-router-dom"; // Voor navigatie
import Button from "../components/Button";

const LogInPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState(null);
  const navigate = useNavigate(); // Navigatiehook van react-router-dom

  const handleSubmit = async (e) => {
    e.preventDefault(); // Voorkomt pagina herladen
    try {
      const response = await fetch(
        `https://localhost:7119/api/Login?email=${email}&wachtwoord=${password}`,
        {
          method: "GET",
        }
      );

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }

      const data = await response.json();
      console.log("Login succesvol:", data);

      // Sla de gegevens op in sessionStorage
      sessionStorage.setItem("userData", JSON.stringify(data));

      // Beslissen waar de gebruiker heen gaat op basis van de respons
      if (data.trainer == null) {
        navigate("/hometrainer"); // trainer
      } else {
        navigate("/homegebruiker"); // Gebruikersvenster
      }
    } catch (error) {
      console.error("Fout bij het inloggen:", error);
      setError("Login mislukt. Controleer je gegevens.");
    }
  };

  return (
    <div className="flex items-center justify-center h-screen overflow-hidden bg-cyan-500">
      <div className="bg-cyan-700 p-6 rounded shadow">
        <form className="space-y-4" onSubmit={handleSubmit}>
          <input
            id="email"
            className="px-4 py-2 border rounded-md w-full"
            type="text"
            placeholder="e-mail"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
          <input
            name="Password"
            className="px-4 py-2 border rounded-md w-full"
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
          {error && <p className="text-red-500">{error}</p>}
          <Button>Verstuur</Button>
        </form>
      </div>
    </div>
  );
};

export default LogInPage;
