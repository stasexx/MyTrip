
import basket from "./../../img/icon/basket.png"
import wishlist from "./../../img/icon/wish_list.png"
import my_tour from "./../../img/icon/my-tour.png"
import tour_photo from "../../img/icon/extreme.png"
import styles from './Stules.module.css';
import React, {useEffect, useState} from "react";
import NavBar from "../../Components/navbar/NavBar";
import Footer from "../../Components/footer/Footer"
import axios from 'axios';
import Tour_wishlist from "../../Components/tour_wishlist/tour_wishlist"
import profile from "../../img/icon/6554725.png"
import Tour_user from "../../Components/tour_cabinet/tour_cabinet"

const MyOrders = () => {

    var user_id = localStorage.getItem("login");
    const[tour,setTour] = useState([]);
    const[id_tour,setIdTour] = useState([]);


        useEffect(()=>{

        axios.get(`http://localhost:5000/api/Users/get/userById=${user_id}`)
        .then(data =>{

            axios.get(`http://localhost:5000/api/WishList/get/wishList/email=${data.data.email}`)
            .then(data =>{
            setTour(data.data);
            })
        })
 
        },[]);


        useEffect(()=>{

            axios.get(`http://localhost:5000/api/Users/get/getAllToursIdForUser/userId=${user_id}`)
            .then(data =>{
                setIdTour(data.data);
            })
            
            },[]);
    

    
    return ( 
        <>
        <NavBar/>
        <div className={styles.container}>

        

                <div className={styles.buttons}>
                    <ul className={styles.btn_list}>
                        <li className={styles.btn_list__item}><a href="/cabinet" className={styles.btn_list__link}><img src={profile} className={styles.icon_btn} alt=""/>Profile</a></li>
                        <li className={styles.btn_list__item}><a href="/cabinet/wishlist" className="btn-list__link"><img src={wishlist} className={styles.icon_btn} alt=""/>Wish list</a></li>
                        <li className={styles.btn_list__item}><a href="/cabinet/mytour" className={styles.btn_list__link}><img src={my_tour} className={styles.icon_btn} alt=""/>My tour</a></li>
                    </ul>
                </div>

                <div className={styles.last}>
                    <h1 className={styles.last_header}>All tours ordered by you</h1>


                    {
                        id_tour.map(item1 =>{

                            return<Tour_user tour_id={item1}/>;
                        })
                    }



                </div>

        </div>
        <Footer/>
        </>
     );
}
 
export default MyOrders;