import React from "react";

const StyledButton = (props) => {
  return (
    <button
      className="px-4 py-2 bg-teal-500 hover:bg-teal-600 rounded-lg font-bold uppercase w-full my-4"
      onClick={
        // TODO: Geef de onClick mee vanuit de props
        props.onClick
      }
    >
      {/* TODO: Zorg ervoor dat de kind components vanuit de props hier getoond worden - VERGEET niet de props binnen te krijgen */}
      {props.children}
    </button>
  );
};

export default StyledButton;
