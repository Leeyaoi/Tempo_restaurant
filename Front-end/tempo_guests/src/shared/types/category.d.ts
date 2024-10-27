import DishType from "./dish";
import DrinkType from "./drink";

declare module "CategoryType";

type CategoryType = {
  id: string;
  name: string;
  drinks: DrinkType[];
  dishes: DishType[];
};

export default CategoryType;
