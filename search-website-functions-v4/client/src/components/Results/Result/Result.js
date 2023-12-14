import { useState } from "react";

export default function Result(props) {
  const [displayType, setDisplayType] = useState("card");

  console.log(`result prop = ${JSON.stringify(props)}`);

  const toggleDisplayType = () => {
    setDisplayType((prevDisplayType) =>
      prevDisplayType === "card" ? "table" : "card"
    );
  };
  <button onClick={toggleDisplayType}>Toggle Display Type</button>

  if (displayType === "card") {
    return (
      <div>
        <div className="card result">
             <div className="card-body">
             <a href={`/details/${props.document.id}`}>         
              <h5 className="title-style">{props.document.Name}</h5>
              </a>
              <p className="card-text">{props.document.Salary}</p>
              <p className="card-text">{props.document.Client}</p>
              <p className="card-text">{props.document.HiringManager}</p>
              <p className="card-text">{props.document.AddressCity} </p>
            </div>
     
        </div>
      </div>
    );
  } else if (displayType === "table") {
    return (
      <div>
        <table>
          <tr>
            <td>
              <a href={`/details/${props.document.id}`}>
                <h6 className="title-style">{props.document.Name}</h6>
              </a>
            </td>
            <td>
              <p>{props.document.Client}</p>
            </td>
            <td>
              <p>{props.document.Salary}</p>
            </td>
            <td>
              <p>{props.document.HiringManager}</p>
            </td>
            <td>
              <p>{props.document.City}</p>
            </td>
          </tr>
        </table>
      </div>
    );
  }
}
