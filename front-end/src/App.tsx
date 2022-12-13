import './App.css';
import { Navbar } from './components/Navbar/Navbar';
import MobNavbar from "./components/Navbar/MobNavbar"
import { Banner } from './components/Banner/Banner';
import {createTheme,colors} from '@mui/material'

const theme = createTheme({
  palette:{
    secondary:{
      main: colors.brown[200]
    }
  }
})

function App() {
  return (
    <div className="App">
     <MobNavbar/>
     <Banner/>

    </div>
  );
}

export default App;
