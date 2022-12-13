import {
    Box,
    Container,
    createTheme,
    CssBaseline,
    Grid,
    ThemeProvider,
  } from "@mui/material";
  import { useEffect, useState } from "react";
  import { dummHeroPost } from "../../TestingData/Test";
  import Post from "./Post";
  import Recepy from "../Recepy/Recepy"
  import MCard from "../Card/RecepyCard"


export const Banner = () => {
  return (
    <Container maxWidth={false}>
          <main>
            <Post
              image={dummHeroPost.image}
              imageText={dummHeroPost.imageText}
              title={dummHeroPost.title}
            />
            <Box sx={{ flexGrow: "inherit" }}>
            </Box>
          </main>
        </Container>
  )
};
export default Banner;
