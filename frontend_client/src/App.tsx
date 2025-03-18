import React from "react";
import { useContext, lazy, Suspense } from "react";
import { ThemeContext } from "./context/theme.context";
import Navbar from "./components/navbar/Navbar.component";
import { Routes, Route } from "react-router-dom";
import CustomLinearProgress from "./components/navbar/custom-linear-progress/CustomLinearProgress.component";

// Imports with Lazy loading
const Home = lazy(() => import("./pages/home/Home.page"));
const Companies = lazy(() => import("./pages/companies/Companies.page"));
const AddCompany = lazy(() => import("./pages/companies/AddCompany.page"));

const App = () => {
  const { darkMode } = useContext(ThemeContext);

  const appStyles = darkMode ? "app-dark" : "app";

  return (
    <div className={`app ${darkMode ? "dark" : ""}`}>
      <Navbar />
      <div className="wrapper">
        <Suspense fallback={<CustomLinearProgress />}>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/companies">
              <Route index element={<Companies />} />
              <Route path="add" element={<AddCompany />} />
            </Route>
          </Routes>
        </Suspense>
      </div>
    </div>
  );
};

export default App;
