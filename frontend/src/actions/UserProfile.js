import BearerToken from '../common/helpers/BearerToken';

const storeUserProfile = userProfileData => ({
    type: 'STORE_USER_PROFILE_DATA',
    payload: userProfileData
});

const clearUserProfile = ({
    type: 'CLEAR_USER_PROFILE_DATA'
});

export const getUserProfileData = (userId) => {
    return dispatch => {
        return fetch(`/api/v1/user-profile/${userId}`, {
            method: 'GET',
            headers: {
                'Authorization': BearerToken()
            }
        })
            .then(resp => resp.text())
            .then(data => {
                const json = JSON.parse(data);
                dispatch(storeUserProfile(json));

                return json;
            })
            .catch(error => console.log(error));
    };
};

export const clearUserProfileData = () => {
    return dispatch => {
        dispatch(clearUserProfile);
    };
};