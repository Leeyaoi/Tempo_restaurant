import { StateCreator } from "zustand";
import { HttpRequest } from "../../api/GenericApi";
import { RESTMethod } from "../types/RESTMethodEnum";
import TableType from "../types/table";
import { sliceResetFns } from "./globalStore";

export interface TableSlice {
  loading: boolean;
  success: boolean;
  errorMessage: string;
  tables: TableType[];
  fetchTables: () => void;
}

const InitialTableSlice = {
  loading: false,
  success: false,
  errorMessage: "",
  tables: [],
};

export const TableStore: StateCreator<TableSlice> = (set, get) => {
  sliceResetFns.add(() => {
    set(InitialTableSlice);
  });
  return {
    ...InitialTableSlice,

    fetchTables: async () => {
      set({ loading: true });
      const res = await HttpRequest<{ items: TableType[] }>({
        uri: "/table",
        method: RESTMethod.Get,
      });
      if (res.code == "error") {
        set({ errorMessage: res.error.message, loading: false });
        return;
      }
      set({ tables: res.data.items, loading: false });
    },
  };
};
