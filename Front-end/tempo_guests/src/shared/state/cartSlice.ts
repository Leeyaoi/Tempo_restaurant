import { StateCreator } from "zustand";
import CartItem from "../types/CartItem";
import DishType from "../types/dish";
import DrinkType from "../types/drink";
import { sliceResetFns } from "./globalStore";

const copyCart = (cart: { [id: string]: CartItem }) => {
  const newCart = Object.assign({}, cart);
  return newCart;
};

export interface CartSlice {
  loading: boolean;
  success: boolean;
  errorMessage: string;
  cart: { [id: string]: CartItem };
  addToCart: (item: DrinkType | DishType) => void;
  decrementInCart: (item: DrinkType | DishType) => void;
  setNum: (num: number, item: DrinkType | DishType) => void;
  removeFromCart: (item: DrinkType | DishType) => void;
  emptyCart: () => void;
  countPrice: () => number;
  countTime: () => string;
}

const InitialCartSlice = {
  loading: false,
  success: false,
  errorMessage: "",
  cart: {},
};

export const CartStore: StateCreator<CartSlice> = (set, get) => {
  sliceResetFns.add(() => {
    set(InitialCartSlice);
  });
  return {
    ...InitialCartSlice,

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
      if (Number.isInteger(num)) {
        const tempCart = copyCart(get().cart);
        if (item.id in tempCart) {
          delete tempCart[item.id];
        }
        tempCart[item.id] = { item: item, num: num };
        set({ cart: copyCart(tempCart) });
        if (num <= 0) {
          get().removeFromCart(item);
        }
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

    countPrice: () => {
      let price = 0;
      for (let i in get().cart) {
        price += get().cart[i].item.price * get().cart[i].num;
      }
      return price;
    },

    countTime: () => {
      let time = 0;
      for (let i in get().cart) {
        const item = get().cart[i].item as DishType;
        if (item.approx_time != undefined) {
          time += item.approx_time * get().cart[i].num;
        }
      }
      return `${Math.floor(time / 60)}ч. ${time % 60}мин.`;
    },
  };
};
