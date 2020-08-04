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
    confirmPassword: "",
    fieldErrors: {
      username: "",
      email: "",
      password: "",
      confirmPassword: ""
    }
  });

  const validate = () => {
    setSignUpFormData({
      ...signUpFormData,
      fieldErrors: {
        username: "",
        email: "",
        password: "",
        confirmPassword: ""
      }
    });
    
    let usernameError = "";
    let emailError = "";
    let passwordError = "";
    let confirmPasswordError = "";

    if (!signUpFormData.username) {
      usernameError = "Username cannot be left blank";
    } else if (!/(?=.*\d)(?=.*[a-z])(?=.*[A-Z])/.test(signUpFormData.username)) {
      usernameError = "Username must contain at least one uppercase letter, at least one lowercase letter and at least one digit";
    }

    if (!signUpFormData.email) {
      emailError = "Email cannot be left blank";
    }

    if (!signUpFormData.password) {
      passwordError = "Password cannot be left blank";
    } else if (!/(?=.*\d)(?=.*[a-z])(?=.*[A-Z])/.test(signUpFormData.password)) {
      passwordError = "Password must contain at least one uppercase letter, at least one lowercase letter and at least one digit";
    } else if (signUpFormData.password <= 12) {
      passwordError = "Password must be 8 to 12 characters";
    }
    
    if (!signUpFormData.confirmPassword) {
      confirmPasswordError = "ConfirmPassword cannot be left blank";
    } else if (signUpFormData.confirmPassword !== signUpFormData.password) {
      confirmPasswordError = "Passwords don't match";
    }

    if (usernameError || emailError || passwordError || confirmPasswordError) {
      setSignUpFormData({
        ...signUpFormData,
        fieldErrors: {
          username: usernameError,
          email: emailError,
          password: passwordError,
          confirmPassword: confirmPasswordError
        }
      });

      return false;
    }

    return true;
  };

  const handleChange = event => {
    setSignUpFormData({
      ...signUpFormData,
      [event.target.name]: event.target.value
    });
  };

  const handleSubmit = event => {
    event.preventDefault()
    const isValid = validate();
    if (isValid) {
      props.userSignUpDataPost(signUpFormData);
      setSignUpFormData({
        ...signUpFormData,
        fieldErrors: {
          username: '',
          email: '',
          password: '',
          confirmPassword: ""
        }
      });
    } else {
      console.log(isValid);
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
              Array.isArray(props.registerErrors) ? 
              props.registerErrors.map(error => <p>{error.message}</p>) : 
              <p>{props.registerErrors}</p>
            }
          </div>
          <form onSubmit={handleSubmit}>
            <div className="input-group input-group-sm mb-3">
              <input
                type='text'
                className="form-control"
                name='username'
                placeholder='Username'
                value={signUpFormData.username}
                onChange={handleChange}
                /><br/>
            </div>
            <div className="field-error">
              <p>{signUpFormData.fieldErrors.username}</p>
            </div>
            
            <div className="input-group input-group-sm mb-3">
              <input
                type='email'
                className="form-control"
                name='email'
                placeholder='Email'
                value={signUpFormData.email}
                onChange={handleChange}
                /><br/>
            </div>
            <div className="field-error">
              <p>{signUpFormData.fieldErrors.email}</p>
            </div>
            
            <div className="input-group input-group-sm mb-3">
              <input
                type='password'
                className="form-control"
                name='password'
                placeholder='Password'
                value={signUpFormData.password}
                onChange={handleChange}
                /><br/>
            </div>
            <div className="field-error">
              <p>{signUpFormData.fieldErrors.password}</p>
            </div>
            
            <div className="input-group input-group-sm mb-3">
              <input
                type='password'
                className="form-control"
                name='confirmPassword'
                placeholder='Confirm Password'
                value={signUpFormData.confirmPassword}
                onChange={handleChange}
                /><br/>
            </div>
            <div className="field-error">
              <p>{signUpFormData.fieldErrors.confirmPassword}</p>
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

const mapStateToProps = state => {
  return {
		registerErrors: state.Authentication.registerErrors
	}
}

const mapDispatchToProps = dispatch => ({
  userSignUpDataPost: userSignUpData => dispatch(userSignUpPostFetch(userSignUpData))
});

export default AuthTemplate(connect(mapStateToProps, mapDispatchToProps)(SignUp));