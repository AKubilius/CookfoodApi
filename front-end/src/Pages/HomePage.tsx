import MobNavbar from "../components/Navbar/MobNavbar";
import {Banner} from "../components/Banner/Banner"
import Recepies from "../components/Recepy/Recepies";
import Paper from "../components/Banner/Paper"


const HomePage = () => {
  return (
    <div>
    <MobNavbar />
    <Recepies/>
    <Paper/>
    </div>
    
  )
}

export default HomePage