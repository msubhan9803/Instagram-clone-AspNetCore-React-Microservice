import InitialState from './InitialState';

export default (state = InitialState, action) => {
  switch (action.type) {
    case 'STORE_USER_NEWSFEED':
      var newsfeed = action.payload;

      return {
        ...state,
        newsfeed: newsfeed,
        fetchedAt: new Date(newsfeed[0].createdAt).getTime()
      }

    case 'UPDATE_USER_NEWSFEED':
      var newPosts = action.payload;
      var oldNewsfeed = state.newsfeed;
      var newsfeed = newPosts.concat(oldNewsfeed);

      return {
        ...state,
        newsfeed: newsfeed,
        fetchedAt: new Date(newsfeed[0].createdAt).getTime()
      }

    case 'CLEAR_USER_NEWSFEED':
      return InitialState

    default:
      return state;
  }
}