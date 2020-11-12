import BearerToken from '../../../common/helpers/BearerToken';

const CreatePost = formData => {
    return fetch(`/post-api/v1/userposts`, {
        method: "POST",
        headers: {
            'Authorization': BearerToken()
        },
        body: formData
    })
    .then(result => result.text())
    .then(data => {
        var json = JSON.parse(data);
        return json;
    })
    .catch(error => console.log('error', error));
};

export default CreatePost;