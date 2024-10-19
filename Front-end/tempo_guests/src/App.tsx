import React from "react";
import { HttpRequest } from "./api/GenericApi";
import { RESTMethod } from "./shared/types/RESTMethodEnum";

console.log(HttpRequest<any>({ uri: "/waiter", method: RESTMethod.Get }));

const App = () => {
  return <div>Hi</div>;
};

export default App;
