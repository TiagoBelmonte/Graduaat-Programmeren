import React from "react";

import ProfilePic from "../assets/images/profile.webp";
import Logo from "../assets/images/logo.png";
import StyledNavLink from "./StyledNavLink";
import useAuth from "../contexts/AuthContextProvider";

import {
  MdOutlineCategory,
  MdOutlineCreditCard,
  MdOutlinePerson,
} from "react-icons/md";

const SideNav = () => {
  // TODO: Haal de user uit de useAuth hook
  const { user } = useAuth();
  return (
    <div className="flex-grow text-gray-300 px-2 text-cente h-full relative">
      <div className="flex flex-col gap-4">
        <img src={ProfilePic} className="rounded-full w-20 mx-auto" />
        <p className="text-xl font-bold text-center">
          {
            // TODO: Toon hier de name van het user object
            user.name
          }
        </p>
      </div>

      <div className="flex flex-col gap-4 my-16">
        <StyledNavLink
          to="/"
          icon={<MdOutlineCreditCard />}
          label="Transacties"
        />
        <StyledNavLink
          to="/categories"
          icon={<MdOutlineCategory />}
          label="Categorieën"
        />
        <StyledNavLink
          to="/profile"
          icon={<MdOutlinePerson />}
          label="Profiel"
        />
      </div>

      <img src={Logo} className="rounded-lg w-24 absolute bottom-2" />
    </div>
  );
};

export default SideNav;
