import { create } from "zustand";
import { devtools, persist, createJSONStorage } from "zustand/middleware";
import { EmployeeSlice, EmployeeStore } from "./employeeSlice";
import { CategorySlice, CategoryStore } from "./categorySlice";
import { DishesSlice, DishesStore } from "./dishesSlice";
import { IngredientSlice, IngredientStore } from "./ingredientSlice";
import DrinkComponent from "../../components/DrinksDataGrid/DrinkComponent";
import { DrinkSlice, DrinkStore } from "./drinkSlice";
import { OrderSlice, OrderStore } from "./orderSlice";
import { UserSlice, UserStore } from "./userSlice";


export const sliceResetFns = new Set<() => void>();

export const resetGlobalStore = () => {
    sliceResetFns.forEach((resetFn) => {
        resetFn();
    });
};

export interface GlobalStoreState
    extends EmployeeSlice, CategorySlice, DishesSlice, IngredientSlice, DrinkSlice, OrderSlice, UserSlice { }

export const useGlobalStore = create<GlobalStoreState>()(
    devtools(
        persist(
            (...a) => ({
                ...DrinkStore(...a),
                ...IngredientStore(...a),
                ...DishesStore(...a),
                ...CategoryStore(...a),
                ...EmployeeStore(...a),
                ...OrderStore(...a),
                ...UserStore(...a)
            }),
            {
                name: "app-storage",
                storage: createJSONStorage(() => sessionStorage),
            }
        )
    )
);