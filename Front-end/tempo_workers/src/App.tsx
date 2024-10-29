import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import LoginPage from "./pages/loginPage/LoginPage";
import MainAdminPage from "./pages/mainAdminPage/MainAdminPage";

const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
      </Routes>
      <Routes>
        <Route path="/AdminPage" element={<MainAdminPage />} />
      </Routes>
    </BrowserRouter>
  );
};

export default App;
