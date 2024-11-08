import { create } from "zustand";
import { devtools, persist, createJSONStorage } from "zustand/middleware";
import { EmployeeSlice, EmployeeStore } from "./employeeSlice";


export const sliceResetFns = new Set<() => void>();

export const resetGlobalStore = () => {
    sliceResetFns.forEach((resetFn) => {
        resetFn();
    });
};

export interface GlobalStoreState
    extends EmployeeSlice { }

export const useGlobalStore = create<GlobalStoreState>()(
    devtools(
        persist(
            (...a) => ({
                ...EmployeeStore(...a),
            }),
            {
                name: "app-storage",
                storage: createJSONStorage(() => sessionStorage),
            }
        )
    )
);