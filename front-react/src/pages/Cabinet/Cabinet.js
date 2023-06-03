
import edit from "./../../img/icon/edit_icon.png"
import exit from "./../../img/icon/exit_icon.png"
import basket from "./../../img/icon/basket.png"
import wishlist from "./../../img/icon/wish_list.png"
import my_tour from "./../../img/icon/my-tour.png"
import tour_photo from "../../img/icon/extreme.png"
import "./style.css"; 
import React, {useEffect, useState} from "react";
import NavBar from "../../Components/navbar/NavBar";
import Footer from "../../Components/footer/Footer"
import axios from 'axios';
import Tour_user from "../../Components/tour_cabinet/tour_cabinet"


const Cabinet = () => {

    var user_id = localStorage.getItem("login");
    var startDatefinal;
    const[users,setUsers] = useState([]);
    const[info,setUsersinfo] = useState([]);
    const[id_tour,setIdTour] = useState([]);

        useEffect(()=>{
            if(user_id){
        axios.get(`http://localhost:5000/api/Users/get/userById=${user_id}`)
        .then(data =>{
        setUsers(data.data);
        })
        }
        },[]);

        useEffect(()=>{

        axios.get(`http://localhost:5000/api/Users/get/userRecentBookedTourBuLast30DaysIds/userId=${user_id}`)
        .then(data =>{
            setIdTour(data.data);
        })
        
        },[]);




        if(info.latestBookingStartDate!=null){
            let startDateString = info.latestBookingStartDate;
            let startDate = new Date(startDateString);
            let day = startDate.getDate();
            let month = startDate.getMonth() + 1;
            let year = startDate.getFullYear();
            startDatefinal=`${day < 10 ? '0' + day : day}.${month < 10 ? '0' + month : month}.${year}`;
        }else{
            startDatefinal="none"
        }


        
        useEffect(()=>{
            if(user_id){
        axios.get(`http://localhost:5000/api/Users/get/userDateForProfile/userId=${user_id}`)
        .then(data =>{
            setUsersinfo(data.data);
        })
        }
        },[]);



        if (!users) {
            return <h1>...Loading</h1>
        } 





        function exit_function() {
            localStorage.removeItem("login");
        }

    return ( 
        <>
        <NavBar/>
        <div className="container">
            <div className="cabinet">
                <img className="profile-photo" src={users.avatar} alt="Profile" />
                <div>
                    <div className="profile-info">
                        <div className="name">
                            <h1 className="h1-name">{users.firstName}</h1>
                        
                            <h1 className="h1-name">{users.lastName}</h1>
                        </div>
                    
                        <div className="level">
                            <h1 className="level__label">Level {Math.floor(users.experience/100)+1}</h1>
                            <progress className="level__bar" max={100} value={users.experience%100}/>
                        </div>
                    </div>
                </div>

                <div className="travels">
                    <h2>My travels</h2>
                    <h3 className="info">{info.travelCount}</h3>

                    <h2>Last travel</h2>
                    <h3 className="info">{startDatefinal}</h3>
                </div>

                <div className="additional">
                    <h2>Created journeys</h2>
                    <h3 className="info">{info.createdTourCount}</h3>

                    <h2>City</h2>
                    <h3 className="info">{users.city}</h3>
                </div>

                <div className="btns">
                    <div className="edit"><a href="/cabinet/editprofile"><img src={edit} alt="edit"/></a></div>
                    <div onClick={exit_function}  className="exit"><a href="/"><img src={exit} alt="exit"/></a></div>
                </div>
            </div>
        </div>

        <div className="buttons">
            <ul className="btn-list">
                <li className="btn-list__item"><a href="/cabinet/myorders" className="btn-list__link"><img src={basket} className="icon_btn" alt=""/>My orders</a></li>
                <li className="btn-list__item"><a href="/cabinet/wishlist" className="btn-list__link"><img src={wishlist} className="icon_btn" alt=""/>Wish list</a></li>
                <li className="btn-list__item"><a href="/cabinet/mytour" className="btn-list__link"><img src={my_tour} className="icon_btn" alt=""/>My tour</a></li>
            </ul>
        </div>

        <div className="last">
            <h1 className="last-header">The last rounds completed in this month</h1>
           

            {
                id_tour.map(item1 =>{

                    return<Tour_user tour_id={item1}/>;
                })
            }

        </div>
        <Footer/>
        </>
     );
}
 
export default Cabinet;