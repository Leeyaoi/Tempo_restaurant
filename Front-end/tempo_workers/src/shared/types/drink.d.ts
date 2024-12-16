import CategoryType from "./category";

declare module "DrinkType"

type DrinkType = {
    id?: string;
    name: string;
    price: string;
    category: CategoryType;
    categoryId: string;
}

export default DrinkType