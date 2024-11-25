import EmployeeType from "../types/employee";
import CookType from "../types/cook";
import WaiterType from "../types/waiter";
import { StateCreator } from "zustand";
import { sliceResetFns } from "./globalStore";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../types/RESTMethodEnum";
import PaginatedType from "../types/paginatedModel";

export interface EmployeeSlice {
    loading: boolean;
    success: boolean;
    errorMessage: string;
    cooks: PaginatedType<CookType>;
    waiters: PaginatedType<WaiterType>;
    fetchCooks: (page: number, limit: number) => void;
    fetchWaiters: (page: number, limit: number) => void;
    createCook: (newCook: any) => Promise<void>;
    createWaiter: (newWaiter: any) => Promise<void>;
    updateCook: (id: string, cook: Partial<CookType>) => void;
    updateWaiter: (id: string, waiter: Partial<WaiterType>) => void;
    deleteCook: (id: string) => void;
    deleteWaiter: (id: string) => void;
}

const InitialEmployeeSlice = {
    loading: false,
    success: false,
    errorMessage: "",
    cooks: {} as PaginatedType<CookType>,
    waiters: {} as PaginatedType<WaiterType>,
};

export const EmployeeStore: StateCreator<EmployeeSlice> = (set, get) => {
    sliceResetFns.add(() => {
        set(InitialEmployeeSlice);
    });
    return {
        ...InitialEmployeeSlice,

        fetchCooks: async (page: number, limit: number) => {
            set({ loading: true });

            const res = await HttpRequest<PaginatedType<CookType>>({
                uri: `Cook?page=${page}&limit=${limit}`,
                method: RESTMethod.Get,
            });

            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set({
                loading: false,
                cooks: res.data,
            });
        },

        fetchWaiters: async (page: number, limit: number) => {
            set({ loading: true });

            const res = await HttpRequest<PaginatedType<WaiterType>>({
                uri: `Waiter?page=${page}&limit=${limit}`,
                method: RESTMethod.Get,
            });

            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set({
                loading: false,
                waiters: res.data,
            });
        },

        deleteCook: async (id) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/cook/${id}`,
                method: RESTMethod.Delete,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                cooks: {
                    ...state.cooks,
                    items: state.cooks.items.filter((cook) => cook.id !== id),
                },
            }));
        },

        deleteWaiter: async (id) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/waiter/${id}`,
                method: RESTMethod.Delete,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                waiters: {
                    ...state.waiters,
                    items: state.waiters.items.filter((waiter) => waiter.id !== id),
                },
            }));
        },

        updateCook: async (id, updatedData) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/cook/${id}`,
                method: RESTMethod.Put,
                item: updatedData,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                cooks: {
                    ...state.cooks,
                    items: state.cooks.items.map((cook) =>
                        cook.id === id ? { ...cook, ...updatedData } : cook
                    ),
                },
            }));
        },

        updateWaiter: async (id, updatedData) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/waiter/${id}`,
                method: RESTMethod.Put,
                item: updatedData,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                waiters: {
                    ...state.waiters,
                    items: state.waiters.items.map((waiter) =>
                        waiter.id === id ? { ...waiter, ...updatedData } : waiter
                    ),
                },
            }));
        },

        createCook: async (newCook: CookType) => {
            try {
                const employeeId = await HttpRequest<{ id: string }>({
                    uri: `/employee`,
                    method: RESTMethod.Post,
                    item: newCook.employee,
                });
                if (employeeId.code === "error") {
                    return;
                }
                const id = await HttpRequest<CookType>({
                    uri: `/cook`,
                    method: RESTMethod.Post,
                    item: { ...newCook, employeeId: employeeId.data.id },
                });
                if (id.code === "error") {
                    set({ errorMessage: id.error.message })
                }
                return;
            } catch (error) {
                return;
            }
        },

        createWaiter: async (newWaiter: any) => {
            try {
                const employeeId = await HttpRequest<{ id: string }>({
                    uri: `/employee`,
                    method: RESTMethod.Post,
                    item: newWaiter.employee,
                });
                if (employeeId.code === "error") {
                    return;
                }
                const id = await HttpRequest<WaiterType>({
                    uri: `/waiter`,
                    method: RESTMethod.Post,
                    item: { ...newWaiter, employeeId: employeeId.data.id },
                });
                if (id.code === "error") {
                    set({ errorMessage: id.error.message })
                }
                return;
            } catch (error) {
                return;
            }
        },
    };
};