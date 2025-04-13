import { StateCreator } from "zustand";
import { sliceResetFns } from "./globalStore";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../types/RESTMethodEnum";
import PaginatedType from "../types/paginatedModel";
import OrderType from "../types/order";

export interface OrderSlice {
    loading: boolean;
    success: boolean;
    errorMessage: string;
    Order: PaginatedType<OrderType>;
    fetchOrders: () => void;
    createOrder: (newOrder: any) => Promise<void>;
    updateOrder: (id: string, Order: Partial<OrderType>) => void;
    deleteOrder: (id: string) => void;
}

const InitialOrderSlice = {
    loading: false,
    success: false,
    errorMessage: "",
    Order: {} as PaginatedType<OrderType>,
};

export const OrderStore: StateCreator<OrderSlice> = (set, get) => {
    sliceResetFns.add(() => {
        set(InitialOrderSlice);
    });
    return {
        ...InitialOrderSlice,

        fetchOrders: async () => {
            set({ loading: true });

            const res = await HttpRequest<PaginatedType<OrderType>>({
                uri: `Order`,
                method: RESTMethod.Get,
            });

            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set({
                loading: false,
                Order: res.data,
            });
        },
        deleteOrder: async (id) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/Order/${id}`,
                method: RESTMethod.Delete,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                Order: {
                    ...state.Order,
                    items: state.Order.items.filter((Order) => Order.id !== id),
                },
            }));
        },
        updateOrder: async (id, updatedData) => {
            set({ loading: true });
            const res = await HttpRequest({
                uri: `/Order/${id}`,
                method: RESTMethod.Put,
                item: updatedData,
            });
            if (res.code === "error") {
                set({ errorMessage: res.error.message, loading: false });
                return;
            }
            set((state) => ({
                loading: false,
                Order: {
                    ...state.Order,
                    items: state.Order.items.map((Order) =>
                        Order.id === id ? { ...Order, ...updatedData } : Order
                    ),
                },
            }));
        },

        createOrder: async (newOrder: {
            id: string;
            name: string;
            surname: string;
            login: string;
            password: string;
        }) => {
            try {
                const employeeId = await HttpRequest<{ id: string }>({
                    uri: `/Order/post`,
                    method: RESTMethod.Post,
                    item: newOrder,
                });
                if (employeeId.code === "error") {
                    return;
                }
                const id = await HttpRequest<OrderType>({
                    uri: `/Order/post`,
                    method: RESTMethod.Post,
                    item: { ...newOrder, OrderId: employeeId.data.id },
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