export default function Result(props) {

  console.log(`result prop = ${JSON.stringify(props)}`);


    return (
      <div>
        <div className="card result">
             <div className="card-body">          
              <h6 className="title-style">{props.document.Name}</h6>      
              <p className="card-text">{props.document.Salary}</p>
              <p className="card-text">{props.document.Client}</p>
              <p className="card-text">{props.document.HiringManager}</p>
              <p className="card-text">{props.document.AddressCity} </p>
            </div>     
        </div>
      </div>
    );
  } 
