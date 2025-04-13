import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import LoginPage from "./pages/loginPage/LoginPage";
import MainAdminPage from "./pages/mainAdminPage/MainAdminPage";
import MainWaiterPage from "./pages/mainWaiterPage/MainWaiterPage";
import Header from "./modules/header/Header";
import Footer from "./modules/footer/Footer";

const App = () => {
  return (
    <div className="Container">
      <Header />
      <BrowserRouter>
        <Routes>
          <Route path="/login" element={<LoginPage />} />
        </Routes>
        <Routes>
          <Route path="/AdminPage" element={<MainAdminPage />} />
        </Routes>
        <Routes>
          <Route path="/WaiterPage" element={<MainWaiterPage />} />
        </Routes>
      </BrowserRouter>
      <Footer />
    </div>
  );
};

export default App;
