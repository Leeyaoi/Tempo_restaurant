import CategoryType from "./category";
import EmployeeType from "./employee";

declare module "CookType"

type CookType = {
    id?: string;
    name: string;
    surname: string;
    category: CategoryType;
    categoryId: string;
    employee: EmployeeType;
    employeeId: string;
}

export default CookType