import React from 'react';

import logo from '../../images/mercury_small.png';

import './AppHeader.css';

export default function AppHeader() {
  return (
    <header className="header">
      <nav className="navbar navbar-expand-lg">
        <a className="navbar-brand" href="/">
          <img src={logo} height="50" className="navbar-logo" alt="Microsoft" />
        </a>
        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>

        <div className="collapse navbar-collapse" id="navbarSupportedContent">
          <ul className="navbar-nav mr-auto">
            <li className="nav-item">
              <a className="nav-link" href="/search">Search</a>
            </li>   
          </ul>
        </div>


      </nav>
      
    </header>
  );
};
