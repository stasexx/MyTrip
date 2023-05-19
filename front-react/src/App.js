import "./styles/main.css"; 
import NavBar from "./Components/navbar/NavBar"
import MainPge from "./pages/MainPage/MainPage"
import Cabinet from "./pages/Cabinet/Cabinet"
import Footer from "./Components/footer/Footer"
import {BrowserRouter as Router,Routes,Route} from "react-router-dom"
function App() {

  return (
    
    <div className="App">
      <Router>

        <NavBar/>
          <Routes>
              <Route path="/" element={<MainPge/>}/>
              <Route path="/cabinet" element={<Cabinet/>}/>
          </Routes>

        <Footer/>

      </Router>
    </div>
  );
}

export default App;
