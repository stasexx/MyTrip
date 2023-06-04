
import styles from './Stules.module.css';
import React, {useEffect, useState} from "react";
import NavBar from "../../Components/navbar/NavBar";
import Footer from "../../Components/footer/Footer"
import axios from 'axios';
import {useNavigate} from 'react-router-dom';
import { Swiper, SwiperSlide } from 'swiper/react';
import 'swiper/css';
import 'swiper/css/effect-coverflow';
import 'swiper/css/pagination';
import "swiper/css/autoplay";
import 'swiper/css/navigation';

import slide1 from "./../../img/icon/slide1.png";
import slide2 from "./../../img/icon/slide2.png";
import slide3 from "./../../img/icon/slide3.png";
import slide4 from "./../../img/icon/slide4.png";
import Tour from "../../Components/tour_for_catalog/tour_for_catalog";

import SwiperCore, { Pagination, Navigation, Autoplay } from 'swiper';

import search_glass from "./../../img/icon/glass_search.png";
const Catalog = () => {



    const[tour,setTours] = useState([]);
  
        useEffect(()=>{
        axios.get("http://localhost:5000/api/Tours/get/allTours")
        .then(data =>{
        setTours(data.data);
        })
        },[]);

    const navigate = useNavigate();

    const [showEurope, setShowEurope] = useState(false);
    const [showNAmerica, setShowNAmerica] = useState(false);
    const [showSAmerica, setShowSAmerica] = useState(false);
    const [showAfrica, setShowAfrica] = useState(false);
    const [showOceania, setShowOceania] = useState(false);
   
    useEffect(() => {
        SwiperCore.use([Autoplay])
      }, []);


      function open(e){
        const id = e.target.id;
        var img = document.getElementById(id);
        if (id === "1") {
          setShowEurope(!showEurope);
          if(showEurope){
            img.style.color='#000000'
          }else
          img.style.color='#FF9635'
        } else if (id === "2") {
          setShowNAmerica(!showNAmerica);
          if(showNAmerica){
            img.style.color='#000000'
          }else
          img.style.color='#FF9635'
        } else if (id === "3") {
          setShowSAmerica(!showSAmerica);
          if(showSAmerica){
            img.style.color='#000000'
          }else
          img.style.color='#FF9635'
        } else if (id === "4") {
          setShowAfrica(!showAfrica);
          if(showAfrica){
            img.style.color='#000000'
          }else
          img.style.color='#FF9635'
        }else if (id === "4") {
          setShowAfrica(!showAfrica);
          if(showAfrica){
            img.style.color='#000000'
          }else
          
          img.style.color='#FF9635'
        }else if(id === "255"){
          axios.get("http://localhost:5000/api/Tours/get/allTours")
          .then(data =>{
          setTours(data.data);
          })
        }
        
      }
      function change_cat(e){
        const id = e.target.id;

        if (id === "21") {
          
          axios.get("http://localhost:5000/api/Tours/get/tourFilter/category=Excursion")
          .then(data =>{
          setTours(data.data);
          })


        } else if (id === "22") {
          axios.get("http://localhost:5000/api/Tours/get/tourFilter/category=Wedding%20tours")
          .then(data =>{
          setTours(data.data);
          })


        } else if (id === "23") {
          axios.get("http://localhost:5000/api/Tours/get/tourFilter/category=Travels%20in%20Ukraine")
          .then(data =>{
          setTours(data.data);
          })

        } else if (id === "24") {
          axios.get("http://localhost:5000/api/Tours/get/tourFilter/category=Romantic")
          .then(data =>{
          setTours(data.data);
          })

        }else if (id === "25") {
          axios.get("http://localhost:5000/api/Tours/get/allTours")
          .then(data =>{
          setTours(data.data);
          })
        }
      }


      function city(e){
        const id = e.target.id;

        if (id === "31") {
          
          axios.get("http://localhost:5000/api/Tours/get/tourFilter/country=London")
          .then(data =>{
          setTours(data.data);
          })


        } else if (id === "32") {
          axios.get("http://localhost:5000/api/Tours/get/tourFilter/country=Paris")
          .then(data =>{
          setTours(data.data);
          })


        } else if (id === "33") {
          axios.get("http://localhost:5000/api/Tours/get/tourFilter/country=Italy")
          .then(data =>{
          setTours(data.data);
          })

        } else if (id === "34") {
          axios.get("http://localhost:5000/api/Tours/get/tourFilter/country=Egypt")
          .then(data =>{
          setTours(data.data);
          })

        }else if (id === "255") {
          axios.get("http://localhost:5000/api/Tours/get/allTours")
          .then(data =>{
          setTours(data.data);
          })
        }
      }

      
    return ( 
        <>
        <NavBar/>
            <div className={styles.tours_text}>TOURS</div>
            <div className={styles.container}>
                <div className={styles.all_photo}>

                    
                <Swiper
                speed={5000}
                centeredSlides={true}
                slidesPerView= {1}
                loop={true}
                autoplay={{
                    delay: 5000,
                    disableOnInteraction: false,
                }}
                className="swiper_container"
                >
                <SwiperSlide>
                    <img src={slide1} alt="slide_image" />
                </SwiperSlide>
                <SwiperSlide>
                    <img src={slide2} alt="slide_image" />
                </SwiperSlide>
                <SwiperSlide>
                    <img src={slide3} alt="slide_image" />
                </SwiperSlide>
                <SwiperSlide>
                    <img src={slide4} alt="slide_image" />
                </SwiperSlide>
                </Swiper>

                </div>
        
                <div className ={styles.search}>Search options</div>
                <div className ={styles.search_box}>
                    <a className={styles.search_btn} href="#"><img className={styles.icon_header} src={search_glass} alt="Link"/></a>
                <input className={styles.search_tour} type ="text" name="" placeholder="Search tours"></input>
                </div>
                <div>
                    <ul className ={styles.name_filter}>

                        <li className ={styles.Category}>Category
                            <ul className ={styles.cat_filter}>
                                <li id="25" onClick={change_cat}className ={styles.under_cat_filter}>All</li>
                                 <li id="21" onClick={change_cat} className ={styles.under_cat_filter}>Excursion</li>
                                 <li id="22" onClick={change_cat} className ={styles.under_cat_filter}>Wedding tours</li>
                                 <li id="23" onClick={change_cat} className ={styles.under_cat_filter}>Travels in Ukraine</li>
                                 <li id="24" onClick={change_cat}className ={styles.under_cat_filter}>Romantic</li>
                            </ul>
                        </li>

                        <li className ={styles.Price}>Price</li>
                        <li className ={styles.Parts}>Parts of the world
                        
                            <ul className ={styles.part_filter}>

                                <li id="255" onClick={city}className ={styles.under_cat_filter}>All</li>
                                 <li id="1" onClick={open} className ={styles.under_part_filter}>Europe →      
                                 {showEurope && (     
                                    <ul className ={styles.under_filter}>
                                        <li id="31"onClick={city} className ={styles.under_part}>London</li>
                                        <li id="32" onClick={city} className ={styles.under_part}>Paris</li>
                                        <li id="33" onClick={city} className ={styles.under_part}>Italy</li>   
                                    </ul>
                                    )}
                                 </li>

                                 <li id="2" onClick={open} className ={styles.under_part_filter}>North America →
                                 {showNAmerica && (
                                    <ul className ={styles.under_filter}>
                                        <li   className ={styles.under_part}>Canada</li>
                                        <li className ={styles.under_part}>USA</li>
                                        <li className ={styles.under_part}>Mexico</li>   
                                    </ul> 
                                    )}
                                 </li>

                                 <li id="3" onClick={open} className ={styles.under_part_filter}>South America →
                                 {showSAmerica && (
                                    <ul className ={styles.under_filter}>
                                        <li className ={styles.under_part}>Brazil</li>
                                        <li  className ={styles.under_part}>Argentina</li>
                                        <li  className ={styles.under_part}>Ecuador</li>   
                                    </ul> 
                                  )} 
                                 </li>

                                 <li id="4" onClick={open}  className ={styles.under_part_filter}>Africa →
                                    {showAfrica && (
                                        <ul className={styles.under_filter}>
                                          <li id="34" onClick={city} className={styles.under_part}>Egypt</li>
                                          <li className={styles.under_part}>CAR</li>
                                          <li  className={styles.under_part}>Madagascar</li>
                                        </ul>
                                    )}
                                 </li>
                                 <li className ={styles.under_part_filter}>Oceania</li>    
                            </ul>
                        
                        
                        </li>
                    </ul>

                    <ul className ={styles.price_filter}>
                  
                        <li className ={styles.price_filter_from}><input type ="text" name="" placeholder="from"></input></li>
                        <li className ={styles.price_filter_to}><input type ="text" name="" placeholder="to"></input></li>

                    </ul>

                </div>
                

                <ul className={styles.tours}>    
                        {
                            tour.map(item1 =>{
                                

                                    return<Tour name={item1.name} main_photo={item1.mainPhoto} rate={item1.rate} tourId={item1.tourId} typeOfTour={item1.typeOfTour}/>;
                            
                                
                            })
                        }
                </ul>



            </div>

        <Footer/>
        </>
     );
}
 
export default Catalog;