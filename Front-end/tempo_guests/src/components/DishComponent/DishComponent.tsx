import React from "react";
import DishType from "../../shared/types/dish";

interface Props {
  dish?: DishType;
}

const DishComponent = ({ dish }: Props) => {
  if (dish == null) {
    return <></>;
  }
  return (
    <div>
      <img src="./src/shared/assets/default_food.png" />
      <p>{dish.name}</p>
      <p>{dish.price}p</p>
      <p>{dish.approx_time}мин</p>
    </div>
  );
};

export default DishComponent;
