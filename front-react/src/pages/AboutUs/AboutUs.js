import React from 'react';
import NavBar from '../../Components/navbar/NavBar';
import Footer from '../../Components/footer/Footer';
import Rectangle_about from "./../../img/icon/Rectangle_about.png";

const About = () => {

    return (
            <>
                <NavBar/>
                <img src={Rectangle_about}/>
                <Footer/>
            </>
    );
  };
  
  export default About;