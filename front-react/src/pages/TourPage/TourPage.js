import React, {useEffect, useState} from "react";
import axios from 'axios';
import NavBar from "../../Components/navbar/NavBar";
import Footer from "../../Components/footer/Footer"
import styles from './Stules.module.css';
import { useParams } from "react-router-dom";
const src="https://localhost:5000/api/Tours/get/allTours";

const  TourPage = () => {
const {id}=useParams();

    const[tour,setTours] = useState([]);
  
        useEffect(()=>{
        axios.get(src)
        .then(data =>{
            if(data.data.tourId===1)
        setTours(data.data);
        })

        },[]);
        {console.log(tour);}

    return ( 
        

        <main className={styles.senctiom}>
            <NavBar/>
               
            <Footer/>
        </main>
        
);
}
 
export default TourPage;