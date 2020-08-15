import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import './Navbar.css';

const Navbar = () => {
    const [searchState, setSearchState] = useState({
        search: ''
    });

    const handleChange = event => {
        setSearchState({
            ...searchState,
            [event.target.name]: event.target.value
        })
    };

    const handleSubmit = event => {
        event.preventDefault();
        console.log("You searched: " + searchState.search);
        console.log(searchState);
    };

    return (
        <nav className="navbar navbar-light sticky-top">
            <a className="navbar-brand" href="/userprofile">
                <img src={require('../../../assets/images/instagram-navbar-logo.png')} width="30" height="30" alt="" />
            </a>
            <form onSubmit={handleSubmit}>
                <input className="form-control search-field mr-md-4" type="search" 
                    name="search" placeholder="&#xF002; Search" aria-label="Search" 
                    value={searchState.search} onChange={handleChange}/>
            </form>
            <div className="navbar-nav">
                <Link to="/userprofile"><i className="fa fa-2x fa-user-circle text-dark" aria-hidden="true"></i></Link>
            </div>
        </nav>
    );
};

export default Navbar;