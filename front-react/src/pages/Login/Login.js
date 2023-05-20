import "./style.css"; 
import React, {useEffect, useState} from "react";
import axios from 'axios';
import login_photo_right from "./../../img/icon/login_photo_right.png";
import logo from "./../../img/icon/logo.png"; 
import google from "./../../img/icon/google.png"; 

const src="http://localhost:5000/checkForEmail?email=";





const  Login = () => {
    const[user,setUsers] = useState([]);    

    function Check_login(){
        var email=document.getElementById("email").value
        var password=document.getElementById("password").value
        axios.get(src+email)
        .then(function (data) {
            setUsers(data.data);
        });
        if(user.userId){
            if(user.password==password){
                alert("ви успішно аторизовані");
                return(
                    <>
                    
                    </>
                )
            }
            
        }
        console.log(user.userId)
        
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
                                <button href="./" className="google_acc"><img className="foto_google" src={google} alt="Link" />Continue with Google</button>
                                <div className="forget"><a href="./" >Forget Password</a></div>
                                <button href="./" onClick={Check_login} className="log">Login</button>
                                <div className="quest">Don`t have an account?<label className="signup">Sign up</label></div>
                            </div>
                         </div>
                    </div>

                    </div>
            </main>
            
    );
    }
     
    export default Login;