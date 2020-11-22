import InitialState from './InitialState';

export default (state = InitialState, action) => {
  switch (action.type) {
    case 'STORE_USER_NEWSFEED':
      return {
        ...state,
        newsfeed: action.payload.newsfeed,
        fetchedAt: action.payload.fetchedAt
      }

    case 'UPDATE_USER_NEWSFEED':
      return {
        ...state,
        newsfeed: action.payload.newsfeed,
        fetchedAt: action.payload.fetchedAt
      }

    case 'CLEAR_USER_NEWSFEED':
      return InitialState

    default:
      return state;
  }
}