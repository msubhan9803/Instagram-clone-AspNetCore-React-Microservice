import React, { useEffect, useState } from 'react';
import { connect } from 'react-redux';
import { Link, useLocation } from 'react-router-dom';
import './UserProfile.css';
import Navbar from '../../../common/components/Navbar';
import PostModal from '../../../common/components/PostModal';
import { getUserProfileData, clearUserProfileData } from '../../../actions/UserProfile';
import { logoutUser } from '../../../actions/Authentication';
import * as Constants from '../constants';
import TokenChecker from '../../../common/helpers/TokenChecker';

const UserProfile = (props) => {
  let location = useLocation();

  const [activeImage, setActiveImage] = useState({
    active: null
  });

  useEffect(() => {
    const tokenValidator = TokenChecker();

    if (tokenValidator === true) {
      props.getUserProfileDataAction(props.currentUserData.userId);
    } else {
      props.history.push('/');
    }

    // return dispatch(remove_UserBio_userPosts)
  }, []);

  const logout = event => {
    event.preventDefault();
    props.logoutUser();
  };

  return (
    <React.Fragment>
      <Navbar />

      <div className="container p-4">
        <div className="row user-details align-items-center">
          <div className="profile-img col-4">
            <img className="mx-auto rounded-circle d-block" src={require('../../../assets/images/iron-man.jpg')} alt="profile-img" />
          </div>
          <div className="container profile-desc col-8 p-2">
            <div className="row align-items-center">
              <h3 className="mb-0">{props.currentUserData.userName}</h3>
              <Link className="btn ml-4" to='/'>Edit Profile</Link>
              <i className="fa fa-2x fa-bars ml-4"></i>
            </div>
            <div className="row mt-3 justify-content-start">
              <p><b>10</b> posts</p>
              <p className="ml-5"><b>165</b> followers</p>
              <p className="ml-5"><b>120</b> following</p>
            </div>
            <div className="row">
              <p>
                {props.userBio.text}
                <br />
                {props.userBio.gender}
                <br />
                {props.userBio.websiteUrl}
              </p>
            </div>
            <div className="row">
              <button className="btn btn-outline-primary" onClick={logout}>Logout</button>
            </div>
          </div>
        </div>
        <div className="container user-posts mt-3">
          <div className="row justify-content-center posts-nav">
            <span className="p-2"><a><i className="fa fa-th"></i> POSTS</a></span>
          </div>
          <div className="row justify-content-center">
            <div className="post-gallery row">
              {props.userPosts.map((post, index) => {
                return <div className="parent-wrapper text-center" key={index}>
                  <Link
                    className="d-block"
                    key={index}
                    to={{
                      pathname: `/post/${props.userPosts[index].id}/${index}`,
                      // This is the trick! This link sets
                      // the `background` in location state.
                      state: { 
                        background: location,
                        postList: "userposts"
                      }
                    }}
                  >
                    <div className="child-wrapper text-white">
                      {
                        post.fileType === "video" ?
                          <><i className="fa fa-1x fa-play"></i> 150</> :
                          <><i className="fa fa-1x fa-heart"></i> 150</>
                      }
                          &nbsp;&nbsp;&nbsp;
                          <i className="fa fa-1x fa-comment"></i> 240
                        </div>
                    <img key={index} className="p-3" src={Constants.postFileThumbnailUrl + post.fileId} alt="" />
                  </Link>
                </div>
              })}
            </div>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

const mapStateToProps = state => {
  return {
    currentUserData: state.Login.currentUserData,
    userBio: state.UserProfile.userBio,
    userPosts: state.UserProfile.userPosts
  }
};

const mapDispatchToProps = dispatch => ({
  getUserProfileDataAction: (userId) => dispatch(getUserProfileData(userId)),
  clearUserProfileDataAction: () => dispatch(clearUserProfileData),
  logoutUser: dispatch(logoutUser())
});

export default connect(mapStateToProps, mapDispatchToProps)(UserProfile);