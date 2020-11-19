import InitialState from './InitialState';

export default (state = InitialState, action) => {
  switch (action.type) {
    case 'STORE_USER_NEWSFEED':
      return {
        ...state, 
        newsfeed: action.payload,
        fetchedAt: Date.now()
      }

    case 'UPDATE_USER_NEWSFEED':
      var newPosts = action.payload;
      var oldNewsfeed = state.newsfeed;
      var newsfeed = newPosts.concat(oldNewsfeed);

      return {
        ...state, 
        newsfeed: newsfeed,
        fetchedAt: Date.now()
      }

    default:
      return state;
  }
}