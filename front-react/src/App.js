import "./styles/main.css"; 

import logo from "./img/icon/logo.png"; 
import wish_list from "./img/icon/icon wish list.png"; 
import tours from "./img/icon/icon tours.png"; 
import sign_in from "./img/icon/icon sign in.png"; 
import about_us from "./img/icon/icon about us.png"; 
function App() {
  return (
    <div className="App">

    <nav className="nav">
        <div className="container">
            <div className="nav-row">
                <a href="./index.html" className="logo"><img src={logo} alt="Link"/></a>
                    <ul className="nav-list">
                        <li className="nav-list__item"><a href="./index.html" className="nav-list__link"><img src={about_us} alt="Link"/>About us</a></li>
                        <li className="nav-list__item"><a href="./projects.html" className="nav-list__link"><img src={tours} alt="Link"/>Tours</a></li>
                        <li className="nav-list__item"><a href="./projects.html" className="nav-list__link"><img src={sign_in} alt="Link"/>Sign in</a></li>
                        <li className="nav-list__item"><a href="./contacts.html" className="nav-list__link"><img src={wish_list} alt="Link"/>Wish list</a></li>
                    </ul>
            </div>
        </div>
    </nav>

    <header className="header">
        <div className="header__wrapper">
            <h1 className="header__title">
                <strong>Hi, my name is <em>Yuri</em></strong><br/>
                a frontend developer
            </h1>
            <div className="header__text">
                <p>with passion for learning and creating.</p>
            </div>
            <a href="#!" className="btn">Download CV</a>
        </div>
    </header>

    <main className="section">
        <div className="container">

                <ul className="content-list">
                    <li className="content-list__item">
                        <h2 className="title-2">Frontend</h2>
                        <p>JavaScript, TypeScript, ReactJS, Angular, Redux, HTML, CSS, NPM, BootStrap, MaterialUI, Yarn, TailwindCSS, StyledComponents</p>
                    </li>
                    <li className="content-list__item">
                        <h2 className="title-2">Backend</h2>
                        <p>NodeJS, MySQL, MongoDB, PHP, Laravel</p>
                    </li>
                </ul>

        </div>
    </main>

    <footer className="footer">
        <div className="container">
            <div className="footer__wrapper">
                <ul className="social">
                    <li className="social__item"><a href="#!"><img src="./img/icons/vk.svg" alt="Link"/></a></li>
                    <li className="social__item"><a href="#!"><img src="./img/icons/instagram.svg" alt="Link"/></a></li>
                    <li className="social__item"><a href="#!"><img src="./img/icons/twitter.svg" alt="Link"/></a></li>
                    <li className="social__item"><a href="#!"><img src="./img/icons/gitHub.svg" alt="Link"/></a></li>
                    <li className="social__item"><a href="#!"><img src="./img/icons/linkedIn.svg" alt="Link"/></a></li>
                </ul>
                <div className="copyright">
                    <p>© 2022 frontend-dev.com</p>
                </div>
            </div>
        </div>
    </footer>

    </div>
  );
}

export default App;
