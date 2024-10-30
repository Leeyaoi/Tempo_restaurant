import { StateCreator } from "zustand";
import OrderType from "../types/order";
import { GlobalStoreState, sliceResetFns } from "./globalStore";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../types/RESTMethodEnum";
import { TableSlice } from "./tableSlice";
import DishType from "../types/dish";

export interface OrderSlice {
  loading: boolean;
  success: boolean;
  errorMessage: string;
  currentOrder: OrderType;
  postOrder: (tableIndex: number, people_num: number) => void;
}

const InitialOrderSlice = {
  loading: false,
  success: false,
  errorMessage: "",
  currentOrder: {} as OrderType,
};

export const OrderStore: StateCreator<GlobalStoreState, [], [], OrderSlice> = (
  set,
  get
) => {
  sliceResetFns.add(() => {
    set(InitialOrderSlice);
  });
  return {
    ...InitialOrderSlice,
    postOrder: async (tableIndex: number, people_num: number) => {
      set({ loading: true });
      const dishesId = [];
      const drinksId = [];
      for (let i in get().cart) {
        const item = get().cart[i].item as DishType;
        if (item.approx_time != undefined) {
          for (let j = 0; j < get().cart[i].num; j++) {
            dishesId.push(get().cart[i].item.id);
          }
        } else {
          for (let j = 0; j < get().cart[i].num; j++) {
            drinksId.push(get().cart[i].item.id);
          }
        }
      }
      const res = await HttpRequest<OrderType>({
        uri: "/order",
        method: RESTMethod.Post,
        item: {
          people_num: people_num,
          tableId: get().tables[tableIndex].id,
          userId: get().currentUserId,
          dishesId: dishesId,
          drinksId: drinksId,
        },
      });
      if (res.code == "error") {
        set({ errorMessage: res.error.message, loading: false });
        return;
      }
      set({ currentOrder: res.data, loading: false });
    },
  };
};
