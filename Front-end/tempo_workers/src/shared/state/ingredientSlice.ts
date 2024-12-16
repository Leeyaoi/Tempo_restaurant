import IngredientType from "../types/ingredient";
import { StateCreator } from "zustand";
import { sliceResetFns } from "./globalStore";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../types/RESTMethodEnum";
import PaginatedType from "../types/paginatedModel";

export interface IngredientSlice {
    loading: boolean;
    success: boolean;
    errorMessage: string;
    Ingredient: PaginatedType<IngredientType>;
    fetchIngredient: (page: number, limit: number) => void;
    createIngredient: (newIngredient: any) => Promise<void>;
    updateIngredient: (id: string, Ingredient: IngredientType) => void;
    deleteIngredient: (id: string) => void;
}

const InitialIngredientSlice = {
    loading: false,
    success: false,
    errorMessage: "",
    Ingredient: {} as PaginatedType<IngredientType>,
};

export const IngredientStore: StateCreator<IngredientSlice> = (set, get) => {
    sliceResetFns.add(() => {
        set(InitialIngredientSlice);
    });
    return {
        ...InitialIngredientSlice,

        fetchIngredient: async () => {
            set({ loading: true });

            const res = await HttpRequest<PaginatedType<IngredientType>>({
                uri: `Ingredient`,
                method: RESTMethod.Get,
            });

            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set({
                loading: false,
                Ingredient: res.data,
            });
        },
        deleteIngredient: async (id) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/Ingredient/${id}`,
                method: RESTMethod.Delete,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                Ingredient: {
                    ...state.Ingredient,
                    items: state.Ingredient.items.filter((Ingredient) => Ingredient.id !== id),
                },
            }));
        },
        updateIngredient: async (id, updatedData) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/Ingredient/${id}`,
                method: RESTMethod.Put,
                item: updatedData,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                Ingredient: {
                    ...state.Ingredient,
                    items: state.Ingredient.items.map((Ingredient) =>
                        Ingredient.id === id ? { ...Ingredient, ...updatedData } : Ingredient
                    ),
                },
            }));
        },

        createIngredient: async (newIngredient: {
            id: string;
            name: string;
            approx_time: string;
            price: string;
            category: string;
        }) => {
            try {
                const employeeId = await HttpRequest<{ id: string }>({
                    uri: `/Ingredient`,
                    method: RESTMethod.Post,
                    item: newIngredient,
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