import BearerToken from '../../../helpers/BearerToken';

export const fetchUserBio = (userId) => {
    return fetch(`/user-api/v1/userBios/${userId}`, {
        method: "GET",
        headers: {
            'Authorization': BearerToken()
        }
    })
    .then(result => result.text())
    .then(data => {
        var json = JSON.parse(data);
        return json;
    })
};

export const updateUserBio = (userBio) => {
    return fetch(`/user-api/v1/userBios/${userBio.id}`, {
        method: 'PUT',
        headers: {
            'Authorization': BearerToken(),
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userBio)
    })
    .then(result => result.text())
    .then(data => data);
};