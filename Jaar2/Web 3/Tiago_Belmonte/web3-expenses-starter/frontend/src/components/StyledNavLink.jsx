import React from "react";
import { NavLink } from "react-router-dom";

const StyledNavLink = (props) => {
  return (
    <NavLink
      {...props}
      className={({ isActive }) =>
        `flex items-center gap-4 p-3 text-gray-200 font-light text-lg ${
          isActive ? "bg-zinc-800 rounded-md text-teal-300 font-semibold" : ""
        }`
      }>
      {props.icon}
      <p>{props.label}</p>
    </NavLink>
  );
};

export default StyledNavLink;
