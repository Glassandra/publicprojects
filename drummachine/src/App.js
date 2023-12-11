import './App.css';
import { useState } from "react";
import { useEffect } from 'react';


function App() {
  const [text, setText] = useState("");

  function handleClick(e) {
    const audio = e.target.querySelector('audio');
    if (audio) {
      audio.play();
    }
    setText(e.target.id);
  }

  function handleKeyPress(e) {
    const keyPressed = e.key.toUpperCase();
    const audio = document.getElementById(keyPressed);
    if (audio) {
      audio.play();
    }
    setText(e.target.id);
  }

  useEffect(() => {
    window.addEventListener("keydown", handleKeyPress);
  return () => {
    window.removeEventListener("keydown", handleKeyPress);
    };
  }, []);

  return (
    <div className="App">
      <div id="drum-machine" className="drummain">
        <div className='buttonContainer'>
          <button className="drum-pad" id="heater-1" onClick={handleClick}>Q
            <audio class="clip" src="https://s3.amazonaws.com/freecodecamp/drums/Heater-1.mp3" preload='true' id="Q"></audio>
          </button>
          <button className="drum-pad" id="heater-2" onClick={handleClick}>W
            <audio class="clip" src="https://s3.amazonaws.com/freecodecamp/drums/Heater-2.mp3" preload='true' id="W"></audio>
          </button>
          <button className="drum-pad" id="heater-3" onClick={handleClick}>E
            <audio class="clip" src="https://s3.amazonaws.com/freecodecamp/drums/Heater-3.mp3" preload='true' id="E"></audio>
          </button>

          <button className="drum-pad" id="heater-4" onClick={handleClick}>A
            <audio class="clip" src="https://s3.amazonaws.com/freecodecamp/drums/Heater-4_1.mp3" preload='true' id="A"></audio>
          </button>
          <button className="drum-pad" id="clap" onClick={handleClick}>S
            <audio class="clip" src="https://s3.amazonaws.com/freecodecamp/drums/Heater-6.mp3" preload='true' id="S"></audio>
          </button>
          <button className="drum-pad" id="open-hh" onClick={handleClick}>D
            <audio class="clip" src="https://s3.amazonaws.com/freecodecamp/drums/Dsc_Oh.mp3" preload='true' id="D"></audio>
          </button>

          <button className="drum-pad" id="kick-n-flat" onClick={handleClick}>Z
            <audio class="clip" src="https://s3.amazonaws.com/freecodecamp/drums/Kick_n_Hat.mp3" preload='true' id="Z"></audio>
          </button>
          <button className="drum-pad" id="kick" onClick={handleClick}>X
            <audio class="clip" src="https://s3.amazonaws.com/freecodecamp/drums/RP4_KICK_1.mp3" preload='true' id="X"></audio>
          </button>
          <button className="drum-pad" id="closed-hh" onClick={handleClick}>C
            <audio class="clip" src="https://s3.amazonaws.com/freecodecamp/drums/Cev_H2.mp3" preload='true' id="C"></audio>
          </button>
        </div>
        <div className='buttonContainer'>
          <h2 id="display" class="display">{text}</h2>
        </div>
      </div>
    </div>
  )
}

export default App;
