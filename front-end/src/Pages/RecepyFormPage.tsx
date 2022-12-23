import MobNavbar from "../components/Navbar/MobNavbar";
import {Banner} from "../components/Banner/Banner"
import Recepies from "../components/Recepy/Recepies";
import RecepyForm from "../components/Recepy/RecepyForm"
import RForm from "../components/Recepy/RForm"
import RecepySetForm from "../components/RecepySet/RecepySetForm"

const HomePage = () => {
  return (
    <div>
    <MobNavbar />
    <RecepySetForm />
    </div>
    
  )
}

export default HomePage