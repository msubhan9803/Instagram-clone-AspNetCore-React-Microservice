import BearerToken from '../../../common/helpers/BearerToken';

const fetchUserId = (userName) => {
    return fetch(`/user-api/v1/users/${userName}`, {
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