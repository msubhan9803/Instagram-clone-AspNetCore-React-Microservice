import InitialState from './InitialState';

export default (state = InitialState, action) => {
  switch (action.type) {
    case 'STORE_USER_PROFILE_DATA':
      return {
        ...state,
        userBio: action.payload.userBio,
        userPosts: action.payload.userPost
      }

    case 'CLEAR_USER_PROFILE_DATA':
      return {
        ...state,
        userBio: {},
        userPosts: {}
      }

    case 'LOGOUT_USER':
      return {userBio: {}, userPosts: []}

    default:
      return state;
  }
}