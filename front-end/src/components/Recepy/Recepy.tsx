import {
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  Grid,
  IconButton,
  Typography,
} from "@mui/material";
import RecepyEdit from "./RecepyEdit";
import DeleteIcon from "@mui/icons-material/Delete"

const onDelete = async (ColId: number) => {
  var token = localStorage.getItem('accessToken');
  const response = await fetch(`https://localhost:7247/Recepy/${ColId}`, {
      headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${sessionStorage.getItem("token")}`
      },
      method: 'DELETE'
  });
  console.log(response);
};

const admin = sessionStorage.getItem("admin");
console.log(admin);

interface IRecepy {
  name: string;
  description: string;
  image: string;
  imageLabel: string;
  duration: number;
  id:number;
}

const path = window.location.pathname; 
let result = path.slice(0, 10);
console.log(path)
console.log(result)

const Recepy: React.FC<IRecepy> = ({
  name,
  description,
  image,
  imageLabel,
  duration,
  id
}) => {
  return (
    <Grid item xs={12} md={6}>
      <CardActionArea component="a" href="#">
        <Card sx={{ display: "flex" }}>
          <CardContent sx={{ flex: 1 }}>
            <Typography component="h2" variant="h5">
              {name}
            </Typography>
            <Typography variant="subtitle1" color="text.secondary">
              
            </Typography>
            <Typography variant="subtitle1" paragraph>
              {description}
            </Typography>
            <div className="travel-offer-details">
              
            </div>
            <Typography variant="subtitle1" color="primary">
              Daugiau
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

      {(admin ==="true" || result==="/recepyset" ) ? (<>
 <IconButton edge="end" onClick={() => onDelete(id)} aria-label="delete">
 <DeleteIcon />
</IconButton>
<RecepyEdit props={id}></RecepyEdit></>
  ) : (  <>
   
  </>
)}



     
     
    </Grid>
  );
};

export default Recepy;