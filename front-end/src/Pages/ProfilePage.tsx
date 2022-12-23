import MobNavbar from "../components/Navbar/MobNavbar";
import Profile from "../components/Profile/Profile"
import RForm from "../components/Recepy/RForm"
import RecepySetForm from "../components/RecepySet/RecepySetForm"
import RecepyEdit from "../components/Recepy/RecepyEdit"

const LoginPage: React.FC = () => {
  const admin = sessionStorage.getItem("admin");
  return (
    <>
      <MobNavbar />
      <Profile/>

      {admin ==="false" ? (
 <RecepySetForm />

  ) : (  <>
   
  </>
)}


      
      
    </>
  );
};

export default LoginPage;