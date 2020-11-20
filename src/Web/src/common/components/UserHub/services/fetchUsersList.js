    import BearerToken from '../../../helpers/BearerToken';

const fetchUsersList = () => {
    return fetch('/user-api/v1/users/', {
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

export default fetchUsersList;