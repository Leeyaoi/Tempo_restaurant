import CookType from "./cook";
import WaiterType from "./waiter";

declare module "EmployeeType"

type EmployeeType = {
    id?: string;
    cook: CookType;
    waiter: WaiterType;
    login: string;
    password: string;
}

export default EmployeeType