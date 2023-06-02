import React, {useEffect, useState} from "react";
import axios from 'axios';
import NavBar from "../../Components/navbar/NavBar";
import Footer from "../../Components/footer/Footer"
import styles from './Stules.module.css';
import { useParams,Navigate } from "react-router-dom";
import StRating from './rating';
import './styles.css';

import { Swiper, SwiperSlide } from 'swiper/react';

import 'swiper/css';
import 'swiper/css/effect-coverflow';
import 'swiper/css/pagination';
import 'swiper/css/navigation';

import { EffectCoverflow, Pagination, Navigation } from 'swiper';

import wish_button from "./../../img/icon/wish_button.png";




const src="http://localhost:5000/api/Tours/get/allTours";




const  TourPage = () => {



    
    const {id}=useParams();
    var MyTour;
    var startDatefinal;
    var endDatefinal;
    var count_review
    const[tour,setTours] = useState([]);
    const[photo,setPhoto] = useState([]);
    const[review,setReview] = useState([]);
    const[org,setOrg] = useState([]);
    const[review_to_print,setReview_to_print] = useState([]);


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


    useEffect(()=>{
        axios.get(src)
        .then(data =>{
        setTours(data.data);
        })
        },[]);

    useEffect(()=>{
        axios.get(`http://localhost:5000/api/TourPhotos/get/allTourPhotosById/id=${id}`)
        .then(data =>{
        setPhoto(data.data);
        })
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


        var us=org.user;
        if(us){
            var agency=us.agency;
            var email=us.email;

        }


    useEffect(()=>{

        axios.get(`http://localhost:5000/api/Reviews/get/reviews/tourId=${id}`)

        .then(function(response){
            setReview_to_print(response.data)
        })
        .catch(function(error) {
            console.log(error)
        })
    },[]);

        var rew = review_to_print[0];
        var rew1 = review_to_print[1];
        if(review_to_print[0]){

            let startDat = review_to_print[0].reviewDate;
            let start = new Date(startDat);
            let day = start.getDate();
            let month = start.getMonth() + 1;
            let year = start.getFullYear();
            var date_rew=`${day < 10 ? '0' + day : day}.${month < 10 ? '0' + month : month}.${year}`;
            var text_rew=review_to_print[0].text
            var rate_rew=review_to_print[0].rate

            let startDat1 = review_to_print[1].reviewDate;
            let start1 = new Date(startDat1);
            let day1 = start1.getDate();
            let month1 = start1.getMonth() + 1;
            let year1 = start1.getFullYear();
            var date_rew1=`${day1 < 10 ? '0' + day1 : day1}.${month1 < 10 ? '0' + month1 : month1}.${year1}`;
            var text_rew1=review_to_print[1].text
            var rate_rew1=review_to_print[1].rate

        }

        if(rew1){
            var rew_21 = rew1.order
            console.log(rew_21)
            if(rew_21){
                var rew_31 = rew_21.user

                if(rew_31){
                    
                    var firstName1=rew_31.firstName;
                    var lastName1=rew_31.lastName;
                    var photo_user1=rew_31.avatar;
                }

            }
            
        }

        

        if(rew){
            var rew_2 = rew.order
            if(rew_2){
                var rew_3 = rew_2.user
                if(rew_3){
                    var firstName=rew_3.firstName;
                    var lastName=rew_3.lastName;
                    var photo_user=rew_3.avatar;
                }

            }
            
        }

    useEffect(()=>{
        axios.get(`http://localhost:5000/api/Reviews/get/reviews/tourId=${id}`)
        .then(data =>{
        setReview(data.data);
        })
        },[]);

        if (review.length > 0) {
            count_review = review.length;
        } else {
            count_review = 0;
        }


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
            if(isActive){
                setIsActive(false);

            }else{
                setIsActive(true);
                axios.post(`http://localhost:5000/api/WishList/create/newFavourite/tourId=${id}?email=${user.email}`)
                .then(alert("Успішно додали до обраних"))
                .catch((error) => alert(error));
                
            }
            console.log(isActive)
          }


        return ( 
        <>
            <NavBar/>
            <div className={styles.container}>
                    <div className={styles.name_tour}>{MyTour.name}</div>
                    <a id={id} className={`${styles.wishlist} ${isActive ? styles.wish : styles.wish_not}`} onClick={show}>
                    <img src={wish_button} alt="" className={styles.like__img} />
                    </a>
                    
                    <div className={styles.info_orh}>
                        <div className={styles.name_org} >{agency}</div><div className={styles.delimiter}>●</div><StRating rate={MyTour.rate}/><div className={styles.delimiter}>●</div>{count_review} reviews<div className={styles.delimiter}>●</div>+{org.experience} Exp <div className={styles.delimiter}>●</div> {email}
                    </div>    
            </div>
            <div className={styles.infoo__tour}>
                    <div className={styles.container}>

                        <img className={styles.foto_tour} src={MyTour.mainPhoto} alt="Link"/>
                        <div className={styles.text_tour} >
                        
                            <div>Begin: {startDatefinal}</div>
                            <div>End: {endDatefinal}</div>
                            <div>Category: {MyTour.category}</div>
                            <div className={styles.price}>{org.price}$</div>
                            <a href={`./${id}/bascket`} className={styles.link_tour}>Purchase</a>
                        </div>
                    </div> 
            </div>

            <div className={styles.container}>

                <div className={styles.description}>{MyTour.description}</div>

                
                <div className={styles.all_photo}>

                 
                <Swiper
                    effect={'coverflow'}
                    grabCursor={true}
                    centeredSlides={true}
                    loop={true}
                    coverflowEffect={{
                    rotate: 0,
                    stretch: 0,
                    depth: 6,
                    modifier: 100,
                    
                    }}
                    spaceBetween ={-570}
                    pagination={{ el: '.swiper-pagination', clickable: true }}
                    navigation={{
                    nextEl: '.swiper-button-next',
                    prevEl: '.swiper-button-prev',
                    clickable: true,
                    }}
                    modules={[EffectCoverflow, Pagination, Navigation]}
                    className="swiper_container"
                >
                                    { photo.map((item) =>(
                                        
                                        <SwiperSlide>
                                            <img src={item.uuid} alt="slide_image" />
                                        </SwiperSlide>
                                    )
                                    )}

                    <div className="slider-controler">
                    <div className="swiper-button-prev slider-arrow">
                        <ion-icon name="arrow-back-outline"></ion-icon>
                    </div>
                    <div className="swiper-button-next slider-arrow">
                        <ion-icon name="arrow-forward-outline"></ion-icon>
                    </div>
                    <div className="swiper-pagination"></div>
                    </div>
                </Swiper>

                </div>
                            
            </div>


            <div className={styles.reviews_cont}>Reviews</div>
            <div className={styles.container}>

                    <div className={styles.reviews}>
                        <div className={styles.name_org} ></div><StRating rate={MyTour.rate}/><div className={styles.delimiter}>●</div>{count_review} reviews
                    </div>    
                    
                    {
                        text_rew ? (
                            <div className={styles.reviews_list}>       
                                <img className={styles.rew_photo_user} src={photo_user} alt="slide_image" />
                                <div className={styles.name_org} >
                                    <div className={styles.name_user}>{firstName} {lastName} <label>{date_rew}</label></div>
                                    <div><StRating  rate={rate_rew}/></div>
                                    <div className={styles.errf}></div>
                                    <div className={styles.text_rew} >{text_rew}</div>
                                </div>    
                            </div> 

                        ): <div className={styles.text_rew} >Відгуки відсутні</div>


                    }

                    {
                        text_rew1 ? (
                            <div className={styles.reviews_list}>       
                            <img className={styles.rew_photo_user} src={photo_user1} alt="slide_image" />
                            <div className={styles.name_org} >
                                <div className={styles.name_user}>{firstName1} {lastName1} <label>{date_rew1}</label></div>
                                <div><StRating  rate={rate_rew1}/></div>
                                <div className={styles.errf}></div>
                                <div className={styles.text_rew} >{text_rew1}</div>
                            </div>    
                        </div> 

                        ): null


                    }

                <a href="#" className={styles.link_pop_tour}>SHOW MORE</a>
            </div>


            <Footer/>
        </>           
               
    );

}
 
export default TourPage;