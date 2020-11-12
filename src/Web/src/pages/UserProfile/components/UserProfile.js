import React, { useEffect, useState } from 'react';
import { connect } from 'react-redux';
import { Link, useLocation, useParams } from 'react-router-dom';
import './UserProfile.css';
import Navbar from '../../../common/components/Navbar';
import PostModal from '../../../common/components/PostModal';
import { getUserProfileData, clearUserProfileData } from '../../../actions/UserProfile';
import { logoutUser } from '../../../actions/Authentication';
import * as Constants from '../constants';
import TokenChecker from '../../../common/helpers/TokenChecker';
import FetchUserId from '../services/fetchUserId';
import { fetchUserRelation, followUserRequest, unFollowUserRequest } from '../services/followUnfollowUser';
import { Spin } from 'antd';
import { LoadingOutlined } from '@ant-design/icons';

const antIcon = <LoadingOutlined style={{ fontSize: 24 }} spin />;

const UserProfile = (props) => {
  let location = useLocation();
  let { username } = useParams();

  const [userData, setUserData] = useState(null);
  const [activeImage, setActiveImage] = useState({
    active: null
  });
  const [loading, setLoading] = useState(true);
  const [followButton, setFollowButton] = useState(null);

  useEffect(() => {
    const tokenValidator = TokenChecker();

    if (tokenValidator === true) {
      Promise.resolve(FetchUserId(username))
        .then(result => {
          setUserData(result);

          Promise.resolve(props.getUserProfileDataAction(result.id))
            .then(r => {
              if (username !== props.currentUserData.userName) {
                const userId = props.currentUserData.userId;
                const followedUserId = result.id;

                Promise.resolve(fetchUserRelation(userId, followedUserId))
                  .then(data => {
                    if (data.relation === 1) {
                      setFollowButton(1);
                    } else {
                      setFollowButton(0);
                    }
                  })
              }

              setLoading(false);
            });
        });
    } else {
      props.history.push('/');
    }

    return () => props.clearUserProfileDataAction();
  }, []);

  const followUser = () => {
    const userId = props.currentUserData.userId;
    const followedUserId = userData.id;

    Promise.resolve(followUserRequest(userId, followedUserId))
      .then(result => {
        setFollowButton(1);
      });
  };

  const unFollowUser = () => {
    const userId = props.currentUserData.userId;
    const followedUserId = userData.id;

    Promise.resolve(unFollowUserRequest(userId, followedUserId))
      .then(result => {
        setFollowButton(0);
      });
  };

  return (
    <React.Fragment>
      {loading ?
        <div className="container" style={{ height: '100vh' }}>
          <div className="row h-100 text-center  align-items-center">
            <div className="col">
              <Spin indicator={antIcon} />
            </div>
          </div>
        </div> :
        <>
          <Navbar />

          <div className="container p-4">
            <div className="row user-details align-items-center">
              <div className="profile-img col-4">
                <img className="mx-auto rounded-circle d-block" src={require('../../../assets/images/iron-man.jpg')} alt="profile-img" />
              </div>
              <div className="container profile-desc col-8 p-2">
                <div className="row align-items-center">
                  <h3 className="mb-0">{username}</h3>
                  {followButton === 1 ?
                    <button className="btn btn-secondary m-3" onClick={unFollowUser}>Following</button>
                    : followButton === 0 ? <button className="btn btn-primary m-3" onClick={followUser}>Follow</button>
                      : null
                  }
                  {username === props.currentUserData.userName ?
                    <>
                      <Link className="btn ml-4" to='/accounts/edit'>Edit Profile</Link>
                      <i className="fa fa-2x fa-bars ml-4"></i>
                    </> :
                    null
                  }
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
              </div>
            </div>
            <div className="container user-posts mt-3">
              <div className="row justify-content-center posts-nav">
                <span className="p-2"><a><i className="fa fa-th"></i> POSTS</a></span>
              </div>
              <div className="row justify-content-left">
                <div className="post-gallery row">
                  {props.userPosts.map((post, index) => {
                    return <div className="parent-wrapper text-center" key={index}>
                      <Link
                        className="img-fluid"
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
        </>
      }
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
  clearUserProfileDataAction: () => dispatch(clearUserProfileData()),
  logoutUser: dispatch(logoutUser())
});

export default connect(mapStateToProps, mapDispatchToProps)(UserProfile);