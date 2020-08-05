import { combineReducers } from 'redux';

import Login from './Login/Login';
import SignUp from './SignUp/SignUp';

const rootReducer = combineReducers({
    Login,
    SignUp
});

export default rootReducer;