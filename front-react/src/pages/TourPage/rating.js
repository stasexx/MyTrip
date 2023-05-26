import React, { Component } from 'react';
import StarRating from './script';


const rating = ({rate}) => {
    return ( 
    <>
      <div className="App">
      <StarRating starsSelected={rate} totalStars={5} onRate={rate} />
      </div>

    </> 
    );
}
 
export default rating;
