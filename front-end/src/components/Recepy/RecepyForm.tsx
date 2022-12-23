import { Box, TextField, Typography } from "@mui/material";
import React from "react";
import { useState } from "react";
import FormContainer from "../Form/Form";

const TravelOfferForm = () => {
    


  const handleOnSubmit = (e: React.FormEvent<HTMLFormElement>) => {};

  return (
    <FormContainer>
      <Typography component="h1" variant="h5">
        Naujas kelionės pasiūlymas
      </Typography>
      <Box component="form" onSubmit={handleOnSubmit} sx={{ mt: 1 }}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="name"
          label="Pavadinimas"
          name="name"
        />
       <TextField
          margin="normal"
          fullWidth
          id="description"
          label="Aprašymas"
          name="description"
          type="description"
          multiline
          minRows={3}
        />
        <TextField
          margin="normal"
          required
          fullWidth
          id="duration"
          label="Trukmė"
          name="duration"
          type="number"
        />
      
        <TextField
          margin="normal"
          required
          fullWidth
          id="recepySetId"
          label="SetId"
          name="recepySetId"
          type="number"
        />
        
      </Box>
    </FormContainer>
  );
};

export default TravelOfferForm;