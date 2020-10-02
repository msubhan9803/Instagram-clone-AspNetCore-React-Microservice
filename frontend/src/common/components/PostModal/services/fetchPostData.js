import BearerToken from '../../../helpers/BearerToken';
import {postDataUrl} from '../constants';

const fetchPostData = id => {
    return fetch(postDataUrl + id, {
        method: 'GET',
        headers: {
          'Authorization': BearerToken()
        }
    })
    .then(resp => resp.text())
    .then(data => {
        const text = JSON.parse(data);
        return text;
    })
    .catch(error => console.log(error));
};

export default fetchPostData;