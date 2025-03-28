import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import "./global.scss";
import ThemeContextProvider from "./context/theme.context";
import { BrowserRouter } from "react-router-dom";

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <ThemeContextProvider>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </ThemeContextProvider>
);
