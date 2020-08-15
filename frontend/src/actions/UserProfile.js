import BearerToken from '../common/helpers/BearerToken';

export const getUserProfileData = (userId) => {
    return dispatch => {
        return fetch('/api/v1/user-profile/' + userId, {
            method: 'GET',
            headers: {
              'Authorization': BearerToken()
            }
        })
        .then(resp => resp.text())
        .then(data => console.log(data))
        .catch(error => console.log(error));
    };
};