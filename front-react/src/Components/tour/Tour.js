import styles from './Stules.module.css';
import StRating from './rating';
import wish_button from "./../../img/icon/wish_button.png";
import wish_button_black from "./../../img/icon/wish_button_black.png";
import React, {useEffect, useState} from "react";
import axios from 'axios';

const Tour = ({name, main_photo, rate,tourId,typeOfTour}) => {

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
        if(isActive){
            setIsActive(false);
            axios.post(`http://localhost:5000/api/WishList/delete/favourite/tourId=${tourId}/email=${user.email}`)
            .then(alert("Успішно видалино з обраних"))
            .catch((error) => alert(error));
        }else{
            setIsActive(true);
            axios.post(`http://localhost:5000/api/WishList/create/newFavourite/tourId=${tourId}/email=${user.email}`)
            .then(alert("Успішно додали до обраних"))
            .catch((error) => alert(error));
            
        }
        console.log(isActive)
      }

    return ( 

        <li id="dfg"className={styles.tour}>
            <a href={`./tour/${typeOfTour}/${tourId}`}>
                <img src={decodeURIComponent(main_photo)} alt="Project img" className={styles.tour__img}/>
                <h3 className={styles.tour__title}>{name}</h3>
                <div className={styles.tour__rating}><StRating rate={rate}/></div>
            </a>
            <a id={tourId} className={`${styles.wishlist} ${isActive ? styles.wish : styles.wish_not}`} onClick={show}>
                    <img src={wish_button} alt="" className={styles.like__img} />
            </a>
        </li>
    );
}
 
export default Tour;