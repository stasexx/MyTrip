import styles from './Stules.module.css';
import wish_button from "./../../img/icon/image 49.png";
import React, {useEffect, useState} from "react";
import axios from 'axios';

const Tour_wishlist = ({name, main_photo, rate,tourId,typeOfTour,category}) => {

    const [isActive, setIsActive] = useState(false);

    const[user,setUser] = useState([]);

    var user_id = localStorage.getItem("login");

        useEffect(()=>{
            if(user_id){
                axios.get(`http://localhost:5000/api/Users/get/userById=${user_id}`)
                .then(data =>{
                    setUser(data.data);
                })
            }
        
        },[]);





    function show(e) {
            axios.post(`http://localhost:5000/api/WishList/delete/favourite/tourId=${tourId}/email=${user.email}`)
            .then(alert("Успішно видалино з обраних"))
            .catch((error) => alert(error));
            window.location.reload();
      }

    return ( 

        <li id="dfg"className={styles.tour}>
            <a href={`/tour/${typeOfTour}/${tourId}`}>
                <img src={main_photo} alt="Project img" className={styles.tour__img}/>
                <h3 className={styles.tour__title}>{name}</h3>
                <h3 className={styles.tour__title}>{category}</h3>
                
            </a>
            <a id={tourId} className={`${styles.wishlist} ${isActive ? styles.wish : styles.wish_not}`} onClick={show}>
                    <img src={wish_button} alt="" className={styles.like__img} />
            </a>
        </li>
    );
}
 
export default Tour_wishlist;