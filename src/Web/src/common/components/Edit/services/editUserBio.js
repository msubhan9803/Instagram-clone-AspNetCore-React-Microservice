import BearerToken from '../../../helpers/BearerToken';

export const fetchUserBio = (userId) => {
    return fetch(`${process.env.REACT_APP_BACKEND_URL}/user-api/v1/userBios/${userId}`, {
        method: "GET",
        headers: {
            'Authorization': BearerToken()
        }
    })
    .then(response => {
      if (response.status === 204) {
        return null;
      }

      return response.text();
    })
    .then(result => {
        var json = JSON.parse(result);
        return json;
    });
};

export const postUserBioRequest = (userBio) => {
    for (var pair of userBio.entries()) {
        console.log(pair[0] + ', ' + pair[1]);
    }

    return fetch(`${process.env.REACT_APP_BACKEND_URL}/user-api/v1/userBios/`, {
        method: 'POST',
        headers: {
            'Authorization': BearerToken()
        },
        body: userBio
    })
    .then(data => {
        var json = JSON.parse(data);
        return json;
    })
    .catch(error => null);
};

export const updateUserBio = (userBio) => {
    return fetch(`${process.env.REACT_APP_BACKEND_URL}/user-api/v1/userBios/${userBio.id}`, {
        method: 'PUT',
        headers: {
            'Authorization': BearerToken(),
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userBio)
    })
    .then(data => {
        var json = JSON.parse(data);
        return json;
    })
    .catch(error => null);
};