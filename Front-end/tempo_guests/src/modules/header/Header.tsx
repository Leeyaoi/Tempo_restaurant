import React from "react";
import AccountCircleRoundedIcon from "@mui/icons-material/AccountCircleRounded";
import "./Header.scss";
import LocalPizzaIcon from "@mui/icons-material/LocalPizza";
import { useGlobalStore } from "../../shared/state/globalStore";
import { useNavigate } from "react-router-dom";

const Header = () => {
  const { currentUser } = useGlobalStore();
  const navigate = useNavigate();
  return (
    <div id="header">
      <LocalPizzaIcon
        id="logo"
        onClick={() => {
          navigate("/login");
        }}
      />
      {currentUser ? (
        <div
          id="header_profile"
          onClick={() => {
            navigate("/cart");
          }}
        >
          <AccountCircleRoundedIcon id="icon" /> <p>{currentUser.name}</p>
        </div>
      ) : (
        <></>
      )}
    </div>
  );
};

export default Header;
