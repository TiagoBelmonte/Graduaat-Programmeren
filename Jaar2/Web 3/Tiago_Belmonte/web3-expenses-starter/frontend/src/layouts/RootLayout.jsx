import React from "react";
import SideNav from "../components/SideNav";
import { Outlet } from "react-router-dom";

const RootLayout = () => {
  return (
    <div className="h-screen flex bg-zinc-900 p-8">
      <div className="flex-shrink w-1/5">
        <SideNav />
      </div>

      <div className="flex-grow bg-zinc-950 rounded-3xl p-8 overflow-y-scroll">
        {/* TODO: Zorg ervoor dat het navigeren hier lukt met een bepaalde component die je moet gebruiken om dynamisch de pagina's te kunnen tonen */}
        <Outlet />
      </div>
    </div>
  );
};

export default RootLayout;
