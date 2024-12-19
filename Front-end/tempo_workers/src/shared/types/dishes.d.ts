import CategoryType from "./category";
import EmployeeType from "./employee";

declare module "DishType"

type DishType = {
    id?: string;
    name: string;
    approx_time: number;
    price: string;
    category: CategoryType;
    categoryId: string;
}

export default DishType