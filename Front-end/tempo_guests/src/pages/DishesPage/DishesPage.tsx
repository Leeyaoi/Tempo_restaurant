import React, { useEffect } from "react";
import "./DishesPage.scss";
import { Container } from "@mui/material";
import Header from "../../modules/header/Header";
import Footer from "../../modules/footer/Footer";
import { useGlobalStore } from "../../shared/state/globalStore";
import CategoryModule from "../../modules/CategoryModule/CategoryModule";

const DishesPage = () => {
  const { menu, fetchMenu } = useGlobalStore();

  useEffect(() => {
    fetchMenu();
  }, []);

  return (
    <Container className="Container">
      <Header />
      <div id="content">
        <div id="menu">
          {menu.map((category, i) => {
            return <CategoryModule key={i} category={category} />;
          })}
        </div>
      </div>
      <Footer />
    </Container>
  );
};

export default DishesPage;
