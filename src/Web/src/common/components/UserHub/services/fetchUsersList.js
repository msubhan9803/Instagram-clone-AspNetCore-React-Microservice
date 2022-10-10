    import BearerToken from '../../../helpers/BearerToken';

const fetchUsersList = () => {
    return fetch(`${process.env.REACT_APP_BACKEND_URL}/user-api/v1/users/`, {
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