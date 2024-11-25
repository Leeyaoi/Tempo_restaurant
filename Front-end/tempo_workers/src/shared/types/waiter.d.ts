import EmployeeType from "./employee";

declare module "WaiterType"

type WaiterType = {
    id?: string;
    name: string;
    surname: string;
    employee: EmployeeType;
}

export default WaiterType