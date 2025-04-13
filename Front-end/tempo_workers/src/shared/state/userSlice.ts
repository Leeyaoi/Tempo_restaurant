import { StateCreator } from "zustand";
import { sliceResetFns } from "./globalStore";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../types/RESTMethodEnum";
import EmployeeType from "../types/employee";

export interface UserSlice {
    loading: boolean;
    success: boolean;
    errorMessage: string;
    currentUser: EmployeeType | null;
    login: (loginInfo: {
        login: string;
        password: string;
    }) => {};
}

const InitialOrderSlice = {
    loading: false,
    success: false,
    errorMessage: "",
    currentUser: null
};

export const UserStore: StateCreator<UserSlice> = (set, get) => {
    sliceResetFns.add(() => {
        set(InitialOrderSlice);
    });
    return {
        ...InitialOrderSlice,


        login: async (loginInfo: {
            login: string;
            password: string;
        }) => {
            set({ loading: true });

            const res = await HttpRequest<EmployeeType>({
                uri: `Employee/login`,
                method: RESTMethod.Post,
                item: loginInfo
            });

            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set({
                loading: false,
                currentUser: res.data,
            });
        },
    }
}