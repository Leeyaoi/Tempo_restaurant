import { create } from "zustand";
import { devtools, persist, createJSONStorage } from "zustand/middleware";
import { EmployeeSlice, EmployeeStore } from "./employeeSlice";
import { CategorySlice, CategoryStore } from "./categorySlice";


export const sliceResetFns = new Set<() => void>();

export const resetGlobalStore = () => {
    sliceResetFns.forEach((resetFn) => {
        resetFn();
    });
};

export interface GlobalStoreState
    extends EmployeeSlice, CategorySlice { }

export const useGlobalStore = create<GlobalStoreState>()(
    devtools(
        persist(
            (...a) => ({
                ...CategoryStore(...a),
                ...EmployeeStore(...a),
            }),
            {
                name: "app-storage",
                storage: createJSONStorage(() => sessionStorage),
            }
        )
    )
);