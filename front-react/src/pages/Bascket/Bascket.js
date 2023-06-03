import React, {useEffect, useState} from "react";
import axios from 'axios';
import NavBar from "../../Components/navbar/NavBar";
import Footer from "../../Components/footer/Footer"
import styles from './Stules.module.css';
import { useParams } from "react-router-dom";
import { SHA1 } from 'crypto-js';
import { enc } from 'crypto-js';

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


        var json_string = `{"public_key":"sandbox_i59238924040","version":"3","action":"pay","amount":"${org.price}","currency":"UAH","description":"test","order_id":"000001"}`;
        var data = btoa(json_string);
        
        console.log(data);

        const sign_string = "sandbox_tJi2z6e5iVHPcfx4x5if1Xb8S0YPmv4Wzv50reUI"+data+"sandbox_tJi2z6e5iVHPcfx4x5if1Xb8S0YPmv4Wzv50reUI";

        console.log(sign_string);

        // Обчислення SHA1 хешу
        var sha1_hash = SHA1(sign_string);

        // Перетворення хешу у рядок
        var sha1_hash_string = sha1_hash.toString(enc.Hex);

        // Кодування у Base64
        var signature  = enc.Base64.stringify(enc.Hex.parse(sha1_hash_string));

        console.log(signature );
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


                            <form method="POST" accept-charset="utf-8" action="https://www.liqpay.ua/api/3/checkout">

                            <input type="hidden" name="data" value={data} />

                            <input type="hidden" name="signature" value={signature} />

                            <button >
                                <a  className={styles.link_create_tour}>Pay with LIQPAY</a>
                            </button>

                            </form>
                            
                        </div>
                    </div> 
        <Footer/>
    </>
)

}
export default Bascket;