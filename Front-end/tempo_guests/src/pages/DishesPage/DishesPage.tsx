import React, { useEffect } from "react";
import "./DishesPage.scss";
import { Button, Container } from "@mui/material";
import Header from "../../modules/header/Header";
import Footer from "../../modules/footer/Footer";
import { useGlobalStore } from "../../shared/state/globalStore";
import CategoryModule from "../../modules/CategoryModule/CategoryModule";
import { useNavigate } from "react-router-dom";

const DishesPage = () => {
  const { menu, fetchMenu } = useGlobalStore();
  const navigate = useNavigate();

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
          <Button
            id="button"
            variant="contained"
            onClick={() => {
              navigate("/cart");
            }}
          >
            Перейти в корзину
          </Button>
        </div>
      </div>
      <Footer />
    </Container>
  );
};

export default DishesPage;
