import InitialState from './InitialState';

export default (state = InitialState, action) => {
  switch (action.type) {
    case 'STORE_USER_DATA':
      return {...state, currentUserData: action.payload}

    case 'LOGOUT_USER':
      return {...state, currentUserData: {}}

    case 'LOGIN_ERRORS':
      return {...state, loginErrors: action.payload}

    case 'RESET_LOGIN_ERRORS':
      return {...state, loginErrors: []}

    default:
      return state;
  }
}