import "./styles/main.css"; 
import NavBar from "./Components/navbar/NavBar"
import MainPge from "./pages/MainPage"
import Footer from "./Components/footer/Footer"
import React, {useEffect, useState} from "react";
import axios from 'axios';
function App() {
  const[tour,setTours] = useState();
  
  useEffect(()=>{
    axios.get("")
  })

  return (
    
    <div className="App">
        <NavBar />
        <MainPge/>
        <Footer/>
    </div>
  );
}

export default App;
