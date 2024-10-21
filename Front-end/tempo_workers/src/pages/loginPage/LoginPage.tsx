import { Button, Container, TextField } from "@mui/material";
import React from "react";
import "./loginPage.scss";
import Header from "../../modules/header/Header";
import Footer from "../../modules/footer/Footer";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../../shared/types/RESTMethodEnum";

const LoginPage = () => {
  const [login, setLogin] = React.useState("");
  const [password, setPassword] = React.useState("");

  const handleLoginChange = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    setLogin(event.target.value);
  };

  const handlePasswordChange = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    setPassword(event.target.value);
  };

  return (
    <Container className="Container">
      <Header />
      <div id="content">
        <div id="login-form">
          <TextField
            className="text-input"
            id="login-input"
            label="Логин"
            variant="outlined"
            value={login}
            onChange={handleLoginChange}
          />
          <TextField
            className="text-input"
            id="password-input"
            label="Пароль"
            type="password"
            variant="outlined"
            value={password}
            onChange={handlePasswordChange}
          />
          <Button
            variant="contained"
            id="button"
            onClick={(event) => {
              event.preventDefault();
              if (login !== "" && password !== "") {
                HttpRequest({
                  uri: "/user",
                  method: RESTMethod.Post,
                  item: { login: login, password: password },
                });
              }
            }}
          >
            Войти
          </Button>
        </div>
      </div>
      <Footer />
    </Container>
  );
};

export default LoginPage;

// import { Button, Container, TextField } from "@mui/material";
// import { MuiTelInput } from "mui-tel-input";
// import React from "react";
// import "./loginPage.scss";
// import Header from "../../modules/header/Header";
// import Footer from "../../modules/footer/Footer";
// import { HttpRequest } from "../../api/GenericApi";
// import { RESTMethod } from "../../shared/types/RESTMethodEnum";

// const LoginPage = () => {
//   const [login, setPhone] = React.useState("");//phone = login
//   const [name, setName] = React.useState("");//name = password

//   const handleLoginChange = (
//     event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
//   ) => {
//     setLogin(event.target.value);
//   };

//   const handleNameChange = (
//     event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
//   ) => {
//     setName(event.target.value);
//   };

//   return (
//     <Container className="Container">
//       <Header />
//       <div id="content">
//         <div id="login-form">
//           <TextField
//             className="text-input"
//             id="name-input"
//             label="Имя"
//             variant="outlined"
//             value={name}
//             onChange={handleNameChange}
//           />
//           <MuiTelInput
//             className="text-input"
//             id="phone-input"
//             label="Номер телефона"
//             defaultCountry="BY"
//             value={phone}
//             onChange={handlePhoneChange}
//           />
//           <Button
//             variant="contained"
//             id="button"
//             onClick={(event) => {
//               event.preventDefault();
//               if (phone != "" && name != "") {
//                 HttpRequest({
//                   uri: "/user",
//                   method: RESTMethod.Post,
//                   item: { name: name, phone: phone },
//                 });
//               }
//             }}
//           >
//             Войти
//           </Button>
//         </div>
//       </div>
//       <Footer />
//     </Container>
//   );
// };

// export default LoginPage;
