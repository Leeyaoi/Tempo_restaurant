import DishType from "./dishes";
import DrinkType from "./drink";
import TableType from "./table";

declare module "OrderType"

type OrderType = {
    id?: string;
    people_num: number;
    status: number;
    table: TableType;
    user: string;
    dishes: DishType[];
    drinks: DrinkType[];
}

export default OrderType