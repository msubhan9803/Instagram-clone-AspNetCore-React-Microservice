import BearerToken from '../../../common/helpers/BearerToken';

export const fetchUserRelation = (userId, followedUserId) => {
    return fetch(`/user-api/v1/users/follow/${userId}/${followedUserId}`, {
        method: "GET",
        headers: {
            "Authorization": BearerToken()
        }
    })
    .then(result => result.text())
    .then(data => {
        var json = JSON.parse(data);
        
        return json;
    })
};

export const followUserRequest = (userId, followedUserId) => {
    return fetch('/user-api/v1/users/follow/', {
        method: "POST",
        headers: {
            "Authorization": BearerToken(),
            'Content-Type': 'application/json',
            Accept: 'application/json',
        },
        body: JSON.stringify({userId, followedUserId})
    })
    .then(result => result.text())
    .then(data => {
        var json = JSON.parse(data);

        return json;
    })
};

export const unFollowUserRequest = (userId, followedUserId) => {
    return fetch(`/user-api/v1/users/unfollow/${userId}/${followedUserId}`, {
        method: "DELETE",
        headers: {
            "Authorization": BearerToken()
        }
    });
};