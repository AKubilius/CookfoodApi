import { Button, TextField } from "@mui/material";
import { useState } from "react";

const Filters: React.FC = () => {


  const handleOnSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log("opa");
  };

  return (
    <div className="filters-container">
      <h3>Filtras</h3>
      <form onSubmit={handleOnSubmit}>
        <TextField
          margin="normal"
          fullWidth
          id="title"
          label="Receptas"
          name="title"
        />
        <Button
          type="submit"
          fullWidth
          variant="contained"
          sx={{ mt: 3, mb: 2 }}
        >
          Filtruoti
        </Button>
      </form>
    </div>
  );
};

export default Filters;