import React from 'react';
import "./style.css";
const src="http://localhost:5000/Tours";

const AdminGeneral = () => {

    return (
            <>

<div className="AdminGeneral">
<div className="whiteBackground">
        <span className="siteStatisticText">General Site Statistic</span>
      </div>
      <div className="additionalFieldStyle">
      <span>Edit</span>
      </div>
      <div className="frameStyle1">
        <span>GENERAL</span>
      </div>
      <div className="frameStyle2">
        <span>TOUR</span>
      </div>
      <div className="frameStyle3">
        <span>USER</span>
      </div>
      <div className="textFieldStyle1">
        <span>Users in General</span>
      </div>
      <div className="fieldStyle1">
        <span>Поле 1</span>
      </div>
      <div className="textFieldStyle2">
        <span>New Users(month)</span>
      </div>
      <div className="fieldStyle2">
        <span>Поле 2</span>
      </div>
      <div className="textFieldStyle3">
        <span>Tour in General</span>
      </div>
      <div className="fieldStyle3">
        <span>Поле 3</span>
      </div>
      <div className="textFieldStyle4">
        <span>New Tours(month)</span>
      </div>
      <div className="fieldStyle4">
        <span>Поле 4</span>
      </div>
      <div className="textFieldStyle5">
        <span>Hand Tours in General</span>
      </div>
      <div className="fieldStyle5">
        <span>Поле 5</span>
      </div>
      <div className="textFieldStyle6">
        <span>New Hand Tours(month)</span>
      </div>
      <div className="fieldStyle6">
        <span>Поле 6</span>
      </div>
      <div className="textFieldStyle7">
        <span>Subs Count</span>
      </div>
      <div className="fieldStyle7">
        <span>Поле 7</span>
      </div>
    </div>

            </>
    );
  };
  
  export default AdminGeneral;