import React from 'react';
import "./style.css";
import tourImage from "../../img/icon/shopping.png"
const src="http://localhost:5000/Tours";

const AdminTours = () => {

    return (
            <>

<div className="AdminTours">
<img src={tourImage} alt="Image" className="tourImage" />
      <div className="frameStyle1">
        <span>Рамка 1</span>
      </div>
      <div className="frameStyle2">
        <span>Рамка 2</span>
      </div>
      <div className="frameStyle3">
        <span>Рамка 3</span>
      </div>
      <div className="textFrame">
        <span>Enter Tour Id:</span>
        </div>
      <div className="textFrame2">
        <span>#0000001</span>
        </div>
        <div className="textFrame3">
        <span>Venice</span>
        </div>
        <div className="textFrame4">
        <span>Edit</span>
        </div>
      <div className="textFrame5">
        <span>Tour Name</span>
      </div>
      <div className="textFrame6">
        <span>Creation Date</span>
      </div>
      <div className="textFrame7">
        <span>Sales</span>
      </div>
      <div className="textFrame8">
        <span>Rate</span>
      </div>
      <div className="textFrame9">
        <span>Comments Count</span>
      </div>
      <div className="textFrame10">
        <span>Sales(month)</span>
      </div>
      <div className="textFrame11">
        <span>Enter the text</span>
      </div>
      <div className="textFrame12">
        <span>Enter the text</span>
      </div>
      <div className="textFrame13">
        <span>Enter the text</span>
      </div>
      <div className="textFrame14">
        <span>Enter the text</span>
      </div>
      <div className="textFrame15">
        <span>Enter the text</span>
      </div>
      <div className="textFrame16">
        <span>Enter the text</span>
        </div>
      <img src="http://localhost:5000/Tours" alt="Картинка" className="tourImage" />
    </div>

            </>
    );
  };
  
  export default AdminTours;