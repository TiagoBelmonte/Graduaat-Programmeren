import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

const HomeTrainer = () => {
  const [users, setUsers] = useState([]);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const fetchUsers = async () => {
    try {
      const response = await fetch("https://localhost:7119/LijstGebruikers");
      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`);
      }
      const data = await response.json();
      setUsers(data);
    } catch (error) {
      console.error("Fout bij het ophalen van gebruikers:", error);
      setError(error.message);
    }
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  const handleUserClick = (user) => {
    navigate(`/homegebruikertrainer`, { state: { user } }); // Navigeer met de volledige user-object
  };

  return (
    <div className="min-h-screen bg-gray-100 flex flex-col items-center p-6">
      <h1 className="text-2xl font-bold text-teal-700 mb-4">Welkom</h1>
      {error && <p className="text-red-500">{error}</p>}
      <div className="grid grid-cols-3 gap-4 w-full max-w-4xl">
        {users.map((user) => (
          <div
            key={user.id}
            onClick={() => handleUserClick(user)} // Klikbare actie
            className="cursor-pointer p-4 bg-teal-500 text-white text-center rounded shadow-lg hover:bg-teal-700"
          >
            <p className="font-bold">{user.naam}</p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default HomeTrainer;
