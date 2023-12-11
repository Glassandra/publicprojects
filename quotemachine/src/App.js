import './App.css';
import { useEffect, useState } from "react";
import quotes from "./quotes.json";


function App() {
  const [quote, setQuote] = useState("");
  const [author, setAuthor] = useState("");

  function handleClick() {
    const randomIndex = Math.floor(Math.random() * quotes.length);
    const randomQuote = quotes[randomIndex];
    setQuote(randomQuote.quote);
    setAuthor(randomQuote.author);
  }

  useEffect(() => {
    handleClick();
  }, []);


  return (
    <div className="App">
      <div id="quote-box" className="quote-box">
        <div className='buttonContainer'>          
          <h2 id="text" class="display quote">{quote}</h2>          
          <h3 id="author" class="display author">{author}</h3>
        </div>
        <div className='buttonContainer'>
          <button className='button' id="new-quote" onClick={handleClick}>New quote</button>
          <a id='tweet-quote' href="twitter.com/intent/tweet" target="_blank"><label>Tweet</label></a>
        </div>
      </div>
    </div>
  )
}

export default App;
