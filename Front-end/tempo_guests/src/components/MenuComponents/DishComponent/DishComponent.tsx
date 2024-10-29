import React, { useEffect, useState } from "react";
import DishType from "../../../shared/types/dish";
import AddIcon from "@mui/icons-material/Add";
import HorizontalRuleIcon from "@mui/icons-material/HorizontalRule";
import { IKImage } from "imagekitio-react";
import { Button, IconButton, TextField } from "@mui/material";
import { useGlobalStore } from "../../../shared/state/globalStore";

interface Props {
  dish?: DishType;
}

const DishComponent = ({ dish }: Props) => {
  if (dish == null) {
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
    setNum(newValue, dish);
  };

  useEffect(() => {
    cart;
  }, [cart]);

  return (
    <div>
      {dish.photo ? (
        <IKImage urlEndpoint={process.env.IMAGE_API} path={dish.photo} />
      ) : (
        <img src="./src/shared/assets/default_food.png" />
      )}
      <p>{dish.name}</p>
      <p>{dish.price}p</p>
      <p>{dish.approx_time} мин</p>
      <div id="add_to_cart">
        {dish.id in cart ? (
          <>
            <IconButton
              id="button"
              onClick={() => {
                decrementInCart(dish);
              }}
            >
              <HorizontalRuleIcon />
            </IconButton>
            <TextField
              type="number"
              className="text-input "
              id="cartNum"
              variant="outlined"
              value={cart[dish.id].num}
              onChange={handleNumberChange}
            />
            <IconButton
              id="button"
              onClick={() => {
                addToCart(dish);
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
              addToCart(dish);
            }}
          >
            Добавить в корзину
          </Button>
        )}
      </div>
    </div>
  );
};

export default DishComponent;
