import React from "react";
import { Link } from "react-router-dom";

import StyledNavLink from "./StyledNavLink";

const NavBar = () => {
  return (
    <nav className="bg-blue-800 text-white shadow-md">
      <div className="mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between h-16">
          <div className="flex-shrink-0 flex items-center">
            <Link to="/" className="text-2xl font-bold">
              WebExpenses
            </Link>
          </div>
          <div className="hidden md:flex md:items-center">
            <StyledNavLink to="/">Dashboard</StyledNavLink>
            <StyledNavLink to="/transactions">Transacties</StyledNavLink>
            <StyledNavLink to="/categories">Categorieën</StyledNavLink>
            <StyledNavLink to="/profile">Profiel</StyledNavLink>
          </div>
        </div>
      </div>
    </nav>
  );
};

export default NavBar;
