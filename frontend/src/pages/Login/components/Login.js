import React, {useState} from 'react';
import {connect} from 'react-redux';
import {userLoginPostFetch} from '../../../actions/Authentication';

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
    <form onSubmit={handleSubmit}>
      <h1>Login To Your Account</h1>

      <label>Email</label>
      <input
        type="email"
        name='email'
        placeholder='Email'
        value={loginFormData.email}
        onChange={handleChange}
        /><br/>

      <label>Password</label>
      <input
        type='password'
        name='password'
        placeholder='Password'
        value={loginFormData.password}
        onChange={handleChange}
        /><br/>

      <input type='submit'/>
    </form>
  );
};

const mapDispatchToProps = dispatch => ({
  userLoginDataPost: userLoginData => dispatch(userLoginPostFetch(userLoginData))
});

export default connect(null, mapDispatchToProps)(Login);