import React from "react";

const TitleLabel = (props) => {
  return (
    <h3 className="text-gray-300 text-sm font-thin my-2">
      {/* TODO: Zorg ervoor dat de kind components vanuit de props hier getoond worden - VERGEET niet de props binnen te krijgen */}
      {props.children}
    </h3>
  );
};

export default TitleLabel;
