import { create } from "zustand";
import { devtools, persist, createJSONStorage } from "zustand/middleware";
import { UserSlice, UserStore } from "./userSlice";
import { MenuSlice, MenuStore } from "./menuSlice";

export const sliceResetFns = new Set<() => void>();

export const resetGlobalStore = () => {
  sliceResetFns.forEach((resetFn) => {
    resetFn();
  });
};

export interface GlobalStoreState extends UserSlice, MenuSlice {}

export const useGlobalStore = create<GlobalStoreState>()(
  devtools(
    persist(
      (...a) => ({
        ...UserStore(...a),
        ...MenuStore(...a),
      }),
      {
        name: "app-storage",
        storage: createJSONStorage(() => sessionStorage),
      }
    )
  )
);
