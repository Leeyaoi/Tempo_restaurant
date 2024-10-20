import { Button, Container, TextField } from "@mui/material";
import { MuiTelInput } from "mui-tel-input";
import React from "react";
import "./loginPage.scss";
import Header from "../../modules/header/Header";
import Footer from "../../modules/footer/Footer";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../../shared/types/RESTMethodEnum";

const LoginPage = () => {
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
                HttpRequest({
                  uri: "/user",
                  method: RESTMethod.Post,
                  item: { name: name, phone: phone },
                });
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
              HttpRequest({
                uri: "/user",
                method: RESTMethod.Post,
                item: { name: "guest", phone: "guest" },
              });
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
