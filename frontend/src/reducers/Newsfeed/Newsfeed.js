import InitialState from './InitialState';

export default (state = InitialState, action) => {
  switch (action.type) {
    case 'STORE_USER_NEWSFEED':
      return {
        ...state, 
        newsfeed: action.payload,
        fetchedAt: Date.now()
      }

    default:
      return state;
  }
}