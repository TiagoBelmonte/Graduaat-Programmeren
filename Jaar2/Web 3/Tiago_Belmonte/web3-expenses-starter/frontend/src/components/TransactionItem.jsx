import React from "react";

const TransactionItem = (props) => {
  // TODO: Haal de transaction uit de props
  const transaction = props.children;
  return (
    <div
      className={`${
        // TODO: Als de transaction type gelijk is aan EXPENSE geef dan volgende kleurcode terug "bg-red-500" en anders "bg-green-500"
        transaction.type == "EXPENSE" ? "bg-red-500" : "bg-green-500"
      } p-4 my-4 rounded-lg flex justify-between items-center`}
    >
      <div className="flex gap-4 items-center">
        <p className="text-white">
          {new Date(
            // TODO: Toon hier de date vanuit het transaction object
            transaction.date
          ).toLocaleDateString()}
        </p>
        <p className="font-bold text-xl">
          {" "}
          {
            // TODO: Toon hier de description vanuit het transaction object
            transaction.descrioption
          }
        </p>
      </div>
      <div>
        <p className="font-bold text-xl text-right">
          {
            // TODO: Toon hier de amount vanuit het transaction object
            (transaction.amount / 100).toFixed(2).replace(".", ",")
          }{" "}
          &euro;
        </p>
        <p className="text-right text-sm font-thin">
          {
            // TODO: Toon hier de name van de category vanuit het transaction object
            transaction.name
          }
        </p>
      </div>
    </div>
  );
};

export default TransactionItem;
