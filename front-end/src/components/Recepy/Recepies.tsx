import {
    Box,
    Container,
    createTheme,
    CssBaseline,
    Grid,
    ThemeProvider,
  } from "@mui/material";
  import { useEffect, useState } from "react";
  import RecepyEdit from "./RecepyEdit";
  import {api,authConfig} from "../Api/Api";
  import Filters from "../Filter/Filter";
  import { dummHeroPost } from "../../TestingData/Test";
  import Post from "../Banner/Post";
  import Recepy from "./Recepy";
import Button from "@mui/material/Button";
  
  const Recepies: React.FC = () => {
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
                      
                    </Grid>
                    <Grid item xs={10}>
                      <Grid container spacing={4}>
                        {Recepies?.map((offer, index) => (
                          
                          
                          <Recepy
                            name={offer.name}
                            description={offer.description}
                            image={"https://images.pexels.com/photos/1640777/pexels-photo-1640777.jpeg"}
                            imageLabel={"Sveikas"}
                            duration={offer.duration}
                            key={index}
                            id={offer.id} />
                        ))
                        }
                      </Grid>
                    </Grid>
                  </Grid>
                </Box>
              </main>
            </Container>
          </ThemeProvider>
          <Box component="span" sx={{ p: 2 }}>
      
    </Box>
        </>
      );
    };
    
    export default Recepies;