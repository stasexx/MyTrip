import "./style.css"; 
import React, {useEffect, useState} from "react";
import axios from 'axios';
import login_photo_right from "./../../img/icon/login_photo_right.png";
import logo from "./../../img/icon/logo.png"; 
import google from "./../../img/icon/google.png"; 
import {useNavigate} from 'react-router-dom';
const src="http://localhost:5000/Users/api/checkForEmail";
const src_google="http://localhost:5000/GoogleOAuth/api/oauth";

const  Login = () => {
    const[user,setUsers] = useState([]);    
    const navigate = useNavigate();


    function Check_login(){
        var email=document.getElementById("email").value
        var password=document.getElementById("password").value
        if(email.length>0){

            axios.get(src,{ params: { email: email } })
            .then(function (data) {
                setUsers(data.data);
                console.log(data.data)
            });
            if(user.userId){
                if(user.password==password){
                    alert("ви успішно аторизовані");
                          navigate('/');
                } 
            }
            console.log(user.userId)
        }
    }
    function Google_login(){
            var gol;
            axios.get(src_google)
            .then(res => {gol=res.data
            console.log(gol);
            navigate(gol);
        })
 
    }
    
        return ( 
            
            <main>
                    <div className="container">
                    <div className="font_right"><img src={login_photo_right} alt="Link" /> </div>
                    <div className="font_left"><img src={login_photo_right} alt="Link" /></div>
                    <div className="log_cont" >
                        <div className="login" >
                            <h3 className="hello">Welcome Back!</h3>
                            <div className="logo"><img src={logo} alt="Link" /></div>
                            

                                 <input type ="text"  className="box" id="email" placeholder="Enter your email"></input>



                                <input  type ="text" className="box" id="password" placeholder="Enter your password"></input>


                            <div className="or_line"> 
                                <div className="line1"></div><div className="text_or">or</div><div className="line2"></div>
                            </div>



                            <div className="login_button">
                                <button href="./" onClick={Google_login} className="google_acc"><img className="foto_google" src={google} alt="Link" />Continue with Google</button>
                                <div className="forget"><a href="./register" >Forget Password</a></div>
                                <button href="./" onClick={Check_login} className="log">Login</button>
                                <div className="quest">Don`t have an account?<a href="./register" className="signup">Sign up</a></div>
                            </div>
                         </div>
                    </div>

                    </div>
            </main>
            
    );
    }
     
    export default Login;