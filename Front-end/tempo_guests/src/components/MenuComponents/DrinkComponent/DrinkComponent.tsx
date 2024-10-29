import React, { useEffect, useState } from "react";
import DrinkType from "../../../shared/types/drink";
import { Button, IconButton, TextField } from "@mui/material";
import HorizontalRuleIcon from "@mui/icons-material/HorizontalRule";
import AddIcon from "@mui/icons-material/Add";
import { useGlobalStore } from "../../../shared/state/globalStore";

interface Props {
  drink?: DrinkType;
}

const DrinkComponent = ({ drink }: Props) => {
  if (drink == null) {
    return <></>;
  }

  const { setNum, addToCart, decrementInCart, cart } = useGlobalStore();

  const handleNumberChange = (
    event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    let newValue = event.target.value as unknown as number;
    if (newValue < 0) {
      newValue = 0;
    }
    setNum(newValue, drink);
  };

  useEffect(() => {
    cart;
  }, [cart]);

  return (
    <div>
      <img src="./src/shared/assets/default_food.png" />
      <p>{drink.name}</p>
      <p>{drink.price}p</p>
      <div id="add_to_cart">
        {drink.id in cart ? (
          <>
            <IconButton
              id="button"
              onClick={() => {
                decrementInCart(drink);
              }}
            >
              <HorizontalRuleIcon />
            </IconButton>
            <TextField
              type="number"
              className="text-input "
              id="cartNum"
              variant="outlined"
              value={cart[drink.id].num}
              onChange={handleNumberChange}
            />
            <IconButton
              id="button"
              onClick={() => {
                addToCart(drink);
              }}
            >
              <AddIcon />
            </IconButton>
          </>
        ) : (
          <Button
            id="button"
            variant="contained"
            onClick={() => {
              addToCart(drink);
            }}
          >
            Добавить в корзину
          </Button>
        )}
      </div>
    </div>
  );
};

export default DrinkComponent;
