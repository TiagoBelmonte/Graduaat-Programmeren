import React from "react";

const Button = ({ eventclick, children, ...props }) => {
  return (
    <button
      className="px-4 py-2 bg-white hover:bg-cyan-500 rounded-lg text-black"
      onClick={eventclick}
      {...props}
    >
      {children}
    </button>
  );
};

export default Button;
