import BearerToken from '../common/helpers/BearerToken';

const storeUserNewsfeed = newsfeed => ({
    type: 'STORE_USER_NEWSFEED',
    payload: newsfeed
});

const updateUserNewsfeed = newPost => ({
    type: 'UPDATE_USER_NEWSFEED',
    payload: newPost
});

const clearUserNewsfeed = ({
    type: 'CLEAR_USER_NEWSFEED'
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

                if (result.length > 0) {
                    dispatch(storeUserNewsfeed(result));
                }
            })
            .catch(error => console.log(error));
    };
};

export const fetchUpdatedNewsfeed = (userId, timeStamp) => {
    return dispatch => {
        return fetch(`/newsfeed-api/v1/newsfeeds/${userId}/${timeStamp}`, {
            method: 'GET',
            headers: {
                'Authorization': BearerToken()
            }
        })
            .then(resp => resp.text())
            .then(data => {
                const result = JSON.parse(data);
                
                if (result.length > 0) {
                    dispatch(updateUserNewsfeed(result));
                }
            })
            .catch(error => console.log(error));
    };
};

export const clearUserNewsfeedAction = () => {
    return dispatch => {
        dispatch(clearUserNewsfeed);
    };
};