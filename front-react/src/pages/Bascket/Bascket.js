import React, {useEffect, useState} from "react";
import axios from 'axios';
import NavBar from "../../Components/navbar/NavBar";
import Footer from "../../Components/footer/Footer"
import styles from './Stules.module.css';
import { useParams } from "react-router-dom";


const  Bascket = () => {
    const {id}=useParams();
    const[tour,setTours] = useState([]);
    const[org,setOrg] = useState([]);
    const[user,setUser] = useState([]);

    useEffect(()=>{
        axios.get(`http://localhost:5000/api/Tours/get/toursById=${id}`)
        .then(data =>{
            setTours(data.data);
        })
        },[]);


    var user_id = localStorage.getItem("login");

        useEffect(()=>{
            if(user_id){
                axios.get(`http://localhost:5000/api/Users/get/userById=${id}`)
                .then(data =>{
                    setUser(data.data);
                })
            }
        
        },[]);






    useEffect(()=>{

            axios.get(`http://localhost:5000/api/OrgTour/get/orgTourByTourId/tourId=${id}`)

            .then(function(response){
                setOrg(response.data)
            })
            .catch(function(error) {
                console.log(error)
            })
        },[]);


        const currentDate = new Date();
        const year = currentDate.getFullYear();
        const month = String(currentDate.getMonth() + 1).padStart(2, '0');
        const day = String(currentDate.getDate()).padStart(2, '0');
        const formattedDate = `${year}-${month}-${day} 00:00:00`;

        var startDatefinal=`${day}.${month}.${year}`;

        if(tour){


            let startDateString = tour.startDate;
            let startDate = new Date(startDateString);
            let day = startDate.getDate();
            let month = startDate.getMonth() + 1;
            let year = startDate.getFullYear();
            var startDatefinal=`${day < 10 ? '0' + day : day}.${month < 10 ? '0' + month : month}.${year}`;

            let endDateString = tour.endDate;
            let endDate = new Date(endDateString);
            day = endDate.getDate();
            month = endDate.getMonth() + 1;
            year = endDate.getFullYear();
            var endDatefinal=`${day < 10 ? '0' + day : day}.${month < 10 ? '0' + month : month}.${year}`;

        }else{
            return <h1>...Loading</h1>  
        }


return(
    <>
     <NavBar/>
    
            <div className={styles.infoo__tour}>
                    <div className={styles.container}>

                        <img className={styles.foto_tour} src={tour.mainPhoto} alt="Link"/>
                        <div className={styles.name}>{tour.name}</div>
                        <div className={styles.text_tour} >
                    
                            <div className={styles.price}>{org.price}$</div>
                            <div className={styles.data}>Order date: {startDatefinal}</div>
                        </div>
                    </div> 
            </div>


            <div className={styles.text_tour_data} >
                        <div className={styles.container}>

                            <div className={styles.user_buy}>Ordered by: {user.lastName} {user.firstName} <label className={styles.promocod}>Promocode: <input  type ="text" className={styles.box} id="password" placeholder="Enter your promocode"></input></label></div>
                            <div className={styles.begin}>Tour begin: {startDatefinal}</div>
                            <div className={styles.end}>Tour end: {endDatefinal}</div>
                            <a href="#" className={styles.link_create_tour}>Pay with MonoPay</a>
                        </div>
                    </div> 
        <Footer/>
    </>
)

}
export default Bascket;