import {
    Box,
    Container,
    createTheme,
    CssBaseline,
    Grid,
    ThemeProvider,
  } from "@mui/material";
  import { useEffect, useState } from "react";

  import api from "../Api/Api";
  import Filters from "../Filter/Filter";
  import { dummHeroPost } from "../../TestingData/Test";
  import Post from "../Banner/Post";
  import Recepy from "./Recepy";
  
  const TravelOffers: React.FC = () => {
    const [Recepies, setTravelOffers] = useState<any[]>([]);
    const theme = createTheme();
  
    useEffect(() => {
      const getTravelOffers = async () => {
        const { data } = await api.get("/Recepy");
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
                      <Filters />
                    </Grid>
                    <Grid item xs={10}>
                      <Grid container spacing={4}>
                        {Recepies?.map((offer, index) => (
                          <Recepy
                            title={offer.city.name}
                            date={`${offer.departureDate.slice(
                              0,
                              10
                            )} - ${offer.returnDate.slice(0, 10)}`}
                            description={offer.description}
                            image={"https://omnilargess.com/wp-content/uploads/2020/01/Neutral-1024x605.jpg"}
                            imageLabel={"Sveikas"}
                            price={offer.price}
                            peopleCount={offer.personCount}
                            key={index}
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
    
    export default TravelOffers;