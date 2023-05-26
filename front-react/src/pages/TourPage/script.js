import React from 'react';
import Star from './star';


const StarRating = ({starsSelected1, totalStars=5, onRate=f=>f}) =>
<div className="star-rating">    
            {[...Array(totalStars)].map((n, i) =>
            <Star key={i}
             selected={i<starsSelected1}
             onClick={() => onRate(i+1)}/>
             )}
</div>


export default StarRating