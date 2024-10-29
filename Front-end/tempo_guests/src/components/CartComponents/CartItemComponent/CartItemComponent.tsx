import React from "react";
import "./CartItemComponent.scss";
import CartItem from "../../../shared/types/CartItem";
import { IconButton, TextField } from "@mui/material";
import { useGlobalStore } from "../../../shared/state/globalStore";
import HorizontalRuleIcon from "@mui/icons-material/HorizontalRule";
import AddIcon from "@mui/icons-material/Add";

const CartItemComponent = ({ item }: { item: CartItem }) => {
  const { setNum, addToCart, decrementInCart } = useGlobalStore();

  const handleNumberChange = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    let newValue = event.target.value as unknown as number;
    if (newValue < 0) {
      newValue = 0;
    }
    setNum(newValue, item.item);
  };

  return (
    <div className="CartItemComponent">
      <img src="./src/shared/assets/default_food.png" className="cart_photo" />
      <p className="cart_name">{item.item.name}</p>
      <p className="cart_price">{item.item.price}p</p>
      <div className="cart_number">
        <IconButton
          id="button"
          onClick={() => {
            addToCart(item.item);
          }}
        >
          <AddIcon />
        </IconButton>
        <TextField
          type="number"
          className="text-input "
          id="cartNum"
          variant="outlined"
          value={item.num}
          onChange={handleNumberChange}
        />
        <IconButton
          id="button"
          onClick={() => {
            decrementInCart(item.item);
          }}
        >
          <HorizontalRuleIcon />
        </IconButton>
      </div>
    </div>
  );
};

export default CartItemComponent;
