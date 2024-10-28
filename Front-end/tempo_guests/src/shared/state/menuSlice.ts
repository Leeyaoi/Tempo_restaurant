import { StateCreator } from "zustand";
import CategoryType from "../types/category";
import { sliceResetFns } from "./globalStore";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../types/RESTMethodEnum";
import DrinkType from "../types/drink";
import DishType from "../types/dish";

interface CartItem {
  num: number;
  item: DrinkType | DishType;
}

const copyCart = (cart: { [id: string]: CartItem }) => {
  const newCart = Object.assign({}, cart);
  return newCart;
};

export interface MenuSlice {
  loading: boolean;
  success: boolean;
  errorMessage: string;
  menu: CategoryType[];
  cart: { [id: string]: CartItem };
  fetchMenu: () => void;
  addToCart: (item: DrinkType | DishType) => void;
  decrementInCart: (item: DrinkType | DishType) => void;
  setNum: (num: number, item: DrinkType | DishType) => void;
  removeFromCart: (item: DrinkType | DishType) => void;
  emptyCart: () => void;
}

const InitialMenuSlice = {
  loading: false,
  success: false,
  errorMessage: "",
  menu: [],
  cart: {},
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

    addToCart: (item: DrinkType | DishType) => {
      let num = 1;
      const tempCart = copyCart(get().cart);
      if (item.id in tempCart) {
        num = tempCart[item.id]!.num + 1;
        delete tempCart[item.id];
      }
      tempCart[item.id] = { item: item, num: num };
      set({ cart: copyCart(tempCart) });
      if (num <= 0) {
        get().removeFromCart(item);
      }
    },

    decrementInCart: (item: DrinkType | DishType) => {
      let num = 0;
      const tempCart = copyCart(get().cart);
      if (item.id in tempCart) {
        num = tempCart[item.id]!.num - 1;
        delete tempCart[item.id];
      }
      tempCart[item.id] = { item: item, num: num };
      set({ cart: copyCart(tempCart) });
      if (num <= 0) {
        get().removeFromCart(item);
      }
    },

    setNum: (num: number, item: DrinkType | DishType) => {
      const tempCart = copyCart(get().cart);
      if (item.id in tempCart) {
        delete tempCart[item.id];
      }
      tempCart[item.id] = { item: item, num: num };
      set({ cart: copyCart(tempCart) });
      if (num <= 0) {
        get().removeFromCart(item);
      }
    },

    removeFromCart: (item: DrinkType | DishType) => {
      const tempCart = copyCart(get().cart);
      delete tempCart[item.id];
      set({ cart: copyCart(tempCart) });
    },

    emptyCart: () => {
      set({ cart: {} });
    },
  };
};
