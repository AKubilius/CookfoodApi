import MobNavbar from "../components/Navbar/MobNavbar";
import {Banner} from "../components/Banner/Banner"
import UserRecepies from "../components/Recepy/UserRecepies";
import RForm from "../components/Recepy/RForm"

const HomePage = () => {
    const name = sessionStorage.getItem("name");
  return (
    <div>
    <MobNavbar />
    <UserRecepies/>
    {name ? (
 <RForm/>

  ) : (  <>
   
  </>
)}
    </div>
    
  )
}

export default HomePage