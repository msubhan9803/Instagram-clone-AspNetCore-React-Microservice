import InitialState from './InitialState';

export default (state = InitialState, action) => {
  switch (action.type) {
    case 'LOGIN_USER':
      return {...state, currentUser: action.payload}
      case 'LOGIN_ERRORS':
        return {...state, loginErrors: action.payload}
      case 'REGISTER_ERRORS':
        return {...state, registerErrors: action.payload}
    default:
      return state;
  }
}