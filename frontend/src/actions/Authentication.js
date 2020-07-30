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
      console.log(resp.status);
    });
    // .then(data => {
    //   if (data.errors) {
    //     console.log(data.errors);
    //   }
    // });
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
    .then(resp => {
      console.log(resp.status);
      resp.json();
      console.log(resp);
    });
    // .then(data => {
    //   let json = JSON.parse(data);
    //   if (json["errors"]) {
    //     console.log("here");
    //   } else {
    //     localStorage.setItem("token", data.token);
    //     dispatch(loginUser(data.user));
    //   }
    // });
  };
};

const loginUser = userObj => ({
    type: 'LOGIN_USER',
    payload: userObj
});