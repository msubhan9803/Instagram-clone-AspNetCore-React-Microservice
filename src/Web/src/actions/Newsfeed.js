import BearerToken from '../common/helpers/BearerToken';

const storeUserNewsfeed = payload => ({
    type: 'STORE_USER_NEWSFEED',
    payload: payload
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
        return fetch(`${process.env.REACT_APP_BACKEND_URL}/newsfeed-api/v1/newsfeeds/${userId}`, {
            method: 'GET',
            headers: {
                'Authorization': BearerToken()
            }
        })
            .then(resp => resp.text())
            .then(data => {
                const result = JSON.parse(data);
                console.log("Initialized Newsfeed");
                var fetchedAt = result.length > 0 ? new Date(result[0].createdAt).getTime() : Date.now();
                
                var payload = {
                    newsfeed: result,
                    fetchedAt: fetchedAt
                };

                dispatch(storeUserNewsfeed(payload));
            })
            .catch(error => console.log(error));
    };
};

export const fetchUpdatedNewsfeed = (userId, currentNewsfeed, fetchedAt) => {
    return dispatch => {
        return fetch(`${process.env.REACT_APP_BACKEND_URL}/newsfeed-api/v1/newsfeeds/${userId}/${fetchedAt}`, {
            method: 'GET',
            headers: {
                'Authorization': BearerToken()
            }
        })
            .then(resp => resp.text())
            .then(data => {
                const result = JSON.parse(data);
                console.log("Updating Newsfeed");

                if (result.length > 0) {
                    var newPosts = result;
                    var newNewsfeed = newPosts.concat(currentNewsfeed);

                    var payload = {
                        newsfeed: newNewsfeed,
                        fetchedAt: new Date(newNewsfeed[0].createdAt).getTime()
                    };

                    dispatch(updateUserNewsfeed(payload));
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