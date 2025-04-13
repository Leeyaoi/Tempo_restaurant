import { Button, TextField } from "@mui/material";
import React, { useEffect } from "react";
import  { Navigate, redirect } from 'react-router-dom'
import "./loginPage.scss";
import { useGlobalStore } from "../../shared/state/globalStore";
import EmployeeType from "../../shared/types/employee";

const LoginPage = () => {
  const [loginData, setLogin] = React.useState("");
  const [password, setPassword] = React.useState("");
  const [waiter, setIsWaiter] = React.useState(false);
  const [cook, setIsCook] = React.useState(false);
  const [admin, setIsAdmin] = React.useState(false);
  const { login, currentUser } = useGlobalStore();

  useEffect(() => { 
    console.log(currentUser)
    if (currentUser != {} as EmployeeType && currentUser != null) {
      setIsWaiter(currentUser.waiter != null);
      setIsCook(currentUser.cook != null);
      setIsAdmin(currentUser.waiter == null && currentUser.cook === null);
    }
  }, [currentUser])

  if (waiter) {
    return <Navigate to={`/WaiterPage`} />;
  }
  if (admin) {
    return <Navigate to={`/AdminPage`} />;
  }

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
      <div id="content">
        <div id="login-form">
          <TextField
            className="text-input"
            id="login-input"
            label="Логин"
            variant="outlined"
            value={loginData}
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
              if (loginData !== "" && password !== "") {
                login({ login: loginData, password: password });
              }
            }}
          >
            Войти
          </Button>
        </div>
      </div>
  );
};

export default LoginPage;