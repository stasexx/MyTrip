
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


const Cabinet = () => {

    var user_id = localStorage.getItem("login");

    const[users,setUsers] = useState([]);
  
        useEffect(()=>{
            if(user_id){
        axios.get(`http://localhost:5000/api/Users/get/userById=${user_id}`)
        .then(data =>{
        setUsers(data.data);
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
                    <h3 className="info">27</h3>

                    <h2>Last travel</h2>
                    <h3 className="info">19.02.2023</h3>
                </div>

                <div className="additional">
                    <h2>Created journeys</h2>
                    <h3 className="info">3</h3>

                    <h2>City</h2>
                    <h3 className="info">{users.city}</h3>
                </div>

                <div className="btns">
                    <div className="edit"><a href="./index.html"><img src={edit} alt="edit"/></a></div>
                    <div onClick={exit_function}  className="exit"><a href="/"><img src={exit} alt="exit"/></a></div>
                </div>
            </div>
        </div>

        <div className="buttons">
            <ul className="btn-list">
                <li className="btn-list__item"><a href="./index.html" className="btn-list__link"><img src={basket} className="icon_btn" alt=""/>My orders</a></li>
                <li className="btn-list__item"><a href="./index.html" className="btn-list__link"><img src={wishlist} className="icon_btn" alt=""/>Wish list</a></li>
                <li className="btn-list__item"><a href="./index.html" className="btn-list__link"><img src={my_tour} className="icon_btn" alt=""/>My tour</a></li>
            </ul>
        </div>

        <div className="last">
            <h1 className="last-header">The last rounds completed in this month</h1>
            <div className="table_container">
            <table>
                <tr>
                    <td rowspan="2" className="td_tour-photo"><img src={tour_photo} alt=""/></td>
                    <td>Header 2</td>
                    <td>Header 3</td>
                    <td>Header 4</td>
                    <td>Header 5</td>
                </tr>
                <tr>
                    <td>Data 2</td>
                    <td>Data 3</td>
                    <td>Data 4</td>
                    <td>Data 5</td>
                </tr>
            </table>
            </div>

            <div className="table_container">
            <table>
                <tr>
                    <td rowspan="2">Header 1</td>
                    <td>Header 2</td>
                    <td>Header 3</td>
                    <td>Header 4</td>
                    <td>Header 5</td>
                </tr>
                <tr>
                    <td>Data 2</td>
                    <td>Data 3</td>
                    <td>Data 4</td>
                    <td>Data 5</td>
                </tr>
            </table>
            </div>
        </div>
        <Footer/>
        </>
     );
}
 
export default Cabinet;