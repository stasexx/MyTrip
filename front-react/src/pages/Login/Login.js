
import React, {useState} from "react";
import axios from 'axios';
import login_photo_right from "./../../img/icon/login_photo_right.png";
import logo from "./../../img/icon/logo.png"; 
import google from "./../../img/icon/google.png"; 
import { useNavigate,useLocation   } from "react-router-dom";
import styles from './Stules.module.css';
import jwt_decode from "jwt-decode";

const src="http://localhost:5000/api/Users/get/userByEmail=";

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
                if(user.password===password){
                    localStorage.setItem("login", user.userId);
                    navigate('/');
                }}
            console.log(user.userId)
        }
    }
    
            const location = useLocation();
            var YOUR_CLIENT_ID = '181736966870-p9ttm86o2f4586i07ldte8jjajc7e2m4.apps.googleusercontent.com';
            var YOUR_REDIRECT_URI = 'http://localhost:3000/login';
            var fragmentString = location.hash.substring(1);
        
            // Parse query string to see if page request is coming from OAuth 2.0 server.
            var params = {};
            var regex = /([^&=]+)=([^&]*)/g, m;
            while (m = regex.exec(fragmentString)) {
            params[decodeURIComponent(m[1])] = decodeURIComponent(m[2]);
            }
            if (Object.keys(params).length > 0) {
            localStorage.setItem('oauth2-test-params', JSON.stringify(params) );
            if (params['state'] && params['state'] == 'try_sample_request') {
                trySampleRequest();
            }
            }
        
            // If there's an access token, try an API request.
            // Otherwise, start OAuth 2.0 flow.
            function trySampleRequest() {
                var params = JSON.parse(localStorage.getItem('oauth2-test-params'));
                if (params && params['access_token']) {
                  var xhr = new XMLHttpRequest();
                  xhr.open('GET', 'https://www.googleapis.com/oauth2/v1/userinfo?access_token=' + params['access_token']);
                  xhr.onreadystatechange = function (e) {
                    if (xhr.readyState === 4 && xhr.status === 200) {

                      console.log(xhr.responseText);

                    } else if (xhr.readyState === 4 && xhr.status === 401) {
                      // Token invalid, so prompt for user permission.
                      oauth2SignIn();
                    }
                  };
                  xhr.send(null);
                } else {
                  oauth2SignIn();
                }
              }
        
            /*
            * Create form to request access token from Google's OAuth 2.0 server.
            */
            function oauth2SignIn() {
            // Google's OAuth 2.0 endpoint for requesting an access token
            var oauth2Endpoint = 'https://accounts.google.com/o/oauth2/v2/auth';
        
            // Create element to open OAuth 2.0 endpoint in new window.
            var form = document.createElement('form');
            form.setAttribute('method', 'GET'); // Send as a GET request.
            form.setAttribute('action', oauth2Endpoint);
        
            // Parameters to pass to OAuth 2.0 endpoint.
            var params = {'client_id': YOUR_CLIENT_ID,
                            'redirect_uri': YOUR_REDIRECT_URI,
                            'scope': 'https://www.googleapis.com/auth/drive.metadata.readonly',
                            'state': 'try_sample_request',
                            'include_granted_scopes': 'true',
                            'response_type': 'token'};
        
            // Add form parameters as hidden input values.
            for (var p in params) {
                var input = document.createElement('input');
                input.setAttribute('type', 'hidden');
                input.setAttribute('name', p);
                input.setAttribute('value', params[p]);
                form.appendChild(input);
            }
        
            // Add form to page and submit it to open the OAuth 2.0 endpoint.
            document.body.appendChild(form);
            form.submit();
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
                                <button onClick={() => oauth2SignIn()} className={styles.google_acc}><img className={styles.foto_google} src={google} alt="Link" />Continue with Google</button>
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