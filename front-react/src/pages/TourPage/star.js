import React from 'react';
import styles from './Stules.module.css';

const Star = ({ selected = false, onClick = () => {} }) => (
  <div className={selected ? `${styles.star} ${styles.selected}` : styles.star} onClick={onClick}></div>
);

export default Star;