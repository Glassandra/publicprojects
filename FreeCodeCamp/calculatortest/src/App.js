import './App.css';
import { useState } from "react";

function App() {

  const [symbolArray, setSymbolArray] = useState([]);
  const [arrayIndex, setArrayIndex] = useState(0);
  const [infoString, setInfoString] = useState("");
  const [currentValue, setCurrentValue] = useState("");
  const [result, setResult] = useState(0);
  const [lastInputWasSymbol, setLastInputWasSymbol] = useState(false);

  function handleErease() {
    setSymbolArray([]);
    setArrayIndex(0);
    setInfoString("");
    setResult(0);
    setCurrentValue("");
  }

  function handleEqual() {
    if (typeof(symbolArray[symbolArray.length-1]) === "number") {
      const tempresult = eval(infoString); 
      var temp = [tempresult];
      setSymbolArray(temp);
      setArrayIndex(tempresult.toString().length + 1);    
      setInfoString(""+ tempresult);
      setCurrentValue("");
      setResult(tempresult);
      setLastInputWasSymbol(false);
    }      
  }

  function handleNumberClick(symbol) {
    if ((arrayIndex === 0 && (symbol === "/" || symbol === "*")) 
        || (arrayIndex === 0 &&  symbol === 0) 
        || (lastInputWasSymbol === true && symbol === 0)
        || (symbol === "." && currentValue.indexOf(".") > -1)
        ) {
      return;
    }
    var nextSymbol;

    if ((typeof(symbolArray[symbolArray.length-1]) !== "number" )
        && (typeof(symbol) === "string" && symbol !== ".")
        && (symbolArray[symbolArray.length-1] === "-" && symbol !== "-")
        ) {
           nextSymbol = [...symbolArray.slice(0,symbolArray.length-2), symbol];
    } else if ((typeof(symbolArray[symbolArray.length-1]) !== "number" )
        && (typeof(symbol) === "string" && symbol !== ".")
        && (symbolArray[symbolArray.length-1] === "-" || symbol !== "-")
        ) {
      nextSymbol = [...symbolArray.slice(0,symbolArray.length-1), symbol];
    } else {
      nextSymbol = [...symbolArray, symbol];      
      setArrayIndex(arrayIndex + 1);
    }        
    setSymbolArray(nextSymbol);
    setInfoString(nextSymbol.join(""));

    if (typeof(symbol) === "string" && symbol !== ".") {
      setCurrentValue("" + symbol);
      setLastInputWasSymbol(true);
    } else if (lastInputWasSymbol === false) {
      setCurrentValue("" + currentValue + symbol);
    } else if (lastInputWasSymbol === true) {
      setCurrentValue("" + symbol);
      setLastInputWasSymbol(false);
    }

  }
 /*  function handleNumberClick(symbol) {
    if ((typeof (symbol) === "string" && typeof(symbolArray[symbolArray.length - 1]) === "string")
     || symbolArray.length > 25  ||
     (result === "" && !typeof(useState[0]) === "number" )) {
      return;
    }
    const nextSymbol = [...symbolArray, symbol];
      

    if (typeof(symbol) === "number" && typeof(currentValue).tonu) {
      setCurrentValue("" + currentValue);
    } else {
      setCurrentValue(symbol);
    }
  } */

  return (
    <div className="App">
      <div className="calculator">
        <div  className="ViewResult">
          <p>{infoString}
          </p>
          <h2 id="display">
            {(currentValue === "") ? result : currentValue}              
          </h2>
        </div>

        <div className='buttonContainer'>
        
          <button className="eraseButton Button" id="clear" onClick={handleErease}>AC</button>
          <button className="otherButton Button" id="divide" onClick={() => handleNumberClick("/")}>/</button>
          <button className="otherButton Button" id="multiply" onClick={() => handleNumberClick("*")}>*</button>

          <button className="numberButton Button" id="seven" onClick={() => handleNumberClick(7)}>7</button>
          <button className="numberButton Button" id="eight" onClick={() => handleNumberClick(8)}>8</button>
          <button className="numberButton Button" id="nine" onClick={() => handleNumberClick(9)}>9</button>
          <button className="otherButton Button" id="subtract" onClick={() => handleNumberClick("-")}>-</button>

          <button className="numberButton Button" id="four" onClick={() => handleNumberClick(4)}>4</button>
          <button className="numberButton Button" id="five" onClick={() => handleNumberClick(5)}>5</button>
          <button className="numberButton Button" id="six" onClick={() => handleNumberClick(6)}>6</button>
          <button className="otherButton Button" id="add" onClick={() => handleNumberClick("+")}>+</button>

          <button className="numberButton Button" id="one" onClick={() => handleNumberClick(1)}>1</button>
          <button className="numberButton Button" id="two" onClick={() => handleNumberClick(2)}>2</button>
          <button className="numberButton Button" id="three" onClick={() => handleNumberClick(3)}>3</button>
          <button  className="otherButton Button" id="decimal" onClick={() => handleNumberClick(".")}>.</button>

          <button className="numberButton Button" id="zero" onClick={() => handleNumberClick(0)}>0</button>
          <button className="equalButton Button" id="equals" onClick={handleEqual}>=</button>
        </div>
      </div>
    </div>
  );
}

export default App;
