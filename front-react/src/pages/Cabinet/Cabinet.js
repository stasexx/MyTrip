import Tour from "../../Components/tour/Tour";
import news from "./../../img/icon/news.png";
import foto_create_tour from "./../../img/icon/foto_create_tour.png";
import extreme from "./../../img/icon/extreme.png";
import entertain from "./../../img/icon/entertain.png";
import shopping from "./../../img/icon/shopping.png";
import "./style.css"; 
import React, {useEffect, useState} from "react";
import axios from 'axios';
const src="http://localhost:5000/Tours";

const  MainPge = () => {

/*  зчитування з бд
    const[tour,setTours] = useState([]);
  
        useEffect(()=>{
        axios.get(src)
        .then(data =>{
        setTours(data.data);
        })
        },[]);
        {var tour_pop=tour.sort((a, b) => b.rate > a.rate ? 1 : -1)}
        {tour_pop=tour.sort((a, b) => b.typeOfTour > a.typeOfTour ? 1 : -1)}
        {tour_pop=tour_pop.slice(0, 3)}

        {var tour_hand=tour.sort((a, b) => b.typeOfTour < a.typeOfTour ? 1 : -1)}
        {tour_hand=tour_hand.slice(0, 3)}*/
 
    return ( 
        <>
        
        <div>hello mytrip</div>
        
        </>
    
        
);
}
 
export default MainPge;