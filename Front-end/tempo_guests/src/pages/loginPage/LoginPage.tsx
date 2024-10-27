import { Button, Container, TextField } from "@mui/material";
import { MuiTelInput } from "mui-tel-input";
import React, { useEffect } from "react";
import "./loginPage.scss";
import Header from "../../modules/header/Header";
import Footer from "../../modules/footer/Footer";
import { useGlobalStore } from "../../shared/state/globalStore";
import UserType from "../../shared/types/user";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
  const { login, currentUser } = useGlobalStore();
  const navigate = useNavigate();

  useEffect(() => {
    if (currentUser !== null) {
      navigate("/dishes");
    }
  }, [currentUser]);

  const [phone, setPhone] = React.useState("");
  const [name, setName] = React.useState("");

  const handlePhoneChange = (newValue: string) => {
    setPhone(newValue);
  };

  const handleNameChange = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    setName(event.target.value);
  };

  return (
    <Container className="Container">
      <Header />
      <div id="content">
        <div id="login-form">
          <TextField
            className="text-input"
            id="name-input"
            label="Имя"
            variant="outlined"
            value={name}
            onChange={handleNameChange}
          />
          <MuiTelInput
            className="text-input"
            id="phone-input"
            label="Номер телефона"
            defaultCountry="BY"
            value={phone}
            onChange={handlePhoneChange}
          />
          <Button
            variant="contained"
            id="button"
            onClick={(event) => {
              event.preventDefault();
              if (phone != "" && name != "") {
                login({ name: name, phone: phone } as UserType);
              }
            }}
          >
            Войти
          </Button>
          <Button
            variant="contained"
            id="button"
            onClick={(event) => {
              event.preventDefault();
              login({ name: "Гость", phone: "Гость" } as UserType);
            }}
          >
            Войти как гость
          </Button>
        </div>
      </div>
      <Footer />
    </Container>
  );
};

export default LoginPage;
