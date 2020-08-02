import React, {useState} from 'react';
import {connect} from 'react-redux';
import {userLoginPostFetch} from '../../../actions/Authentication';
import AuthTemplate from '../../../common/components/AuthTemplateHoc';
import './Login.css';

const Login = (props) => {
  const [loginFormData, setLoginFormData] = useState({
    email: "",
    password: ""
  });

  const handleChange = event => {
    setLoginFormData({
      ...loginFormData,
      [event.target.name]: event.target.value
    });
  };

  const handleSubmit = event => {
    event.preventDefault();
    props.userLoginDataPost(loginFormData);
  };

  return (
    <div className="wrapper-content">
      <div className="form">
        <div className="form-logo">
          <img src={require('../../../assets/images/instagram-font-logo.png')} alt="instagram-font"/>
        </div>
        <div className="form-fields d-block m-auto col-md-10">
          <form onSubmit={handleSubmit}>
            <div class="input-group input-group-sm mb-3">
              <input
                  type="email"
                  class="field-email form-control"
                  name="email"
                  placeholder="Email"
                  value={loginFormData.email}
                  onChange={handleChange}
                  />
            </div>
            
            <div class="input-group input-group-sm mb-3">
              <input
                type="password"
                class="form-control"
                name="password"
                placeholder="Password"
                value={loginFormData.password}
                onChange={handleChange}
                />
            </div>
            <input className="btn btn-primary btn-md btn-block" type='submit'/>
          </form>
        </div>
      </div>
      <div className="signup-link">
        <p>Don't have an account? <a href="/signup">Sign up</a></p>
      </div>
    </div>
  );
};

const mapDispatchToProps = dispatch => ({
  userLoginDataPost: userLoginData => dispatch(userLoginPostFetch(userLoginData))
});

export default AuthTemplate(connect(null, mapDispatchToProps)(Login));