import { useState, useEffect } from "react";
import "./companies.scss";
import httpModule from "../../helper/http.module";
import { ICompany } from "../../types/global.typing";
import { Button, CircularProgress } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { Add } from "@mui/icons-material";
import CompaniesGrid from "../../components/companies/CompanyGrid.component";

const Companies = () => {
  const [companies, setCompanies] = useState<ICompany[]>([]);
  const [loading, setLoading] = useState<boolean>(false);
  const redirect = useNavigate();

  useEffect(() => {
    setLoading(true);
    httpModule
      .get<ICompany[]>("/Company/Get")
      .then((res) => {
        setCompanies(res.data);
        setLoading(false);
      })
      .catch((err) => {
        alert("Error fetching companies");
        console.log(err);
        setLoading(false);
      });
  }, []);

  console.log(companies);

  return (
    <div className="content companies">
      <div className="heading">
        <h2>Companies</h2>
        <Button variant="outlined" onClick={() => redirect("/companies/add")}>
          <Add />
        </Button>
      </div>

      {loading ? (
        <CircularProgress size={100} />
      ) : companies.length === 0 ? (
        <h1>No Company</h1>
      ) : (
        <CompaniesGrid data={companies} />
      )}
    </div>
  );
};

export default Companies;
