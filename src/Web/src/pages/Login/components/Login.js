import React, {useState, useEffect} from 'react';
import {connect} from 'react-redux';
import { withRouter, Link } from "react-router-dom";
import {userLoginPostFetch} from '../../../actions/Authentication';
import AuthTemplate from '../../../common/components/AuthTemplateHoc';
import TokenChecker from '../../../common/helpers/TokenChecker';
import './Login.css';

const Login = (props) => {
  const [loginFormData, setLoginFormData] = useState({
    email: "",
    password: "",
    fieldErrors: {
      email: "",
      password: ""
    }
  });

  useEffect(() => {
    const tokenValidator = TokenChecker();

    if (tokenValidator === true) {
      props.history.push(`/projects/instagram/userprofile/${props.currentUserData.userName}`);
    }
  });

  const validate = () => {
    setLoginFormData({
      ...loginFormData,
      fieldErrors: {
        email: "",
        password: ""
      }
    });
    
    let emailError = "";
    let passwordError = "";

    if (!loginFormData.email) {
      emailError = "Email cannot be left blank";
    }

    if (!loginFormData.password) {
      passwordError = "Password cannot be left blank";
    }

    if (emailError || passwordError) {
      setLoginFormData({
        ...loginFormData,
        fieldErrors: {
          email: emailError,
          password: passwordError
        }
      });

      return false;
    }

    return true;
  };

  const handleChange = event => {
    setLoginFormData({
      ...loginFormData,
      [event.target.name]: event.target.value
    });
  };

  const handleSubmit = event => {
    event.preventDefault();
    const isValid = validate();
    if (isValid) {
      props.userLoginDataPost(loginFormData);
      setLoginFormData({
        ...loginFormData,
        fieldErrors: {
          email: "",
          password: ""
        }
      });
    }
  };

  return (
    <div className="wrapper-content">
      <div className="form">
        <div className="form-logo">
          <img src={require('../../../assets/images/instagram-font-logo.png')} alt="instagram-font"/>
        </div>
        <div className="form-fields d-block m-auto col-md-10">
          <div className="field-error">
            {
              Array.isArray(props.loginErrors) ? 
              props.loginErrors.map(error => <p>{error.message}</p>) : 
              <p>{props.loginErrors}</p>
            }
          </div>
          <form onSubmit={handleSubmit}>
            <div className="input-group input-group-sm mb-3">
              <input
                  type="email"
                  className="field-email form-control"
                  name="email"
                  placeholder="Email"
                  value={loginFormData.email}
                  onChange={handleChange}
                  />
            </div>
            <div className="field-error">
              <p>{loginFormData.fieldErrors.email}</p>
            </div>
            
            <div className="input-group input-group-sm mb-3">
              <input
                type="password"
                className="form-control"
                name="password"
                placeholder="Password"
                value={loginFormData.password}
                onChange={handleChange}
                />
            </div>
            <div className="field-error">
              <p>{loginFormData.fieldErrors.password}</p>
            </div>

            <input className="btn btn-primary btn-md btn-block" type='submit'/>
          </form>
        </div>
      </div>
      <div className="signup-link">
        <p>Don't have an account? <Link to="/projects/instagram/signup">Sign up</Link></p>
      </div>
    </div>
  );
};

const mapStateToProps = state => {
  return {
    currentUserData: state.Login.currentUserData,
    loginErrors: state.Login.loginErrors
  }
}

const mapDispatchToProps = dispatch => ({
  userLoginDataPost: userLoginData => dispatch(userLoginPostFetch(userLoginData))
});


export default AuthTemplate(withRouter(connect(mapStateToProps, mapDispatchToProps)(Login)));