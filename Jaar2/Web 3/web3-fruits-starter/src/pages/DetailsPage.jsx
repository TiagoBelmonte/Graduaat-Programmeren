import React, { useEffect } from "react";
import { useParams } from "react-router-dom";

import fruits from "../utils/fruits.json";

const DetailsPage = () => {
  // TODO:  Haal de id uit het pad met de useParams hook

  // TODO:  Vind het corresporende fruit met deze id. TIP: find methode. Steek dit in een fruit variabele.

  // TODO:  Als het fruit niet bestaat, geef dan een paragraaf terug met fruit niet gevonden

  // TODO:  Pas ook de titel van het document aan met de naam van het fruit - enkel en alleen als je de fruitsoort gevonden hebt met de id.
  //        Opgelet dit moet niet bij elke rerender gebeuren natuurlijk. TIP: document.title = "..."

  return (
    <div className="w-full p-4">
      <img
        className="w-full object-contain max-h-96"
        // TODO:  Vul het src attribuut in met de img property van het fruit object dat je gevonden hebt
      ></img>
      <hr className="my-4"></hr>
      <h1 className="text-4xl font-extrabold text-food-red text-center">
        {/* TODO: Vul de naam van het fruit in */}
      </h1>

      <table>
        <thead>
          <tr>
            <th colSpan={2} className="text-right">
              / 100g
            </th>
          </tr>
        </thead>
        <tbody>
          {/* TODO: Vul de tabel verder aan met de nutritions property van het fruit object
                  Je moet dus voor elk nutrition element een <tr> element hebben met twee <td> elementen 
                  Met het eerste td element de naam van de nutrition, en het tweede td element met de value (Zie screenshot)
                  OPGELET: NIET hardcoden
                  PRO TIP: Je kan gebruik maken van de Object.keys methode om alle keys te tonen en dan de corresponderende values te tonen          
        */}
        </tbody>
      </table>
    </div>
  );
};

export default DetailsPage;
