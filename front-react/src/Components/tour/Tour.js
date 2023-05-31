import styles from './Stules.module.css';
import StRating from './rating';
import wish_button from "./../../img/icon/wish_button.png";
import wish_button_black from "./../../img/icon/wish_button_black.png";



const Tour = ({name, main_photo, rate,tourId}) => {


    function show(e) {

        var btn = document.getElementById(2);

        btn.addEventListener("click", function() {
            if(this.classList.contains('wish')){
                this.classList.remove('wish');
            }else {
                this.classList.add('wish');
            }
        });
    }

    return ( 

        <li id="dfg"className={styles.tour}>
            <a href={`./tour/${tourId}`}>
                <img src={main_photo} alt="Project img" className={styles.tour__img}/>
                <h3 className={styles.tour__title}>{name}</h3>
                <div className={styles.tour__rating}><StRating rate={rate}/></div>
            </a>
            <a id="2" className={styles.wishlist} onClick={show} >
                <img src={wish_button} alt="" className={styles.like__img}/>
            </a>
        </li>
    );
}
 
export default Tour;