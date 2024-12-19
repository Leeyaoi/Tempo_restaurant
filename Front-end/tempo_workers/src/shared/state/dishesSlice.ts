import DishesType from "../types/dishes";
import { StateCreator } from "zustand";
import { sliceResetFns } from "./globalStore";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../types/RESTMethodEnum";
import PaginatedType from "../types/paginatedModel";

export interface DishesSlice {
    loading: boolean;
    success: boolean;
    errorMessage: string;
    Dishes: PaginatedType<DishesType>;
    fetchDishes: (page: number, limit: number) => void;
    createDishes: (newDishes: any) => Promise<void>;
    updateDishes: (id: string, Dishes: DishesType) => void;
    deleteDishes: (id: string) => void;
}

const InitialDishesSlice = {
    loading: false,
    success: false,
    errorMessage: "",
    Dishes: {} as PaginatedType<DishesType>,
};

export const DishesStore: StateCreator<DishesSlice> = (set, get) => {
    sliceResetFns.add(() => {
        set(InitialDishesSlice);
    });
    return {
        ...InitialDishesSlice,

        fetchDishes: async () => {
            set({ loading: true });

            const res = await HttpRequest<PaginatedType<DishesType>>({
                uri: `Dish`,
                method: RESTMethod.Get,
            });

            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set({
                loading: false,
                Dishes: res.data,
            });
        },
        deleteDishes: async (id) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/Dish/${id}`,
                method: RESTMethod.Delete,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                Dishes: {
                    ...state.Dishes,
                    items: state.Dishes.items.filter((Dishes) => Dishes.id !== id),
                },
            }));
        },
        updateDishes: async (id, updatedData) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/Dish/${id}`,
                method: RESTMethod.Put,
                item: updatedData,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                Dishes: {
                    ...state.Dishes,
                    items: state.Dishes.items.map((Dishes) =>
                        Dishes.id === id ? { ...Dishes, ...updatedData } : Dishes
                    ),
                },
            }));
        },

        createDishes: async (newDishes: {
            id: string;
            name: string;
            approx_time: string;
            price: string;
            category: string;
        }) => {
            try {
                const employeeId = await HttpRequest<{ id: string }>({
                    uri: `/Dish`,
                    method: RESTMethod.Post,
                    item: newDishes,
                });
                if (employeeId.code === "error") {
                    set({ errorMessage: employeeId.error.message })
                }
                return;
            } catch (error) {
                return;
            }
        },
    }
}