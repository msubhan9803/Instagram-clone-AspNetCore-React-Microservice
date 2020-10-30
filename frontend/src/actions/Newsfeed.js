import BearerToken from '../common/helpers/BearerToken';

const storeUserNewsfeed = newsfeed => ({
    type: 'STORE_USER_NEWSFEED',
    payload: newsfeed
});

export const fetchInitial = (userId) => {
    return dispatch => {
        return fetch(`/newsfeed-api/v1/newsfeeds/${userId}`, {
            method: 'GET',
            headers: {
                'Authorization': BearerToken()
            }
        })
            .then(resp => resp.text())
            .then(data => {
                const result = JSON.parse(data);
                dispatch(storeUserNewsfeed(result));
            })
            .catch(error => console.log(error));
    };
};