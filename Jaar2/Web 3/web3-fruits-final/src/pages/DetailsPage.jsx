import React, { useEffect } from "react";
import { useParams } from "react-router-dom";

import fruits from "../utils/fruits.json";

const DetailsPage = () => {
  const { id } = useParams();

  const fruit = fruits.find((f) => f.id === Number.parseInt(id));

  useEffect(() => {
    if (fruit) {
      document.title = fruit.name;
    }
  }, [fruit]);

  if (fruit == null) {
    return <p>Fruit niet gevonden</p>;
  }

  return (
    <div className="w-full p-4">
      <img
        className="w-full object-contain max-h-96"
        src={`/images/${fruit.img}`}></img>
      <hr className="my-4"></hr>
      <h1 className="text-4xl font-extrabold text-food-red text-center">
        {fruit.name}
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
          {Object.keys(fruit.nutritions).map((n) => (
            <tr key={n}>
              <td className="">{n}</td>
              <td>{fruit.nutritions[n]}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default DetailsPage;
