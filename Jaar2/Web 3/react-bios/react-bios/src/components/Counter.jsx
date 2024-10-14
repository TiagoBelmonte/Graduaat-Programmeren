import { useState } from "react";
import Button from "./Button.jsx";

const Counter = () => {
  const [waarde, setWaarde] = useState(0);
  const [history, sethistory] = useState([]);
  const PlusClick = () => {
    setWaarde(waarde + 1);
  };
  const MinClick = () => {
    setWaarde(waarde - 1);
  };
  const WaardeOpslaan = () => {
    sethistory([...history, waarde]);
  };

  return (
    <>
      <p>{waarde}</p>
      <Button onClick={PlusClick}> + </Button>
      <Button onClick={MinClick}> - </Button>
      <Button onClick={WaardeOpslaan}> voeg toe</Button>

      <ul>
        {history.map((h, idx) => (
          <li key={idx}>{h}</li>
        ))}
      </ul>
    </>
  );
};

export default Counter;
