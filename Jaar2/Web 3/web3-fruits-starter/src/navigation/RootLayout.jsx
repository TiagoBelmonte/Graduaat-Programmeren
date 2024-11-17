import { Outlet } from "react-router-dom";
import Header from "../components/Header";

const RootLayout = () => {
  return (
    <div className="flex flex-col min-h-screen">
      <Header />
      <div className="flex flex-grow">
        {/* TODO: Niets vergeten??? */}
        <Outlet />
      </div>
    </div>
  );
};

export default RootLayout;
