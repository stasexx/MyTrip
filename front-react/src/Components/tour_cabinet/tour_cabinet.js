import React, {useEffect, useState} from "react";
import axios from 'axios';
import styles from './Stules.module.css';
import image_21 from "./../../img/icon/image_21.png";
import image_15 from "./../../img/icon/image 15.png";

import image_20 from "./../../img/icon/image 20.png";
import image_19 from "./../../img/icon/image 19.png";
import image_18 from "./../../img/icon/image 18.png";
import image_17 from "./../../img/icon/image 17.png";
import image_16 from "./../../img/icon/image 16.png";


const Tour_user = ({tour_id}) => {


    const[tour,setTour] = useState([]);
    const[tour_info_orh,setTour_info_orh] = useState([]);
    const[tour_info_hdm,setTour_info_hdm] = useState([]);
    const[tour_info_orh_price,settour_info_orh_price] = useState([]);

        useEffect(()=>{

        axios.get(`http://localhost:5000/api/Tours/get/toursById=${tour_id}`)
        .then(data =>{
            setTour(data.data);
        })
        
        },[]);


        useEffect(() => {
            axios
              .get(`http://localhost:5000/api/OrgTour/get/orgTourByTourId/tourId=${tour_id}`)
              .then((response) => {
                const data = response.data;
                if (data && data.user ) {
                  setTour_info_orh(data.user);
                  settour_info_orh_price(data.price);
                }
              })
              .catch((error) => {
                console.log(error);
              });
          }, []);
    

        useEffect(()=>{

            axios.get(`http://localhost:5000/api/HandTour/get/handTourByTour/tourId=${tour_id}`)
            .then((response) =>{
                const data = response.data;
                if (data && data.user ) {
                  setTour_info_orh(data.user);
                  settour_info_orh_price("————");
                }
            })

        },[]);
        

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




    
    return ( 
     <>





        <div className={styles.table_container}>
                    <table>


                        <tr>
                            <td rowspan="2" className={styles.td_tour_photo}><img src={decodeURIComponent(tour.mainPhoto)} alt=""/></td>
                            <td>
                                <div><img src={image_21}  className={styles.tour__img}/>Name</div>
                                <div className={styles.name}>{tour.name}</div>
                            </td>

                            <td>
                                <div>
                                     <img src={image_15}  className={styles.tour__img}/>Date start</div>
                                <div className={styles.name}>{startDatefinal}</div>
                            </td>
                            
                            <td>
                                <div><img src={image_17}  className={styles.tour__img}/>Place of departure </div>
                                <div className={styles.name}>{tour.placeOfDeparture}</div>
                            </td>

                            <td>
                                <div><img src={image_18}  className={styles.tour__img}/>Price </div>
                                <div className={styles.name}>{tour_info_orh_price}</div>
                            </td>
                        </tr>
                        <tr>
                            
                            <td>
                                <div><img src={image_20}  className={styles.tour__img}/>Organizer </div>
                                <div className={styles.name}>{tour_info_orh.lastName} {tour_info_orh.firstName}</div>
                            </td>

                            <td>
                                <div><img src={image_15}  className={styles.tour__img}/>Date end</div>
                                <div className={styles.name}>{endDatefinal}</div>
                            </td>

                            <td>
                                <div><img src={image_16}  className={styles.tour__img}/>Place of arrival</div>
                                <div className={styles.name}>{tour.destination}</div>
                            </td>

                            <td>
                                <div><img src={image_19}  className={styles.tour__img}/>Type</div>
                                <div className={styles.name}>{tour.category}</div>
                            </td>
                        </tr>

                    </table>
        </div>

    </>

    )

}
export default Tour_user;