import "./style.css"; 
import React, {useEffect, useState} from "react";
import axios from 'axios';
import login_photo_right from "./../../img/icon/login_photo_right.png";
import logo from "./../../img/icon/logo.png"; 
import google from "./../../img/icon/google.png"; 
import {useNavigate} from 'react-router-dom';
const src_google="http://localhost:5000/GoogleOAuth/api/oauth";

const  Login = () => { 
    const navigate = useNavigate();

    function Check_register(){

        var firstname=document.getElementById("firstname").value
        var lastname=document.getElementById("lastname").value
        var email=document.getElementById("email").value
        var password=document.getElementById("password").value
        var password_confirm=document.getElementById("confirm_password").value

        if(email.length>0 ||firstname.length>0||password.length>0||password_confirm.length>0||lastname.length>0){

            if(password==password_confirm){
                
                axios.post(`http://localhost:5000/Users/api/registration/email=${email}/password=${password}/firstname=${firstname}/lastname=${lastname}`)
                .then((respons) => alert(respons)
                )
                .catch((error) => alert(error));
            }
            else{
                alert("Паролі не однакові")
            }
        }
        else{
            alert("Ви не заповнили всі поля")
        }
    }
    function Google_login(){

            axios.get(src_google)
            .then(res => console.log(res.data))
 
    }
    
        return ( 
            
            <main>
                    <div className="container">
                    <div className="font_right"><img src={login_photo_right} alt="Link" /> </div>
                    <div className="font_left"><img src={login_photo_right} alt="Link" /></div>
                    <div className="log_cont" >
                        <div className="login" >
                            <h3 className="hello">Welcome to MyTrip!</h3>
                            <div className="logo"><img src={logo} alt="Link" /></div>
                            
                            <input type ="text"  className="box" id="firstname" placeholder="Enter your first name"></input>
                            <input type ="text"  className="box" id="lastname" placeholder="Enter your last name"></input>
                            <input type ="text"  className="box" id="email" placeholder="Enter your email"></input>
                            <input  type ="text" className="box" id="password" placeholder="Enter your password"></input>
                            <input type ="text"  className="box" id="confirm_password" placeholder="Confirm Password"></input>

                            <div className="or_line"> 
                                <div className="line1"></div><div className="text_or">or</div><div className="line2"></div>
                            </div>
                            <div className="login_button">
                                <button onClick={Google_login} className="google_acc"><img className="foto_google" src={google} alt="Link" />Continue with Google</button>
                                <button href="./" onClick={Check_register} className="log">Register</button>
                                <div className="quest">Already have an account?<a href="./login" className="signup">Sign in</a></div>
                            </div>
                         </div>
                    </div>

                    </div>
            </main>
            
    );
    }
     
    export default Login;