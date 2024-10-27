import React from "react";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import LoginPage from "./pages/loginPage/LoginPage";
import DishesPage from "./pages/DishesPage/DishesPage";

const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/dishes" element={<DishesPage />} />
      </Routes>
    </BrowserRouter>
  );
};

export default App;
