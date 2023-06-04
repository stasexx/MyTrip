
import edit from "./../../img/icon/edit_icon.png"
import exit from "./../../img/icon/exit_icon.png"
import basket from "./../../img/icon/basket.png"
import wishlist from "./../../img/icon/wish_list.png"
import my_tour from "./../../img/icon/my-tour.png"
import tour_photo from "../../img/icon/extreme.png"
import font from "../../img/icon/font.png"
import styles from './Stules.module.css';
import React, {useEffect, useState} from "react";
import NavBar from "../../Components/navbar/NavBar";
import Footer from "../../Components/footer/Footer"
import axios from 'axios';
import Tour_user from "../../Components/my tour/my_tour"
import profile from "../../img/icon/6554725.png"
import {useNavigate} from 'react-router-dom';

const EditProfile = () => {
    const navigate = useNavigate();
    const user_id = localStorage.getItem("login");
    const [users, setUsers] = useState([]);
    const [firstName, setFirstName] = useState("");
    const [email, setEmail] = useState("");
    const [login, setLogin] = useState("");
    const [password, setPassword] = useState("");
    const [lastName, setLastName] = useState("");
    const [phoneNumber, setPhoneNumber] = useState("");
    const [city, setCity] = useState("");
    const [avatar, setAvatar] = useState("");

  useEffect(() => {
    if (user_id) {
      axios.get(`http://localhost:5000/api/Users/get/userById=${user_id}`)
        .then(data => {
          setUsers(data.data);
        })
    }
  }, []);

  useEffect(() => {
    if (users) {
      setFirstName(users.firstName);
      setEmail(users.email);
      setLogin(users.login);
      setPassword(users.password);
      setLastName(users.lastName);
      setPhoneNumber(users.phoneNumber);
      setCity(users.city);
      setAvatar(users.avatar);
    }
  }, [users]);

  const handleFirstNameChange = (e) => {
    setFirstName(e.target.value);
  }

  const handleEmailChange = (e) => {
    setEmail(e.target.value);
  }

  const handleLoginChange = (e) => {
    setLogin(e.target.value);
  }

  const handlePasswordChange = (e) => {
    setPassword(e.target.value);
  }

  const handleLastNameChange = (e) => {
    setLastName(e.target.value);
  }

  const handlePhoneNumberChange = (e) => {
    setPhoneNumber(e.target.value);
  }

  const handleCityChange = (e) => {
    setCity(e.target.value);
  }
  const handleAvatarChange = (e) => {
    setAvatar(e.target.value);
  }

  const handleSaveChanges = () => {


    if(users.firstName!=firstName){
        axios.post(`http://localhost:5000/api/Users/change/firstName=${firstName}/email=${users.email}`)
        .then(alert("Успішно змінено"))
        .catch((error) => alert(error)); 
    }

    if(users.lastName!=lastName){
        axios.post(`http://localhost:5000/api/Users/change/lastName=${lastName}/email=${users.email}`)
        .then(alert("Успішно змінено"))
        .catch((error) => alert(error)); 
    }


    if(users.login!=login){
        axios.post(`http://localhost:5000/api/Users/change/newLogin=${login}/email=${users.email}`)
        .then(alert("Успішно змінено"))
        .catch((error) => alert(error)); 
    }
    
    if(users.phoneNumber!=phoneNumber){
        axios.post(`http://localhost:5000/api/Users/change/newPhoneNumber=${phoneNumber}/email=${users.email}`)
        .then(alert("Успішно змінено"))
        .catch((error) => alert(error)); 
    }


        
    if(users.city!=city){
        axios.post(`http://localhost:5000/api/Users/change/newCity=${city}/email=${users.email}`)
        .then(alert("Успішно змінено"))
        .catch((error) => alert(error)); 
    }

    if(users.password!=password){
        axios.post(`http://localhost:5000/api/Users/change/oldPassword=${users.password}/newPassword=${password}/email=${users.email}`)
        .then(alert("Успішно змінено"))
        .catch((error) => alert(error)); 
    }

    if(users.email!=email){
        axios.post(`http://localhost:5000/api/Users/change/email=${users.email}/password=${users.password}/newEmail=${email}`)
        .then(alert("Успішно змінено"))
        .catch((error) => alert(error)); 
    }
    if(users.avatar!=avatar){
      axios.post(`http://localhost:5000/api/Users/change/newAvatar=${encodeURIComponent(avatar)}/email=${users.email}`)
      .then(alert("Успішно змінено"))
      .catch((error) => alert(error)); 
  }



    console.log("Saving changes...");
  }

    return ( 
        <>
        <NavBar/>


        <div className={styles.buttons}>
            <ul className={styles.btn_list}>
            <li className={styles.btn_list__item}><a href="/cabinet" className={styles.btn_list__link}><img src={profile} className={styles.icon_btn} alt=""/>Profile</a></li>
                <li className={styles.btn_list__item}><a href="/cabinet/myorders" className={styles.btn_list__link}><img src={basket} className={styles.icon_btn} alt=""/>My orders</a></li>
                <li className={styles.btn_list__item}><a href="/cabinet/wishlist" className={styles.btn_list__link}><img src={wishlist} className={styles.icon_btn} alt=""/>Wish list</a></li>
                <li className={styles.btn_list__item}><a href="/cabinet/mytour" className={styles.btn_list__link}><img src={my_tour} className={styles.icon_btn} alt=""/>My tour</a></li>
            </ul>
        </div>

        <div className={styles.container}>

        

            <div className={styles.cabinet}>
                <div>
                    <img className={styles.profile_photo} src={decodeURIComponent(users.avatar)} alt="Profile" />
                    <input type="text" className={styles.avatar}placeholder="Enter url avatar " value={avatar} onChange={handleAvatarChange} />

                </div>
                
                


                <div className={styles.travels}>
                    <h2 className={styles.h2}>Name</h2>
                    <input type="text" className={styles.info} placeholder="Enter your name" value={firstName} onChange={handleFirstNameChange} />
                    <h2 className={styles.h2}>Email</h2>
                    <input type="text" className={styles.info} placeholder="Enter your email" value={email} onChange={handleEmailChange} />
                    <h2 className={styles.h2}>Username</h2>
                    <input type="text" className={styles.info} placeholder="Enter your username" value={login} onChange={handleLoginChange} />
                    <h2 className={styles.h2}>Password</h2>
                    <input type="text" className={styles.info} placeholder="Enter your password" value={password} onChange={handlePasswordChange} />
                </div>

                <div className={styles.additional}>
                    <h2 className={styles.h2}>Surname</h2>
                    <input type="text" className={styles.info} placeholder="Enter your surname" value={lastName} onChange={handleLastNameChange} />

                    <h2 className={styles.h2}>Phone</h2>
                    <input type="text" className={styles.info} placeholder="Enter your phone number" value={phoneNumber} onChange={handlePhoneNumberChange} />

                    <h2 className={styles.h2}>City</h2>
                    <input type="text" className={styles.info} placeholder="Enter your city" value={city} onChange={handleCityChange} />

                    <div onClick={handleSaveChanges} className={styles.btn_save}>Save</div>
                    
                    
                </div>

                <img src={font}  className={styles.font__img}/>
            </div>
            
        </div>

        <Footer/>
        </>
     );
}
 
export default EditProfile;