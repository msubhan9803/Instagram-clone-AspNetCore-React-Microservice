import history from "../common/utils/History";

const storeCurrentUserData = userData => ({
  type: 'STORE_USER_DATA',
  payload: userData
});

const logoutCurrentUser = ({
  type: 'LOGOUT_USER'
});

const loginErrors = errors => ({
  type: 'LOGIN_ERRORS',
  payload: errors
});

const resetLoginErrors = () => ({
  type: 'RESET_LOGIN_ERRORS'
});

const signUpErrors = errors => ({
  type: 'SIGNUP_ERRORS',
  payload: errors
});

const resetSignUpErrors = () => ({
  type: 'RESET_SIGNUP_ERRORS'
});

export const userSignUpPostFetch = userSignUpData => {
  return dispatch => {
    return fetch(`${process.env.REACT_APP_BACKEND_URL}/user-api/v1/accounts/`, {
      method: "POST",
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json',
      },
      body: JSON.stringify(userSignUpData)
    })
    .then(resp => {
      if (!resp.ok) {
        throw resp.text();
      }

      dispatch(resetSignUpErrors());
      alert("You have successfully Registered! Please Login to continue");
      history.push("/");
    })
    .catch(error => {
      Promise.resolve(error).then((value) =>{
        var result = JSON.parse(value);
        
        if (result.error) {
          console.log(result.error);
          dispatch(signUpErrors(result.error));
        } else {
          console.log(result.errors);
          dispatch(signUpErrors(result.errors));
        }
      });
    });
  };
};

export const userLoginPostFetch = userLoginData => {
  return dispatch => {
    return fetch(`${process.env.REACT_APP_BACKEND_URL}/user-api/v1/accounts/login`, {
      method: "POST",
      headers: {
        'Content-Type': 'application/json',
        Accept: 'application/json'
      },
      body: JSON.stringify(userLoginData)
    })
    .then(response => {
      if (!response.ok) {
        throw response.text();
      }

      return response
    })
    .then(resp => resp.text())
    .then(data => {
      var result = JSON.parse(data);

      dispatch(storeCurrentUserData(result.user));
      localStorage.setItem("token", result.token.token);
      localStorage.setItem("expires", result.token.expires);
      dispatch(resetLoginErrors());
      history.push(`/userprofile/${result.user.userName}`);
    })
    .catch(error => {
      Promise.resolve(error).then((value) =>{
        var result = JSON.parse(value);
        
        if (result.error) {
          dispatch(loginErrors(result.error));
        } else {
          dispatch(loginErrors(result.errors));
        }
      });
    });
  };
};

export const logoutUser = () => {
  return dispatch => {
    return () => {
      dispatch(logoutCurrentUser);
      localStorage.removeItem("token");
      localStorage.removeItem("expires");
      history.push("/");
    }
  };
};