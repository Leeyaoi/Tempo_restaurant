import EmployeeType from "../types/employee";
import { StateCreator } from "zustand";
import { sliceResetFns } from "./globalStore";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../types/RESTMethodEnum";
import PaginatedType from "../types/paginatedModel";

export interface EmployeeSlice {
    loading: boolean;
    success: boolean;
    errorMessage: string;
    employees: PaginatedType<EmployeeType>;
    fetchEmployees: (page: number, limit: number) => void;
    deleteEmployee: (id: string | number) => void;
    updateEmployee: (id: string | number, updatedData: Partial<EmployeeType>) => void;
    createEmployee: (newEmployee: EmployeeType) => void;
}

const InitialEmployeeSlice = {
    loading: false,
    success: false,
    errorMessage: "",
    employees: {
        items: [],
        limit: 5,
        page: 1,
        pageCount: 1,
        total: 0,
    },
};

export const EmployeeStore: StateCreator<EmployeeSlice> = (set, get) => {
    sliceResetFns.add(() => {
        set(InitialEmployeeSlice);
    });
    return {
        ...InitialEmployeeSlice,

        fetchEmployees: async (page: number, limit: number) => {
            set({ loading: true });
        
            const res = await HttpRequest<PaginatedType<EmployeeType>>({
                uri: `Employee?page=${page}&limit=${limit}`,
                method: RESTMethod.Get,
            });
        
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set({
                loading: false,
                employees: res.data,
            });
        },

        deleteEmployee: async (id) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/employee/${id}`,
                method: RESTMethod.Delete,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                employees: {
                    ...state.employees,
                    items: state.employees.items.filter((employee) => employee.id !== id),
                },
            }));
        },

        updateEmployee: async (id, updatedData) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/employee/${id}`,
                method: RESTMethod.Put,
                item: updatedData,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                employees: {
                    ...state.employees,
                    items: state.employees.items.map((employee) =>
                        employee.id === id ? { ...employee, ...updatedData } : employee
                    ),
                },
            }));
        },

        createEmployee: async (newEmployee: any) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: "/employee",
                method: RESTMethod.Post,
                item: newEmployee,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                employees: {
                    ...state.employees,
                    items: [...state.employees.items, res.data as EmployeeType],
                    total: state.employees.total + 1,
                },
            }));
        },
    };
};