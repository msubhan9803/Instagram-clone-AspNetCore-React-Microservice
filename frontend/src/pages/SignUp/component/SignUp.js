import React, {useState} from 'react';
import {connect} from 'react-redux';
import {userSignUpPostFetch} from '../../../actions/Authentication';
import AuthTemplate from '../../../common/components/AuthTemplateHoc';
import './SignUp.css';

const SignUp = (props) => {
  const [signUpFormData, setSignUpFormData] = useState({
    username: "",
    email: "",
    password: "",
    confirmPassword: ""
  });

  const handleChange = event => {
    setSignUpFormData({
      ...signUpFormData,
      [event.target.name]: event.target.value
    });
  };

  const handleSubmit = event => {
    event.preventDefault()
    props.userSignUpDataPost(signUpFormData)
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
                class="form-control"
                name='username'
                placeholder='Username'
                value={signUpFormData.username}
                onChange={handleChange}
                /><br/>
            </div>
            
            <div class="input-group input-group-sm mb-3">
              <input
                class="form-control"
                name='email'
                placeholder='Email'
                value={signUpFormData.email}
                onChange={handleChange}
                /><br/>
            </div>
            
            <div class="input-group input-group-sm mb-3">
              <input
                class="form-control"
                type='password'
                name='password'
                placeholder='Password'
                value={signUpFormData.password}
                onChange={handleChange}
                /><br/>
            </div>
            
            <div class="input-group input-group-sm mb-3">
              <input
                class="form-control"
                type='password'
                name='confirmPassword'
                placeholder='Confirm Password'
                value={signUpFormData.confirmPassword}
                onChange={handleChange}
                /><br/>
            </div>
            <div className="term">
              <p>By signing up, you agree to our <strong>Terms &amp; Privacy Policy</strong></p>
            </div>
            <input className="btn btn-primary btn-md btn-block" type='submit'/>
          </form>
        </div>
      </div>
      <div className="login-link">
        <p>Already have an account? <a href="/login">Login</a></p>
      </div>
    </div>
  );
};

const mapDispatchToProps = dispatch => ({
  userSignUpDataPost: userSignUpData => dispatch(userSignUpPostFetch(userSignUpData))
});

export default AuthTemplate(connect(null, mapDispatchToProps)(SignUp));