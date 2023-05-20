import "./styles/main.css"; 
import NavBar from "./Components/navbar/NavBar"
import MainPge from "./pages/MainPage/MainPage"
import Login from "./pages/Login/Login"
import Cabinet from "./pages/Cabinet/Cabinet"
import {BrowserRouter as Router,Routes,Route} from "react-router-dom"
function App() {

  return (
    
    <div className="App">
      <Router>
             <Routes>
              <Route path="/login" element={<Login/>}/>
              <Route path="/" element={<MainPge/>}/>
              <Route path="/cabinet" element={<Cabinet/>}/>
          </Routes>
      </Router>
    </div>
  );
}

export default App;
