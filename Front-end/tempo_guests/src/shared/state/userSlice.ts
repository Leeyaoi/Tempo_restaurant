import UserType from "../types/user";
import { StateCreator } from "zustand";
import { sliceResetFns } from "./globalStore";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../types/RESTMethodEnum";

export interface UserSlice {
  loading: boolean;
  success: boolean;
  errorMessage: string;
  currentUserId: string;
  currentUser: UserType | null;
  login: (user: UserType) => void;
}

const InitialUserSlice = {
  loading: false,
  success: false,
  errorMessage: "",
  currentUserId: "",
  currentUser: null,
};

export const UserStore: StateCreator<UserSlice> = (set, get) => {
  sliceResetFns.add(() => {
    set(InitialUserSlice);
  });
  return {
    ...InitialUserSlice,
    login: async ({ name, phone }: UserType) => {
      set({ loading: true });
      const res = await HttpRequest<UserType>({
        uri: "/user",
        method: RESTMethod.Post,
        item: { name: name, phone: phone },
      });
      if (res.code == "error") {
        set({ errorMessage: res.error.message, loading: false });
        return;
      }
      set({
        currentUser: res.data,
        currentUserId: res.data.id,
        loading: false,
      });
    },
  };
};
