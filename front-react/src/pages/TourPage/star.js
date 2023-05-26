import React from 'react';

 const Star = ({ selected1=false, onClick=f=>f }) =>
    <div className={ (selected1) ? "star selected" : "star" } onClick={onClick}>
    </div>


export default Star