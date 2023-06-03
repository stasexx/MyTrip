
import edit from "./../../img/icon/edit_icon.png"
import exit from "./../../img/icon/exit_icon.png"
import basket from "./../../img/icon/basket.png"
import wishlist from "./../../img/icon/wish_list.png"
import my_tour from "./../../img/icon/my-tour.png"
import tour_photo from "../../img/icon/extreme.png"
import styles from './Stules.module.css';
import React, {useEffect, useState} from "react";
import NavBar from "../../Components/navbar/NavBar";
import Footer from "../../Components/footer/Footer"
import axios from 'axios';
import Tour_user from "../../Components/my tour/my_tour"
import profile from "../../img/icon/6554725.png"

const MyTour = () => {
    const user_id = localStorage.getItem("login");
    const [id_tour, setIdTour] = useState([]);
    const [future, setFuture] = useState([]);
    const [last, setLast] = useState([]);
  
    useEffect(() => {
      const fetchData = async () => {
        try {
          const response = await axios.get(`http://localhost:5000/api/Users/get/getAllToursWitchCreateBydUser/userId=${user_id}`);
          setIdTour(response.data);
  
          const futureTours = [];
          const lastTours = [];
  
          for (const tourId of response.data) {
            const tourResponse = await axios.get(`http://localhost:5000/api/Tours/get/toursById=${tourId}`);
            const tourStartDate = new Date(tourResponse.data.startDate);
  
            if (tourStartDate > currentDate) {
              futureTours.push(tourId);
            } else if (tourStartDate < currentDate) {
              lastTours.push(tourId);
            }
          }
  
          setFuture(futureTours);
          setLast(lastTours);
        } catch (error) {
          console.log(error);
        }
      };
  
      fetchData();
    }, []);
  
    const currentDate = new Date();
    const year = currentDate.getFullYear();
    const month = String(currentDate.getMonth() + 1).padStart(2, '0');
    const day = String(currentDate.getDate()).padStart(2, '0');
    const formattedDate = `${year}-${month}-${day} 00:00:00`;
  
    return ( 
        <>
        <NavBar/>


        <div className="buttons">
            <ul className="btn-list">
            <li className={styles.btn_list__item}><a href="/cabinet" className={styles.btn_list__link}><img src={profile} className={styles.icon_btn} alt=""/>Profile</a></li>
                <li className="btn-list__item"><a href="/cabinet/myorders" className="btn-list__link"><img src={basket} className="icon_btn" alt=""/>My orders</a></li>
                <li className="btn-list__item"><a href="/cabinet/wishlist" className="btn-list__link"><img src={wishlist} className="icon_btn" alt=""/>Wish list</a></li>
            </ul>
        </div>

        <div className="last">
            <h1 className="last-header">Scheduled tours</h1>
                {console.log(future)}
                {console.log(last)}
            {
    
            future.map(item1 =>{
                 return<Tour_user tour_id={item1} past={false}/>;
            
            })
            }



            <h1 className="last-header">Past tours</h1>

            {
            last.map(item1 =>{
                 return<Tour_user tour_id={item1} past={true}/>;
            
            })
            }
        </div>
        <Footer/>
        </>
     );
}
 
export default MyTour;