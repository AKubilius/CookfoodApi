import {AppBar,Toolbar,IconButton,Typography,Button,Menu,MenuItem} from '@mui/material'
import RestaurantIcon from '@mui/icons-material/Restaurant'
import { Stack } from '@mui/system'

export const Navbar = () => {
  return (
    <AppBar position='static' sx={{bgcolor:'secondary.main'}}>
        <Toolbar>
            <IconButton size='large' edge='start'  aria-label='logo'>
                <RestaurantIcon/>
            </IconButton>
            <Typography variant ='h6'  component='div' sx={{flexGrow:1}}>
                CookFood
            </Typography>
            <Stack direction='row' spacing={2}>
                <Button color='inherit'>RecipeSets</Button>
                <Button color='inherit'>Recipes</Button>
                <Button color='inherit'>About</Button>
                <Button color='inherit'>Login</Button>
            </Stack>

        </Toolbar>
        </AppBar>
  )
}
