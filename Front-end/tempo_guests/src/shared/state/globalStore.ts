import { create } from "zustand";
import { devtools, persist, createJSONStorage } from "zustand/middleware";
import { UserSlice, UserStore } from "./userSlice";
import { MenuSlice, MenuStore } from "./menuSlice";
import { CartSlice, CartStore } from "./cartSlice";
import { TableSlice, TableStore } from "./tableSlice";
import { OrderSlice, OrderStore } from "./orderSlice";

export const sliceResetFns = new Set<() => void>();

export const resetGlobalStore = () => {
  sliceResetFns.forEach((resetFn) => {
    resetFn();
  });
};

export interface GlobalStoreState
  extends UserSlice,
    MenuSlice,
    CartSlice,
    TableSlice,
    OrderSlice {}

export const useGlobalStore = create<GlobalStoreState>()(
  devtools(
    persist(
      (...a) => ({
        ...UserStore(...a),
        ...MenuStore(...a),
        ...CartStore(...a),
        ...TableStore(...a),
        ...OrderStore(...a),
      }),
      {
        name: "app-storage",
        storage: createJSONStorage(() => sessionStorage),
      }
    )
  )
);
