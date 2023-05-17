import Tour from "../Components/tour/Tour";
import news from "./../img/icon/news.png";

const  MainPge= () => {
    return ( 
    <>

 <main className="section">
        <div className="container">
        <img className="news" src={news} alt="Link"/>
        <h2 class="text-header">POPULAR TOUR</h2>
            <ul className="popular-tours">
                <Tour/>
                <Tour/>
                <Tour/>
            </ul>
        </div>
    </main>
    
    
    </> );
}
 
export default MainPge;