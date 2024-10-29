import DishType from "./dish";
import DrinkType from "./drink";

export default interface CartItem {
  num: number;
  item: DrinkType | DishType;
}
