import font from "../../img/icon/font.png"
import styles from './Stules.module.css';
import React, {useEffect, useState} from "react";
import NavBar from "../../Components/navbar/NavBar";
import Footer from "../../Components/footer/Footer"
import axios from 'axios';

import {useNavigate} from 'react-router-dom';



const Redactor = () => {
    const navigate = useNavigate();
    const user_id = localStorage.getItem("login");
    const [users, setUsers] = useState([]);
    const [idtour, setidtours] = useState([]);

            /* Для туру*/ 

    const [name, setName] = useState("");
    const [description, setDescription] = useState("");

    const [typeOfTour , setTypeOfTour ] = useState("orh");
    const [category  , setСategory  ] = useState("");
    const [startDate  , setStartDate  ] = useState("");
    const [endDate , setEndDate ] = useState("");
    const [destination , setDestination ] = useState("");
    const [placeOfDeparture , setPlaceOfDeparture ] = useState("");

    const [countOfUser  , setCountOfUser  ] = useState("");
    const [mainPhoto  , setMainPhoto  ] = useState("");
    const [tags  , setTags  ] = useState("");
    const [experience   , setExperience   ] = useState("");
    const [price    , setPrice    ] = useState("");
    const [promocode     , setPromocode    ] = useState("");



    const [photo1     , setPhoto1    ] = useState("");
    const [photo2    , setPhoto2   ] = useState("");
    const [photo3     , setPhoto3    ] = useState("");
    const [photo4    , setPhoto4   ] = useState("");
    const [photo5     , setPhoto5    ] = useState("");
    






    const [email      , setEmail     ] = useState("");
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
      setEmail(users.email);
    }
  }, [users]);



  const handleNameChange = (e) => {
    setName(e.target.value);
  }

  const handleDescriptionChange = (e) => {
    setDescription(e.target.value);
  }
