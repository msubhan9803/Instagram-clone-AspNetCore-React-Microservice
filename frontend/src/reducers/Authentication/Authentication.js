import InitialState from './InitialState';

export default (state = InitialState, action) => {
  switch (action.type) {
    case 'LOGIN_USER':
      return {...state, currentUser: action.payload}
    default:
      return state;
  }
}