import React from "react";
import DrinkType from "../../shared/types/drink";

interface Props {
  drink?: DrinkType;
}

const DrinkComponent = ({ drink }: Props) => {
  if (drink == null) {
    return <></>;
  }
  return (
    <div>
      <img src="./src/shared/assets/default_food.png" />
      <p>{drink.name}</p>
      <p>{drink.price}p</p>
    </div>
  );
};

export default DrinkComponent;
