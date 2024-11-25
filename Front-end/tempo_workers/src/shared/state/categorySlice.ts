import CategoryType from "../types/category";
import { StateCreator } from "zustand";
import { sliceResetFns } from "./globalStore";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../types/RESTMethodEnum";
import PaginatedType from "../types/paginatedModel";

export interface CategorySlice {
    loading: boolean;
    success: boolean;
    errorMessage: string;
    Category: PaginatedType<CategoryType>;
    fetchCategory: () => void;
    createCategory: (newCategory: any) => Promise<void>;
    updateCategory: (id: string, Category: Partial<CategoryType>) => void;
    deleteCategory: (id: string) => void;
}

const InitialCategorySlice = {
    loading: false,
    success: false,
    errorMessage: "",
    Category: {} as PaginatedType<CategoryType>,
};

export const CategoryStore: StateCreator<CategorySlice> = (set, get) => {
    sliceResetFns.add(() => {
        set(InitialCategorySlice);
    });
    return {
        ...InitialCategorySlice,

        fetchCategory: async () => {
            set({ loading: true });

            const res = await HttpRequest<PaginatedType<CategoryType>>({
                uri: `Category`,
                method: RESTMethod.Get,
            });

            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set({
                loading: false,
                Category: res.data,
            });
        },
        deleteCategory: async (id) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/Category/${id}`,
                method: RESTMethod.Delete,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                Category: {
                    ...state.Category,
                    items: state.Category.items.filter((Category) => Category.id !== id),
                },
            }));
        },
        updateCategory: async (id, updatedData) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/Category/${id}`,
                method: RESTMethod.Put,
                item: updatedData,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                Category: {
                    ...state.Category,
                    items: state.Category.items.map((Category) =>
                        Category.id === id ? { ...Category, ...updatedData } : Category
                    ),
                },
            }));
        },

        createCategory: async (newCategory: {
            id: string;
            name: string;
            surname: string;
            login: string;
            password: string;
        }) => {
            try {
                const employeeId = await HttpRequest<{ id: string }>({
                    uri: `/Category/post`,
                    method: RESTMethod.Post,
                    item: newCategory,
                });
                if (employeeId.code === "error") {
                    return;
                }
                const id = await HttpRequest<CategoryType>({
                    uri: `/Category/post`,
                    method: RESTMethod.Post,
                    item: { ...newCategory, CategoryId: employeeId.data.id },
                });
                if (id.code === "error") {
                    set({ errorMessage: id.error.message })
                }
                return;
            } catch (error) {
                return;
            }
        },
    }
}