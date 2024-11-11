import { useEffect, useState, useRef, useContext } from "react";
import Button from "./Button.jsx";
import { DarkModeContext, useDarkMode } from "../contexts/DarkmodeContext.jsx";

const Counter = () => {
  const [waarde, setWaarde] = useState(0);
  const [history, sethistory] = useState([]);

  //Gebruik maken van de context
  //const darkModeObj = useContext(DarkModeContext);

  //gebruik maken van onze eigen hook
  const darkModeObj = useDarkMode();

  //Referentie aan een JSX element
  //stap 1: Nieuwe instantie referentie
  const inputRef = useRef();

  const PlusClick = () => {
    setWaarde(waarde + 1);
  };
  const MinClick = () => {
    setWaarde(waarde - 1);
  };
  const WaardeOpslaan = () => {
    sethistory([...history, waarde]);
  };

  console.log("Counter component is gerenderd!");

  //useEffect

  useEffect(() => {
    console.log("useEffect Type 1");
  });

  useEffect(() => {
    console.log("useEffect Type 2");
    inputRef.current.focus();
  }, []);

  useEffect(() => {
    console.log("useEffect Type 3");
  }, [history]);

  useEffect(() => {
    const timerId = setInterval(() => {
      console.log("Om de 2sec uitgevoerd");
      setWaarde(waarde + 1);
    }, 2000);

    // Cleanup van onze useEffect
    return () => {
      clearInterval(timerId);
    };
  }, [waarde]);

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

      <div>
        <p>Text input</p>
        <input ref={inputRef} type="test" placeholder="Vak" />
      </div>

      {darkModeObj.isDarkMode ? <p>Ja</p> : <p>Neen</p>}
    </>
  );
};

export default Counter;
