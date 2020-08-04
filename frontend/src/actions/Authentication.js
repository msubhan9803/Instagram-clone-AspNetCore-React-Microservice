export const userSignUpPostFetch = userSignUpData => {
  return dispatch => {
    return fetch("/user-api/v1/accounts/", {
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

      alert("You have successfully registered! Please Login to continue")
    })
    .catch(error => {
      Promise.resolve(error).then((value) =>{
        var result = JSON.parse(value);
        console.log(result.errors);
        if (result.error) {
          dispatch(registerErrors(result.error));
        } else {
          dispatch(registerErrors(result.errors));
        }
      });
    });
  };
};

export const userLoginPostFetch = userLoginData => {
  return dispatch => {
    return fetch("/user-api/v1/accounts/login", {
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
      console.log(data);
      var result = JSON.parse(data);
      localStorage.setItem("token", result.token);
      localStorage.setItem("expires", result.expires);
      dispatch(loginUser(data.user));
    })
    .catch(error => {
      Promise.resolve(error).then((value) =>{
        var result = JSON.parse(value);
        console.log(result.errors);
        if (result.error) {
          dispatch(loginErrors(result.error));
        } else {
          dispatch(loginErrors(result.errors));
        }
      });
    });
  };
};

const loginUser = userObj => ({
    type: 'LOGIN_USER',
    payload: userObj
});

const loginErrors = errors => ({
  type: 'LOGIN_ERRORS',
  payload: errors
});

const registerErrors = errors => ({
  type: 'REGISTER_ERRORS',
  payload: errors
});