import DrinkType from "../types/drink";
import { StateCreator } from "zustand";
import { sliceResetFns } from "./globalStore";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../types/RESTMethodEnum";
import PaginatedType from "../types/paginatedModel";

export interface DrinkSlice {
    loading: boolean;
    success: boolean;
    errorMessage: string;
    Drink: PaginatedType<DrinkType>;
    fetchDrink: (page: number, limit: number) => void;
    createDrink: (newDrink: any) => Promise<void>;
    updateDrink: (id: string, Drink: DrinkType) => void;
    deleteDrink: (id: string) => void;
}

const InitialDrinkSlice = {
    loading: false,
    success: false,
    errorMessage: "",
    Drink: {} as PaginatedType<DrinkType>,
};

export const DrinkStore: StateCreator<DrinkSlice> = (set, get) => {
    sliceResetFns.add(() => {
        set(InitialDrinkSlice);
    });
    return {
        ...InitialDrinkSlice,

        fetchDrink: async () => {
            set({ loading: true });

            const res = await HttpRequest<PaginatedType<DrinkType>>({
                uri: `Drink`,
                method: RESTMethod.Get,
            });

            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set({
                loading: false,
                Drink: res.data,
            });
        },
        deleteDrink: async (id) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/Drink/${id}`,
                method: RESTMethod.Delete,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                Drink: {
                    ...state.Drink,
                    items: state.Drink.items.filter((Drink) => Drink.id !== id),
                },
            }));
        },
        updateDrink: async (id, updatedData) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/Drink/${id}`,
                method: RESTMethod.Put,
                item: updatedData,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                Drink: {
                    ...state.Drink,
                    items: state.Drink.items.map((Drink) =>
                        Drink.id === id ? { ...Drink, ...updatedData } : Drink
                    ),
                },
            }));
        },

        createDrink: async (newDrink: {
            id: string;
            name: string;
            price: string;
            category: string;
        }) => {
            try {
                const employeeId = await HttpRequest<{ id: string }>({
                    uri: `/Drink`,
                    method: RESTMethod.Post,
                    item: newDrink,
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