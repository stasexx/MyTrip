import "./styles/main.css"; 
import NavBar from "./Components/navbar/NavBar"
import MainPge from "./pages/MainPage"
import Footer from "./Components/footer/Footer"

function App() {

  return (
    
    <div className="App">
        <NavBar/>
        <MainPge/>
        <Footer/>
    </div>
  );
}

export default App;
