import { StateCreator } from "zustand";
import CategoryType from "../types/category";
import { sliceResetFns } from "./globalStore";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../types/RESTMethodEnum";

export interface MenuSlice {
  loading: boolean;
  success: boolean;
  errorMessage: string;
  menu: CategoryType[];
  fetchMenu: () => void;
}

const InitialMenuSlice = {
  loading: false,
  success: false,
  errorMessage: "",
  menu: [],
};

export const MenuStore: StateCreator<MenuSlice> = (set, get) => {
  sliceResetFns.add(() => {
    set(InitialMenuSlice);
  });
  return {
    ...InitialMenuSlice,

    fetchMenu: async () => {
      set({ loading: true });
      const res = await HttpRequest<{ items: CategoryType[] }>({
        uri: "/category",
        method: RESTMethod.Get,
      });
      if (res.code == "error") {
        set({ errorMessage: res.error.message, loading: false });
        return;
      }
      set({ menu: res.data.items, loading: false });
    },
  };
};
