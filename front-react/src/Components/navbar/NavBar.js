import"./styles.css"

import logo from "./../../img/icon/logo.png"; 


import React, {useEffect, useState} from "react";
import axios from 'axios';

import wish_list from "./../../img/icon/wish_list.png"; 
import tours from "./../../img/icon/tours.png"; 
import sign_in from "./../../img/icon/sign_in.png"; 
import about_us from "./../../img/icon/about_us.png";
import search_glass from "./../../img/icon/glass_search.png";

const  NavBar= () => {


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

    return ( 
    <>
    <nav className="nav">
        <div className="container">
            <div className="nav-row">
                <a href="/" className="logo"><img src={logo} alt="Link"/></a>
                <div class ="search-box">
                     <a class="search-btn" href="#"><img className="icon_header" src={search_glass} alt="Link"/></a>
                    <input class="search-tour" type ="text" name="" placeholder="Search tours"></input>
                </div>
                   <ul className="nav-list">
                        <li className="nav-list__item"><a href="/about" className="nav-list__link"><img className="icon_header" src={about_us} alt="Link"/>About us</a></li>
                        <li className="nav-list__item"><a href="/catalog" className="nav-list__link"><img className="icon_header" src={tours} alt="Link"/>Tours</a></li>
         
                    
                    
                        {user_id ? (
                                <>
                                    <li className="nav-list__item"><a href="/cabinet/wishlist" className="nav-list__link"><img className="icon_header" src={wish_list}  alt="Link"/>Wish list</a></li>

                                    <li className="nav-list__item"><a href="/cabinet" className="nav-list_user"><img className="icon_user" src={decodeURIComponent(user.avatar)} alt="Link" /></a></li>

                                </>

                          ) : (
                            <li className="nav-list__item"><a href="/login" className="nav-list_sign"><img className="icon_header" src={sign_in} alt="Link" />Sign in</a></li>
                          )}
                    
                    
                    
                    
                    </ul>
            </div>
        </div>
    </nav>
    
    </> );
}
 
export default NavBar;