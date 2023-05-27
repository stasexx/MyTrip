import React, {useEffect, useState} from "react";
import axios from 'axios';
import NavBar from "../../Components/navbar/NavBar";
import Footer from "../../Components/footer/Footer"
import styles from './Stules.module.css';
import { useParams } from "react-router-dom";
import Scrollable from "./Scrollable";
import StRating from './rating';

import wish_button from "./../../img/icon/wish_button.png";
const src="http://localhost:5000/api/Tours/get/allTours";
/*http://localhost:5000/api/Reviews/get/reviews/tourId=3*/
const  TourPage = () => {
const {id}=useParams();
var MyTour;
var startDatefinal;
var endDatefinal;
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

            let startDateString = MyTour.startDate;
            let startDate = new Date(startDateString);
            let day = startDate.getDate();
            let month = startDate.getMonth() + 1;
            let year = startDate.getFullYear();
            var startDatefinal=`${day < 10 ? '0' + day : day}.${month < 10 ? '0' + month : month}.${year}`;

            let endDateString = MyTour.endDate;
            let endDate = new Date(endDateString);
            day = endDate.getDate();
            month = endDate.getMonth() + 1;
            year = endDate.getFullYear();
            var endDatefinal=`${day < 10 ? '0' + day : day}.${month < 10 ? '0' + month : month}.${year}`;

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
            <div className={styles.container}>
                    <div className={styles.name_tour}>{MyTour.name}</div>
                    
                    <div className={styles.info_orh}>
                        <div className={styles.name_org} >TrapStar</div><div className={styles.delimiter}>●</div><StRating rate={MyTour.rate}/><div className={styles.delimiter}>●</div> 978 reviews<div className={styles.delimiter}>●</div>+25 Exp <div className={styles.delimiter}>●</div> mail@mail.com
                    </div>    
            </div>
            <div className={styles.infoo__tour}>
                    <div className={styles.container}>

                        <img className={styles.foto_tour} src={MyTour.mainPhoto} alt="Link"/>
                        <div className={styles.text_tour} >

                        
                            <div>Begin: {startDatefinal}</div>
                            <div>End: {endDatefinal}</div>
                            <div>Category: {MyTour.category}</div>
                            <div className={styles.price}>300$</div>
                            <label href="#" className={styles.link_tour}>Purchase</label>
                        </div>
                    </div> 
            </div>

            <div className={styles.container}>

                <div className={styles.description}>{MyTour.description}</div>

                <div className="all_photo">

                <Scrollable _class='items'>

                </Scrollable>

                </div>

                            
            </div>

            <div className={styles.font_picture}></div>
            
            <Footer/>
        </>           
               
    );

}
 
export default TourPage;