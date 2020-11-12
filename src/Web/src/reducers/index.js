import { combineReducers } from 'redux';

import Login from './Login/Login';
import SignUp from './SignUp/SignUp';
import Newsfeed from './Newsfeed/Newsfeed';
import UserProfile from './UserProfile/UserProfile';

const rootReducer = combineReducers({
    Login,
    SignUp,
    Newsfeed,
    UserProfile
});

export default rootReducer;