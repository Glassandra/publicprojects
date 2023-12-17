import './App.css';
import { useEffect, useState } from "react";


function App() {
  const [breakLength, setBreakLength] = useState(5);
  const [sessionLength, setSessionLength] = useState(25);
  const [timerSeconds, setTimerSeconds] = useState(0);
  const [timerMinutes, setTimerMinutes] = useState(25);
  const [isRunning, setIsRunning] = useState(false);
  const [isBreak, setIsBreak] = useState(false);
  const [sessiontText, setSessionText] = useState('Session');

  useEffect(() => {
    let interval = null;
    let audioElement = document.getElementById('beep');

    audioElement.addEventListener('ended', () => {
      audioElement.currentTime = 0;
    });
  
    if (isRunning) {
      interval = setInterval(() => {
        if (timerSeconds > 0) {
          setTimerSeconds(timerSeconds - 1);
        } else if (timerSeconds === 0) {
          if (timerMinutes === 0) {
            clearInterval(interval);
            audioElement.play();
            setIsRunning(false);
            if (!isBreak) {
              setIsBreak(true);
              setSessionText('Break');
              setTimerMinutes(breakLength);
              setTimerSeconds(0);
            } else {
              setIsBreak(false);
              setSessionText('Session');
              setTimerMinutes(sessionLength);
              setTimerSeconds(0);
            }
            setIsRunning(true);
          } else {
            setTimerMinutes(timerMinutes - 1);
            setTimerSeconds(59);
          }
        }
      }, 1000);
    } else if (!isRunning && timerSeconds !== 0) {
      clearInterval(interval);
    }
  
    return () => {
      clearInterval(interval);
      audioElement.removeEventListener('ended', () => {
        audioElement.currentTime = 0;
      } );
    }
  }, [isRunning, timerMinutes,timerSeconds, isBreak, breakLength, sessionLength]	);

  function formatTime(minutes, seconds) {
    let formattedSeconds = seconds < 10 ? `0${seconds}` : seconds;
    let formattedMinutes = minutes < 10 ? `0${minutes}` : minutes;
    return `${formattedMinutes}:${formattedSeconds}`;
  }



  function handleClick(e) {
    switch (e.target.id) {
      case 'break-decrement':
        if (breakLength > 1) {
          setBreakLength(breakLength - 1);
          if (isBreak) {
            setTimerMinutes(timerMinutes - 1);
          }
        }
        break;
      case 'break-increment':
        if (breakLength < 60) {
          setBreakLength(breakLength + 1)
          if (isBreak) {
            setTimerMinutes(timerMinutes + 1);
          }
        }
        break;
      case 'session-decrement': 
        if (sessionLength > 1) {
          setSessionLength(sessionLength - 1);
          if (!isBreak) {
            setTimerMinutes(timerMinutes - 1);
          }
        }
        break;
      case 'session-increment':
        if (sessionLength < 60) {
          setSessionLength(sessionLength + 1);   
          if (!isBreak) {
            setTimerMinutes(timerMinutes + 1);
          }
        }
        break;
      case 'start_stop':
        setIsRunning(!isRunning);
        break;
      case  'reset':
        setBreakLength(5);
        setSessionLength(25);
        setTimerSeconds(0);
        setTimerMinutes(25);
        setIsRunning(false);
        document.getElementById('beep').pause();
        document.getElementById('beep').currentTime = 0;
        setIsBreak(false);
        setSessionText('Session');
        break;
      default:
          break;
  }
}


  return (
    <div className="App">
      <div id="quote-box" className="quote-box">
        <div className='buttonContainer'>
          <div className='breakContainer'>
          <h2 id="break-label">Break Length</h2>
          <button className='button' id="break-decrement" onClick={handleClick}>-</button>
          <h3 id="break-length">{breakLength}</h3>
          <button className='button' id="break-increment" onClick={handleClick}>+</button>
          </div>

          <div className='breakContainer'>
          <h2 id="session-label">Session Length</h2>
          <button className='button' id="session-decrement" onClick={handleClick}>-</button>
          <h3 id="session-length">{sessionLength}</h3>
          <button className='button' id="session-increment" onClick={handleClick}>+</button>
          </div>
        </div>

        <div className='timerContainer'>
          <h2 id="timer-label">{sessiontText}</h2>
          <h3 id="time-left">{formatTime(timerMinutes,timerSeconds)}</h3>
          <audio id="beep" src="https://raw.githubusercontent.com/freeCodeCamp/cdn/master/build/testable-projects-fcc/audio/BeepSound.wav" preload='true'></audio>
        </div>

        <div className='buttonContainer'>
          <button className='button' id="start_stop" onClick={handleClick}>Start/Stop</button>
          <button className='button' id="reset" onClick={handleClick}>Reset</button>
        </div>
      </div>
    </div>
  )
}

export default App;