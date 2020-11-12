import InitialState from './InitialState';

export default (state = InitialState, action) => {
  switch (action.type) {
    case 'SIGNUP_ERRORS':
        return {...state, signUpErrors: action.payload}
    case 'RESET_SIGNUP_ERRORS':
        return {...state, signUpErrors: []}
    default:
      return state;
  }
}