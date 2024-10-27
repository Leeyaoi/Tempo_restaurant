import React from "react";
import AccountCircleRoundedIcon from "@mui/icons-material/AccountCircleRounded";
import "./Header.scss";
import LocalPizzaIcon from "@mui/icons-material/LocalPizza";
import { useGlobalStore } from "../../shared/state/globalStore";

const Header = () => {
  const { currentUser } = useGlobalStore();
  return (
    <div id="header">
      <LocalPizzaIcon id="logo" />
      {currentUser ? (
        <div id="header_profile">
          <AccountCircleRoundedIcon id="icon" /> <p>{currentUser.name}</p>
        </div>
      ) : (
        <></>
      )}
    </div>
  );
};

export default Header;
