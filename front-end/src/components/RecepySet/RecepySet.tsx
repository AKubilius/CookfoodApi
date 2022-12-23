import {
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  Grid,
  Typography,
  IconButton
} from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete"
import Button from "@mui/material/Button";
import RecepySetEdit from "./RecepySetEdit";

const onDelete = async (ColId: number) => {
  var token = localStorage.getItem('accessToken');
  const response = await fetch(`https://localhost:7247/RecepySet/${ColId}`, {
      headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${sessionStorage.getItem("token")}`
      },
      method: 'DELETE'
  });
  console.log(response);
};

const admin = sessionStorage.getItem("admin");

interface IRecepySet {
  name: string;
  type: string;
  image: string;
  imageLabel: string;
  setId: number;
  
}
const path = window.location.pathname; 
console.log(path)

const RecepySet: React.FC<IRecepySet> = ({
  name,
  type,
  image,
  imageLabel,
  setId

}) => {
  return (
    <Grid item xs={12} md={6}>
      <CardActionArea component="a" href={"/recepyset/" + setId}>
        <Card sx={{ display: "flex" }}>
          <CardContent sx={{ flex: 1 }}>
            <Typography component="h2" variant="h5">
              {name}
            </Typography>
            <Typography variant="subtitle1" color="text.secondary">
            </Typography>
            <Typography variant="subtitle1" paragraph>
              {type}
            </Typography>
          </CardContent>
          <CardMedia
            component="img"
            sx={{ width: 160, display: { xs: "none", sm: "block" } }}
            image={image}
            alt={imageLabel}

          />
        </Card>
      </CardActionArea>


          {admin ==="true" || path==="/profile" && admin!==null ? (<>
 <IconButton edge="end" onClick={() => onDelete(setId)} aria-label="delete">
 <DeleteIcon />
</IconButton><RecepySetEdit props={setId}></RecepySetEdit></>

  ) : (  <>
   
    </>
  )}
  
  
  
       
       
      </Grid>
    );
  };

export default RecepySet;