import React, {useEffect, useState} from "react";
import axios from 'axios';
import NavBar from "../../Components/navbar/NavBar";
import Footer from "../../Components/footer/Footer"
import styles from './Stules.module.css';
import { useParams } from "react-router-dom";

import StRating from './rating';

import wish_button from "./../../img/icon/wish_button.png";
const src="http://localhost:5000/api/Tours/get/allTours";

const  TourPage = () => {
const {id}=useParams();
var MyTour;

    const[tour,setTours] = useState([]);
    useEffect(()=>{
        axios.get(src)
        .then(data =>{
        setTours(data.data);
        })
        },[]);
        if(tour[0]){
            for(let i = 0;i<tour.length;i++){
                if(tour[i].tourId==id){
                    MyTour=tour[i];
                    break;
                }
            }

        }else{
            return <h1>...Loading</h1>  
        }

        function show(e) {

            var btn = document.getElementById(2);
    
            btn.addEventListener("click", function() {
                if(this.classList.contains('wish')){
                    this.classList.remove('wish');
                }else {
                    this.classList.add('wish');
                }
            });
        }


        return ( /*
            <main className={styles.senctiom}>
                <NavBar/>

                    <li id="dfg"className={styles.tour}>
                        <a href="">
                            <img src={MyTour.mainPhoto} alt="Project img" className={styles.tour__img}/>
                            <h3 className={styles.tour__title}>{MyTour.name}</h3>
                            <div className={styles.tour__rating}><StRating rate={MyTour.rate}/></div>
                        </a>
                        <a id="2" className={styles.wishlist} onClick={show} >
                            <img src={wish_button} alt="" className={styles.like__img}/>
                        </a>
                    </li>
                <Footer/>
            </main>    */
        <>
            <NavBar/>
            <div className="container">
                <div className={styles.name_tour}>{MyTour.name}</div>
                <div className={styles.info_orh}><strong>TrapStar</strong> ● <StRating rate={MyTour.rate}/>  ● 978 reviews  ● +25 Exp  ● mail@mail.com</div>  

            </div>
            <div className="font_picture"></div>
            
            <Footer/>
        </>           
               
    );

}
 
export default TourPage;