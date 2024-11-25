import React, { useState } from "react";

const AddParkingsPage = () => {
  const [name, setName] = useState("");
  const [age, setAge] = useState("");

  return (
    <div>
      <form action="http://localhost:3000" method="GET">
        <label htmlFor="firstName">Naam:</label>
        <input
          id="firstName"
          className="px-4 py-2 border rounded-md block"
          type="text"
          placeholder="Naam"
          required
          name="name"
          value={name}
          onChange={(event) => {
            setName(event.target.value);
          }}
        />
        <input
          name="age"
          className="px-4 py-2 border rounded-md block"
          type="number"
          placeholder="Leeftijd"
          value={age}
          onChange={(event) => {
            setAge(event.target.value);
          }}
        />
        <button type="submit">Verstuur</button>
      </form>
    </div>
  );
};

export default AddParkingsPage;
