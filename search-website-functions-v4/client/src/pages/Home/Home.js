import React from "react";
import { useNavigate } from "react-router-dom";

import SearchBar from '../../components/SearchBar/SearchBar';

import "./Home.css";
import "../../pages/Search/Search.css";
import logo from '../../images/cognitive_search.jpg';

export default function Home() {
  const navigate = useNavigate();
  const navigateToSearchPage = (q) => {
    if (!q || q === '') {
      q = '*'
    }
    navigate('/search?q=' + q);
  }

  return (
    <main className="main main--home">
      <div className="row home-search">
        <img className="logo" src={logo} alt="Cognitive Search"></img>
        <br></br>
        <h1 className="poweredby lead">Douglas's Comparison Report - Powered by Azure AI Search</h1>
        <br></br>
        <br></br>
        <SearchBar postSearchHandler={navigateToSearchPage}></SearchBar>
      </div>
    </main>
  );
};
