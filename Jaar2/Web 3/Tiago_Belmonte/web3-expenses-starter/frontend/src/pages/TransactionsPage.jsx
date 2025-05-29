import Axios from "axios";
import { React, useState, useEffect } from "react";
import TitleLabel from "../components/TitleLabel";
import { MdAdd } from "react-icons/md";
import { useNavigate } from "react-router-dom";
import api from "../api/transactions";
import TransactionItem from "../components/TransactionItem";

const TransactionsPage = () => {
  // TODO: Maak een transactions state aan - initieël lege array
  const [transactions, settransactions] = useState([]);

  // TODO: Gebruik de correct hook om te kunnen navigeren in deze component
  const navigate = useNavigate();

  // TODO:  Gebruik de getAllTransactions methode en steek dit in de juiste structuur zodanig dat deze code enkel uitvoert bij het mounten van de component
  //        Steek het resultaat van de getAllTransactions in de transactions state - TIP Axios response
  //        Vergeet geen foutenafhandeling toe te passen - dit mag in de console gelogd worden

  useEffect(() => {
    (async () => {
      try {
        const response = await Axios.get(api.getAllTransactions);
        settransactions(response.data);
      } catch (error) {
        console.error(error);
      }
    })();
  }, []);

  return (
    <div>
      <div className="flex justify-between items-center gap-4">
        <TitleLabel>Transacties</TitleLabel>
        <button
          className="text-2xl rounded-full bg-teal-500 hover:bg-teal-600 p-4"
          onClick={() =>
            // TODO: Navigeer met de methode uit de hook naar het "/add" pad
            navigate("/add")
          }
        >
          <MdAdd />
        </button>
      </div>
      {/* TODO: Als de transactions leeg zijn toon dan de volgende paragraaf
          <p className="text-center uppercase font-thin">
            Geen transacties gevonden
          </p>
        */}
      if(transactions == null)
      {
        <p className="text-center uppercase font-thin">
          Geen transacties gevonden
        </p>
      }
      {/* TODO: Voor elk transaction object in de transactions array toon je de TransactionItem component
      en geef je het transaction object mee als props */}
      {transactions.map((t) => (
        <option key={t.id} value={t.id}>
          <TransactionItem t />
        </option>
      ))}
    </div>
  );
};

export default TransactionsPage;
