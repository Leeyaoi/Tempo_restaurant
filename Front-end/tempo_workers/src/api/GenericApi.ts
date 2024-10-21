import { client } from "./client";
import { AxiosError, AxiosResponse } from "axios";
import { RESTMethod } from "../shared/types/RESTMethodEnum";

interface Props {
  uri: string;
  method: RESTMethod;
  item?: object;
  id?: string;
}

type SuccessResponse<V> = {
  code: "success";
  data: V;
};

type ErrorResponse<E = AxiosError> = {
  code: "error";
  error: E;
};

type BaseResponse<V, E> = SuccessResponse<V> | ErrorResponse<E>;

export const HttpRequest = async <V, E = AxiosError>({
  uri,
  method,
  item = {},
  id = "",
}: Props): Promise<BaseResponse<V, E>> => {
  let res: AxiosResponse<V>;
  try {
    switch (method) {
      case RESTMethod.Get:
        res = await client.get<V>(uri);
        break;
      case RESTMethod.Post:
        res = await client.post<V>(uri, item);
        break;
      case RESTMethod.Delete:
        res = await client.delete<V>(uri + "/" + id);
        break;
      case RESTMethod.Put:
        res = await client.put<V>(uri + "/" + id, item);
        break;
      default:
        throw "Bad request";
    }
    if (res.status >= 400) {
      return {
        code: "error",
        error: new Error(`Request failed with status ${res.status}`) as E,
      };
    }
    return { code: "success", data: res.data };
  } catch (error) {
    return { code: "error", error: error as E };
  }
};