/*
  const handleTypeOfTourChange = (e) => {
    setTypeOfTour(e.target.value);
  }
*/
  const handleСategoryChange = (e) => {
    setСategory(e.target.value);
  }

  const handleStartDateChange = (e) => {
    setStartDate(e.target.value);
  }

  const handleEndDateChange = (e) => {
    setEndDate(e.target.value);
  }

  const handleDestinationChange = (e) => {
    setDestination(e.target.value);
  }
  const handlePlaceOfDepartureChange = (e) => {
    setPlaceOfDeparture(e.target.value);
  }
  const handleCountOfUserChange = (e) => {
    setCountOfUser(e.target.value);
  }
  const handleMainPhotoChange = (e) => {
    setMainPhoto(e.target.value);
  }
  const handleTagsChange = (e) => {
    setTags(e.target.value);
  }
  const handleExperienceChange = (e) => {
    setExperience(e.target.value);
  }

  const handlePriceChange = (e) => {
    setPrice(e.target.value);
  }
  const handlePromocodeChange = (e) => {
    setPromocode(e.target.value);
  }


  const handlePhoto1Change = (e) => {
    setPhoto1(e.target.value);
  }
  const handlePhoto2Change = (e) => {
    setPhoto2(e.target.value);
  }
  const handlePhoto3Change = (e) => {
    setPhoto3(e.target.value);
  }
  const handlePhoto4Change = (e) => {
    setPhoto4(e.target.value);
  }
  const handlePhoto5Change = (e) => {
    setPhoto5(e.target.value);
  }
  const handleSaveChanges = () => {

    if(users.email){

        var dateString = startDate;
        var parts = dateString.split('.'); 
        
        var datetime = new Date(parts[2], parts[1] - 1, parts[0]);
        
        var datetimeString = datetime.toISOString();
        
        console.log(datetimeString); // Выводит: "2023-06-19T00:00:00.000Z"
    

        var dateString1 = endDate;
        var parts1 = dateString1.split('.'); 
        
        var datetime1 = new Date(parts1[2], parts1[1] - 1, parts1[0]);
        
        var datetimeString1 = datetime1.toISOString();
        
        console.log(datetimeString1); // Выводит: "2023-06-19T00:00:00.000Z"
    
 
        const mainPhotoen = encodeURIComponent(mainPhoto);

        axios.post(`http://localhost:5000/api/OrgTour/create/createOrgTour/name=${name}/description=${description}/rate=0/typeOfTour=${typeOfTour}/category=${category}/startDate=${datetimeString}/endDate=${datetimeString1}/destination=${destination}/placeOfDeparture=${placeOfDeparture}/countOfUser=${countOfUser}/mainPhoto=${mainPhotoen}/allPhotos=0/tags=${tags}/experience=${experience}/price=${price}/promocode=${promocode}/email=${users.email}`)
        .then(data =>{
            setidtours(data.data);
            var tour = data.data.tour;
            console.log(tour.tourId)

            if(photo1){
                axios.post(`http://localhost:5000/api/TourPhotos/create/tourPhoto/tourId=${tour.tourId}/uuid=${encodeURIComponent(photo1)}`)
                .then()
                .catch((error) => alert(error)); 
            }
            
            if(photo2){
                axios.post(`http://localhost:5000/api/TourPhotos/create/tourPhoto/tourId=${tour.tourId}/uuid=${encodeURIComponent(photo2)}`)
                .then()
                .catch((error) => alert(error)); 
            }

            if(photo3){
                axios.post(`http://localhost:5000/api/TourPhotos/create/tourPhoto/tourId=${tour.tourId}/uuid=${encodeURIComponent(photo3)}`)
                .then()
                .catch((error) => alert(error)); 
            }

            if(photo4){
                axios.post(`http://localhost:5000/api/TourPhotos/create/tourPhoto/tourId=${tour.tourId}/uuid=${encodeURIComponent(photo4)}`)
                .then()
                .catch((error) => alert(error)); 
            }


            if(photo5){
                axios.post(`http://localhost:5000/api/TourPhotos/create/tourPhoto/tourId=${tour.tourId}/uuid=${encodeURIComponent(photo5)}`)
                .then()
                .catch((error) => alert(error)); 
            }
            

            navigate('/');




    


            
        })
        
    }

  }

  const handleCancelChanges = () => {
    navigate('/');
  }
    return ( 
        <>
        <NavBar/>

        <div className={styles.container}>
            <div className={styles.name_page}>Tour redactor
            <div className={styles.swi_name_orh}>Organization Tour</div>
            </div>
        
            
            <label className={styles.switch}>
                <input type="checkbox" className={styles.switch__input}></input>
                <span className={styles.switch__slider}></span>
            </label>


        <div className={styles.tour_images}> ● Tour cover </div>
        <input type="text" className={styles.info_main} placeholder="Enter url main photo" onChange={handleMainPhotoChange} />
        <div>
            <div className={styles.tour_images}> ● Tour images</div>
            <ul>
                <li>
                <div className={styles.tour_cover}>1. <input type="text" className={styles.info} placeholder="Enter url photo" onChange={handlePhoto1Change} /></div>
                </li>
                <li>
                <div className={styles.tour_cover}>2. <input type="text" className={styles.info} placeholder="Enter url photo" onChange={handlePhoto2Change} /></div>
                </li>
                <li>
                <div className={styles.tour_cover}>3. <input type="text" className={styles.info} placeholder="Enter url photo" onChange={handlePhoto3Change} /></div>
                </li>
                <li>
                <div className={styles.tour_cover}>4. <input type="text" className={styles.info} placeholder="Enter url photo" onChange={handlePhoto4Change} /></div>
                </li>
                <li>
                <div className={styles.tour_cover}>5. <input type="text" className={styles.info} placeholder="Enter url photo" onChange={handlePhoto5Change} /></div>
                </li>
            </ul>
        </div>
             <div className={styles.tour_images}> ● Tour Name</div>
             <input type="text" className={styles.info_name} placeholder="Enter tour name" onChange={handleNameChange} />

             <div className={styles.tour_images}> ● Tour Type </div>
             
             
                <select className={styles.select} id="ddselect"   onChange={handleСategoryChange} >
                    <option>Select Category</option>
                    <option>Wedding tours</option>
                    <option>Travels in Ukraine</option>
                    <option>Romantic</option>
                    <option>Excursion</option>
                </select>



            <div className={styles.cabinet}>


                <div className={styles.travels}>
                    
                    <h2 className={styles.h2}>● Tour Begin </h2>
                    <input type="text" className={styles.info_main} placeholder="Enter data in format (day.month.year)" onChange={handleStartDateChange} />
                    <h2 className={styles.h2}>● Tour End</h2>
                    <input type="text" className={styles.info_main} placeholder="Enter data in format (day.month.year)" onChange={handleEndDateChange} />
                 </div>

                <div className={styles.additional}>
                    <h2 className={styles.h2}>● Tour Price($)</h2>
                    <input type="text" className={styles.info_main} placeholder="Enter tour price"  onChange={handlePriceChange} />

                    <h2 className={styles.h2}>● Tour Exp</h2>
                    <input type="text" className={styles.info_main} placeholder="Enter tour exp"  onChange={handleExperienceChange} />

                 
                </div>

            </div>
            <div className={styles.tour_images}> ● Tags </div>
            <input type="text" className={styles.info_name} placeholder="Enter tags using “ , ”" onChange={handleTagsChange} />

            <div className={styles.cabinet}>
                <div className={styles.travels}>
                    <h2 className={styles.h2}>● Promocode </h2>
                    <input type="text" className={styles.info_main} placeholder="Enter promocode for tour" onChange={handlePromocodeChange} />
                    <h2 className={styles.h2}>● Departure   </h2>
                    <input type="text" className={styles.info_main} placeholder="Enter your departure"  onChange={handlePlaceOfDepartureChange} />
                </div>
                <div className={styles.additional}>
                    <h2 className={styles.h2}>● Count Of User </h2>
                    <input type="text" className={styles.info_main} placeholder="Enter your count of user"  onChange={handleCountOfUserChange} />
                    <h2 className={styles.h2}>● Destination  </h2>
                    <input type="text" className={styles.info_main} placeholder="Enter your destination"  onChange={handleDestinationChange} />
                </div>
            </div>

            <div className={styles.tour_images}> ● Description </div>
            <input type="text" className={styles.info_name} placeholder="Enter description about your tour" onChange={handleDescriptionChange} />

            <div className={styles.cabinet}>
                <div className={styles.travels}>
                  <div onClick={handleSaveChanges} className={styles.btn_crt}>Create</div>
                </div>
                <div className={styles.additional}>
                <div onClick={handleCancelChanges} className={styles.btn_can}>Cancel</div>
                </div>
            </div>
            
        </div>

        <Footer/>
        </>
     );
}
 
export default Redactor;