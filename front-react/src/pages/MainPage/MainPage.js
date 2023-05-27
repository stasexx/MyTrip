import Tour from "../../Components/tour/Tour";
import news from "./../../img/icon/news.png";
import foto_create_tour from "./../../img/icon/foto_create_tour.png";
import extreme from "./../../img/icon/extreme.png";
import entertain from "./../../img/icon/entertain.png";
import shopping from "./../../img/icon/shopping.png";

import React, {useEffect, useState} from "react";
import axios from 'axios';
import NavBar from "../../Components/navbar/NavBar";
import Footer from "../../Components/footer/Footer"
import styles from './Stules.module.css';
const src="http://localhost:5000/api/Tours/get/allTours";


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
        

        <main className={styles.section}>
            <NavBar/>
                <div className={styles.container}>
                    <img className={styles.news} src={news} alt="Link"/>
                    <h2 className={styles.text_header}>Popular Tour</h2>
                    <ul className={styles.tours}>    
                        {
                            tour_pop.map(item =>{
                            return<Tour name={item.name} main_photo={item.mainPhoto} rate={item.rate} tourId={item.tourId}/>;
                             })
                        }

                    </ul>
                    <a href="#" className={styles.link_pop_tour}>SHOW MORE</a>

                    <h2 className={styles.text_header}>Hand made tours</h2>
                    <ul className={styles.tours}>    
                        {
                            tour_hand.map(item1 =>{
                                if(item1.typeOfTour=="hdm"){

                                    return<Tour name={item1.name} main_photo={item1.mainPhoto} rate={item1.rate} tourId={item1.tourId}/>;
                            
                                }
                            })
                        }
                    </ul>
                    <a href="#" className={styles.link_pop_tour}>SHOW MORE</a>
                </div>

                <div className={styles.create__tour}>
                    <div className={styles.container}>
                        <img className={styles.foto_create_tour} src={foto_create_tour} alt="Link"/>
                        
                            <div className={styles.text_create_tour} ><strong>Make your own adventure</strong> Using our tour redactor you can create your 
                                own unforgettable journey for you and your friends and family. 
                                Go ahead! It’s adventure time!

                                <label href="#" className={styles.link_create_tour}>Create</label>
                            </div>
                    </div> 
                </div>
                
                <div className={styles.container}>
                    <h2 class={styles.text__categories}>Experience best tours you can have</h2>
                    <ul class={styles.tours}>  
                        <li className={styles.tour_categories}>
                            <a href="./project-page.html">
                                <img src={extreme} alt="Project img" className={styles.tour__img}/>
                                <h3 className={styles.categories__title}>Extreme</h3>
                            </a>
                        </li>
                        <li className={styles.tour_categories}>
                            <a href="./project-page.html">
                                <img src={entertain} alt="Project img" className={styles.tour__img}/>
                                <h3 className={styles.categories__title}>Entertain</h3>
                            </a>
                        </li>
                        <li className={styles.tour_categories}>
                            <a href="./project-page.html">
                                <img src={shopping} alt="Project img" className={styles.tour__img}/>
                                <h3 className={styles.categories__title}>Shopping</h3>
                            </a>
                        </li>
                    </ul>
                </div>
                <Footer/>
        </main>
        
);
}
 
export default MainPge;