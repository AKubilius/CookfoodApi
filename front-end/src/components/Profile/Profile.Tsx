import {
  Box,
  Container,
  createTheme,
  CssBaseline,
  Grid,
  ThemeProvider,
} from "@mui/material";
import { useEffect, useState } from "react";

import {api,authConfig} from "../Api/Api";
import { dummHeroPost } from "../../TestingData/Test";
import Post from "../Banner/Post";
import RecepySet from "../RecepySet/RecepySet";
import React from "react";

const RecepySets: React.FC = () => {
  const [RecepySets, setTravelOffers] = useState<any[]>([]);
  const theme = createTheme();

  useEffect(() => {
    const getTravelOffers = async () => {
      const { data } = await api.get("/RecepySet/user",authConfig);
      setTravelOffers(data);
    };

    getTravelOffers();
  }, []);

  return (
      <>
        <ThemeProvider theme={theme}>
          <CssBaseline />
          <Container maxWidth={false}>
            <main>
              <Post
                image={dummHeroPost.image}
                imageText={dummHeroPost.imageText}
                title={dummHeroPost.title}
              />
              <Box sx={{ flexGrow: 1 }}>
                <Grid container spacing={2}>
                  <Grid item xs={2}>
                 
                  </Grid>
                  <Grid item xs={10}>
                    <Grid container spacing={4}>
                      {RecepySets?.map((offer, index) => (
                        <RecepySet
                          name={offer.name}
                          type={offer.type}
                          image={"https://images.pexels.com/photos/1640777/pexels-photo-1640777.jpeg"}
                          imageLabel={"Sveikas"}
                          key={index}
                          setId={offer.id}
                        />
                        
                      ))}
                    </Grid>
                  </Grid>
                </Grid>
              </Box>
            </main>
          </Container>
        </ThemeProvider>
      </>
    );
  };
  
  export default RecepySets;