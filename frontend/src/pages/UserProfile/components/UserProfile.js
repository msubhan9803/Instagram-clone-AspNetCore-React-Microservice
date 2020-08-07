import React, {useEffect} from 'react';
import tokenChecker from '../../../common/helpers/tokenChecker';
import './UserProfile.css';

const UserProfile = (props) => {
  useEffect(() => {
    const tokenValidator = tokenChecker();

    if (tokenValidator === false || tokenValidator === null) {
      props.history.push('/');
    }
  });

  return (
    <div>User Profile Page!</div>
  );
};

export default UserProfile;