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
        {tour_hand=tour_hand.slice(0, 3)}
 
    return ( 
        
        <main className="section">
                <div className="container">
                    <img className="news" src={news} alt="Link"/>
                    <h2 class="text-header">Popular Tour</h2>
                    <ul class="tours">    
                        {
                            tour_pop.map(item =>{
                            return<Tour name={item.name} main_photo={item.mainPhoto} rate={item.rate}/>;
                             })
                        }

                    </ul>
                    <a href="#" className="link_pop_tour">SHOW MORE</a>

                    <h2 class="text-header">Hand made tours</h2>
                    <ul class="tours">    
                        {
                            tour_hand.map(item1 =>{
                                if(item1.typeOfTour=="hdm"){

                                    return<Tour name={item1.name} main_photo={item1.mainPhoto} rate={item1.rate}/>;
                            
                                }
                            })
                        }
                    </ul>
                    <a href="#" className="link_pop_tour">SHOW MORE</a>
                </div>

                <div className="create__tour">
                    <div className="container">
                        <img className="foto_create_tour" src={foto_create_tour} alt="Link"/>
                        
                            <div className="text_create_tour" ><strong>Make your own adventure</strong> Using our tour redactor you can create your 
                                own unforgettable journey for you and your friends and family. 
                                Go ahead! It’s adventure time!

                                <label href="#" className="link_create_tour">Create</label>
                            </div>
                    </div> 
                </div>
                <div className="container">
                    <h2 class="text__categories">Experience best tours you can have</h2>
                    <ul class="tours">  
                        <li className="tour_categories">
                            <a href="./project-page.html">
                                <img src={extreme} alt="Project img" className="tour__img"/>
                                <h3 className="categories__title">Extreme</h3>
                            </a>
                        </li>
                        <li className="tour_categories">
                            <a href="./project-page.html">
                                <img src={entertain} alt="Project img" className="tour__img"/>
                                <h3 className="categories__title">Entertain</h3>
                            </a>
                        </li>
                        <li className="tour_categories">
                            <a href="./project-page.html">
                                <img src={shopping} alt="Project img" className="tour__img"/>
                                <h3 className="categories__title">Shopping</h3>
                            </a>
                        </li>
                    </ul>
                </div>

                




        </main>
        
);
}
 
export default MainPge;