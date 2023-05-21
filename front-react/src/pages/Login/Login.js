
import React, {useEffect, useState} from "react";
import axios from 'axios';
import login_photo_right from "./../../img/icon/login_photo_right.png";
import logo from "./../../img/icon/logo.png"; 
import google from "./../../img/icon/google.png"; 
import {useNavigate} from 'react-router-dom';
import styles from './Stules.module.css';
const src="http://localhost:5000/api/Users/get/userByEmail=";
const src_google="http://localhost:5000/api/GoogleOAuth/oauth/authorization";

const  Login = () => {
    const[user,setUsers] = useState([]);    
    const navigate  = useNavigate ();

    function Check_login(){
        var email=document.getElementById("email").value
        var password=document.getElementById("password").value
        if(email.length>0){

            axios.get(src+email)
            .then(function (data) {
                setUsers(data.data);
                console.log(data.data)
            });
            if(user.userId){
                if(user.password==password){
                    alert("ви успішно аторизовані");
                }}
            console.log(user.userId)
        }
    }
    function Google_login(){
            var gol;
            axios.get(src_google)
            .then(data => {console.log(data);console.log(data.data);
        })
 
    }
    
        return ( 
            
            <main>
                    <div className="container">
                    <div className={styles.font_right}><img src={login_photo_right} alt="Link" /> </div>
                    <div className={styles.font_left}><img src={login_photo_right} alt="Link" /></div>
                    <div className={styles.log_cont} >
                        <div className={styles.login}>
                            <h3 className={styles.hello}>Welcome Back!</h3>
                            <div className={styles.logo}><img src={logo} alt="Link" /></div>
                            

                                 <input type ="text"  className={styles.box}id="email" placeholder="Enter your email"></input>



                                <input  type ="text" className={styles.box} id="password" placeholder="Enter your password"></input>


                            <div className={styles.or_line}> 
                                <div className={styles.line1}></div><div className={styles.text_or}>or</div><div className={styles.line2}></div>
                            </div>



                            <div className={styles.login_button}>
                                <button onClick={Google_login} className={styles.google_acc}><img className={styles.foto_google} src={google} alt="Link" />Continue with Google</button>
                                <div className={styles.forget}><a href={styles.register} >Forget Password</a></div>
                                <button href="./" onClick={Check_login} className="log">Login</button>
                                <div className={styles.quest}>Don`t have an account?<a href="./register" target="_self" className={styles.signup}>Sign up</a></div>
                            </div>
                         </div>
                    </div>

                    </div>
            </main>
            
    );
    }
     
    export default Login;