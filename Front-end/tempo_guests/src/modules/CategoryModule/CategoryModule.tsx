import React from "react";
import CategoryType from "../../shared/types/category";
import DishComponent from "../../components/MenuComponents/DishComponent/DishComponent";
import DrinkComponent from "../../components/MenuComponents/DrinkComponent/DrinkComponent";
import "./CategoryModule.scss";

interface Props {
  category?: CategoryType;
}

const CategoryModule = ({ category }: Props) => {
  if (category == null) {
    return <></>;
  }
  return (
    <div className="food_category">
      <p className="category_name">{category.name}</p>
      {category.dishes.map((dish, i) => {
        return <DishComponent dish={dish} key={dish.id} />;
      })}
      {category.drinks.map((drink, i) => {
        return <DrinkComponent drink={drink} key={drink.id} />;
      })}
    </div>
  );
};

export default CategoryModule;
