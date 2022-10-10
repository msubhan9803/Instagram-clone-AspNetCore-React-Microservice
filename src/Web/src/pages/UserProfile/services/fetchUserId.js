import BearerToken from '../../../common/helpers/BearerToken';

const fetchUserId = (userName) => {
    return fetch(`${process.env.REACT_APP_BACKEND_URL}/user-api/v1/users/${userName}`, {
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

export default fetchUserId;