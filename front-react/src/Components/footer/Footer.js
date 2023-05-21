import"./styles.css"
import travel_concept_footer from "./../../img/footer/travel_concept_footer.png";

import footer_tg_bot from "./../../img/footer/footer_tg_bot.png";
import footer_email from "./../../img/footer/footer_email.png";
import footer_map from "./../../img/footer/footer_map.png";
import footer_phone from "./../../img/footer/footer_phone.png";
const Footer = () => {
    return (  
    <>
        <footer className="footer">
        <img className="footer_img" src={travel_concept_footer}/>
        <div className="container">
                <div className="footer__wrapper">

                <ul className="social">
                        <li className="social__item"><a><img  className="img_footer" src={footer_email} />trip_my@gmail.com</a></li>
                        <li className="social__item"><a ><img className="img_footer" src={footer_map}/>Ukraine, Lviv, 79035147 Zelena Street</a></li>
                        <li className="social__item"><a><img className="img_footer" src={footer_phone}/>+380-50-373-5343</a></li>
                        <li className="social__item"><a href="http://t.me/MyTrip_support_bot"><img className="img_footer" src={footer_tg_bot}/>Telegram bot support</a></li>
                </ul>
                    <div className="copyright">
                        <p>© 2022 Teamprogerov</p>
                    </div>
                </div>
            </div>
        </footer>
    </>);
}
 
export default Footer;