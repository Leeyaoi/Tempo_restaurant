import DishType from "./dish";
import DrinkType from "./drink";
import TableType from "./table";
import UserType from "./user";

declare module "OrderType";

type OrderType = {
  id: string;
  table: TableType;
  user: UserType;
  dishes: DishType[];
  drinks: DrinkType[];
};

export default OrderType;
