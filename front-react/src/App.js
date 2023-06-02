import "./styles/main.css"; 
import NavBar from "./Components/navbar/NavBar"
import MainPge from "./pages/MainPage/MainPage"
import Login from "./pages/Login/Login"
import Cabinet from "./pages/Cabinet/Cabinet"
import Bascket from "./pages/Bascket/Bascket";
import Register from "./pages/Register/Register"
import {BrowserRouter as Router,Routes,Route} from "react-router-dom";
import TourPage from "./pages/TourPage/TourPage";
import HandTourPage from "./pages/HandTourPage/HandTourPage";
import Wishlist from "./pages/WashList/WashList";
import MyTour from "./pages/MyTour/MyTour";
import MyOrders from "./pages/MyOrders/MyOrders";
function App() {

  const cors = require("cors");


  return (
    
    <div className="App">
      <Router>
             <Routes>
              <Route path="/register" element={<Register/>}/>
              <Route path="/login" element={<Login/>}/>
              <Route path="/tour/orh/:id" element={<TourPage/>}/>
              <Route path="/tour/hdm/:id" element={<HandTourPage/>}/>
              <Route path="/" element={<MainPge/>}/>
              <Route path="/cabinet" element={<Cabinet/>}/>
              <Route path="/tour/orh/:id/bascket" element={<Bascket/>}/>
              <Route path="/cabinet/wishlist" element={<Wishlist/>}/>
              <Route path="/cabinet/myorders" element={<MyOrders/>}/>
              
          </Routes>
      </Router>
    </div>
  );
}

export default App;
