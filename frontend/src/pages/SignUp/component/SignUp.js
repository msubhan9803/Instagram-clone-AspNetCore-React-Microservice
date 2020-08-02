import React, {useState} from 'react';
import {connect} from 'react-redux';
import {userSignUpPostFetch} from '../../../actions/Authentication';
import AuthTemplate from '../../../common/components/AuthTemplateHoc';

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
    <form onSubmit={handleSubmit}>
      <h1>Sign Up For An Account</h1>

      <label>Username</label>
      <input
        name='username'
        placeholder='Username'
        value={signUpFormData.username}
        onChange={handleChange}
        /><br/>

      <label>Email</label>
      <input
        name='email'
        placeholder='Email'
        value={signUpFormData.email}
        onChange={handleChange}
        /><br/>

      <label>Password</label>
      <input
        type='password'
        name='password'
        placeholder='Password'
        value={signUpFormData.password}
        onChange={handleChange}
        /><br/>

      <label>Confirm Password</label>
      <input
        type='confirmPassword'
        name='confirmPassword'
        placeholder='Confirm Password'
        value={signUpFormData.confirmPassword}
        onChange={handleChange}
        /><br/>

      <input type='submit'/>
    </form>
  );
};

const mapDispatchToProps = dispatch => ({
  userSignUpDataPost: userSignUpData => dispatch(userSignUpPostFetch(userSignUpData))
});

export default AuthTemplate(connect(null, mapDispatchToProps)(SignUp));