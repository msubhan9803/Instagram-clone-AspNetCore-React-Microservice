import React, { useState } from 'react';
import { connect } from 'react-redux';
import './Navbar.css';
import { logoutUser } from '../../../actions/Authentication';

const Navbar = (props) => {
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

    const logout = event => {
        event.preventDefault();
        props.logoutUser();
    };

    return (
        <nav className="navbar navbar-light sticky-top">
            <a className="navbar-brand" href={`/newsfeed`}>
                <img src={require('../../../assets/images/instagram-navbar-logo.png')} width="30" height="30" alt="" />
            </a>
            <form onSubmit={handleSubmit}>
                <input className="form-control search-field mr-md-4" type="search"
                    name="search" placeholder="&#xF002; Search" aria-label="Search"
                    value={searchState.search} onChange={handleChange} />
            </form>
            <div className="row">
                <a className="mr-3" style={{color: "#000"}} href="/newsfeed"><i className="fa fa-2x fa-home" aria-hidden="true"></i></a>
                <a className="mr-3" style={{color: "#000"}} href="/create"><i className="fa fa-2x fa-plus-circle"></i></a>
                
                <div className="userprofile mr-3">
                    <div className="dropdown">
                        <a type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <i className="fa fa-2x fa-user-circle text-dark" aria-hidden="true"></i>
                        </a>
                        <div className="dropdown-menu dropdown-menu-center text-left" aria-labelledby="dropdownMenuButton">
                            <a className="dropdown-item" href={`/userprofile/${props.currentUserData.userName}`}>
                                <i className="fa fa-user-circle text-dark mr-2" aria-hidden="true"></i> Profile
                        </a>
                            <a className="dropdown-item" href="/accounts/edit"><i className="fa fa-bars mr-2"></i> Settings</a>
                            <hr />
                            <a className="dropdown-item" onClick={logout}>Log Out</a>
                        </div>
                    </div>
                </div>
            </div>
        </nav>
    );
};

const mapStateToProps = state => {
    return {
        currentUserData: state.Login.currentUserData
    }
};

const mapDispatchToProps = dispatch => ({
    logoutUser: dispatch(logoutUser())
});

export default connect(mapStateToProps, mapDispatchToProps)(Navbar);