import InitialState from './InitialState';

export default (state = InitialState, action) => {
  switch (action.type) {
    case 'STORE_USER_DATA':
      console.log(action.payload);
      return {...state, currentUserData: action.payload}
      case 'LOGIN_ERRORS':
        return {...state, loginErrors: action.payload}
      case 'RESET_LOGIN_ERRORS':
        return {...state, loginErrors: []}
    default:
      return state;
  }
}