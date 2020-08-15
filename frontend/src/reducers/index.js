import { combineReducers } from 'redux';

import Login from './Login/Login';
import SignUp from './SignUp/SignUp';
import UserProfile from './UserProfile/UserProfile';

const rootReducer = combineReducers({
    Login,
    SignUp,
    UserProfile
});

export default rootReducer;