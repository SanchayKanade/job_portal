import { useState } from "react";
import { ICreateCompany } from "../../types/global.typing";
import {
  Button,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
} from "@mui/material";
import TextField from "@mui/material/TextField/TextField";
import { useNavigate } from "react-router-dom";
import httpModule from "../../helper/http.module";
import "./companies.scss";

const AddCompany = () => {
  const [company, setCompany] = useState<ICreateCompany>({
    name: "",
    size: "",
  });
  const redirect = useNavigate();

  const handleClickSaveBtn = () => {
    if (company.name === "" || company.size === "") {
      alert("Fill all fields");
      return;
    }
    httpModule
      .post("/Company/Create", company)
      .then((responst) => redirect("/companies"))
      .catch((error) => console.log(error));
  };

  const handleClickBackBtn = () => {
    redirect("/companies");
  };

  return (
    <div className="content">
      <div className="add-company">
        <h2>Add New Company</h2>
        <TextField
          autoComplete="off"
          label="Company Name"
          variant="outlined"
          value={company.name}
          onChange={(e) => setCompany({ ...company, name: e.target.value })}
        />
        <FormControl fullWidth>
          <InputLabel>Company Size</InputLabel>
          <Select
            value={company.size}
            label="Company Size"
            onChange={(e) => setCompany({ ...company, size: e.target.value })}
          >
            <MenuItem value="Small">Small</MenuItem>
            <MenuItem value="Medium">Medium</MenuItem>
            <MenuItem value="Large">Large</MenuItem>
          </Select>
        </FormControl>
        <div className="btns">
          <Button
            variant="outlined"
            color="primary"
            onClick={handleClickSaveBtn}
          >
            Save
          </Button>
          <Button
            variant="outlined"
            color="secondary"
            onClick={handleClickBackBtn}
          >
            Back
          </Button>
        </div>
      </div>
    </div>
  );
};

export default AddCompany;
