import React, {useEffect, useState} from 'react';
import {connect} from 'react-redux';
import { Link } from 'react-router-dom';
import './UserProfile.css';
import Navbar from '../../../common/components/Navbar';
import PostModal from '../../../common/components/PostModal';
import {getUserProfileData, clearUserProfileData} from '../../../actions/UserProfile';
import {logoutUser} from '../../../actions/Authentication';

const UserProfile = (props) => {
  const [postModalState, setPostModalState] = useState({
    visible: false
  });

  useEffect(() => {
    props.getUserProfileDataAction(props.currentUserData.userId);
  }, []);

  const toggleModal = () => setPostModalState({
    ...postModalState,
    visible: !postModalState.visible
  });

  const logout = event => {
    event.preventDefault();
    props.logoutUser();
  };

  return (
    <React.Fragment>
      <Navbar />
      
      <div className="container p-4">
        <div className="row user-details">
          <div className="profile-img col-4">
              <img className="mx-auto d-block rounded-circle" 
                src="https://instagram.flyp1-1.fna.fbcdn.net/v/t51.2885-19/s150x150/17266075_1962256160661159_275316685097926656_a.jpg?_nc_ht=instagram.flyp1-1.fna.fbcdn.net&_nc_ohc=ram0norGLDEAX8_HgEu&oh=db4fba2f68a103ce555c7fe291b05b79&oe=5F578D24" alt="profile-img"/>
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
                <br/>
                {props.userBio.gender}
                <br/>
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
            <div className="post-gallery">
              <PostModal visible={postModalState.visible} toggleModal={toggleModal} />
              
              <img className="p-3" onClick={toggleModal} src="https://instagram.flyp1-1.fna.fbcdn.net/v/t51.2885-19/s150x150/17266075_1962256160661159_275316685097926656_a.jpg?_nc_ht=instagram.flyp1-1.fna.fbcdn.net&_nc_ohc=ram0norGLDEAX8_HgEu&oh=db4fba2f68a103ce555c7fe291b05b79&oe=5F578D24" alt=""/>
              <img className="p-3" onClick={toggleModal} src="https://instagram.flyp1-1.fna.fbcdn.net/v/t51.2885-19/s150x150/17266075_1962256160661159_275316685097926656_a.jpg?_nc_ht=instagram.flyp1-1.fna.fbcdn.net&_nc_ohc=ram0norGLDEAX8_HgEu&oh=db4fba2f68a103ce555c7fe291b05b79&oe=5F578D24" alt=""/>
              <img className="p-3" onClick={toggleModal} src="https://instagram.flyp1-1.fna.fbcdn.net/v/t51.2885-19/s150x150/17266075_1962256160661159_275316685097926656_a.jpg?_nc_ht=instagram.flyp1-1.fna.fbcdn.net&_nc_ohc=ram0norGLDEAX8_HgEu&oh=db4fba2f68a103ce555c7fe291b05b79&oe=5F578D24" alt=""/>
              <img className="p-3" onClick={toggleModal} src="https://instagram.flyp1-1.fna.fbcdn.net/v/t51.2885-19/s150x150/17266075_1962256160661159_275316685097926656_a.jpg?_nc_ht=instagram.flyp1-1.fna.fbcdn.net&_nc_ohc=ram0norGLDEAX8_HgEu&oh=db4fba2f68a103ce555c7fe291b05b79&oe=5F578D24" alt=""/>
              <img className="p-3" onClick={toggleModal} src="https://instagram.flyp1-1.fna.fbcdn.net/v/t51.2885-19/s150x150/17266075_1962256160661159_275316685097926656_a.jpg?_nc_ht=instagram.flyp1-1.fna.fbcdn.net&_nc_ohc=ram0norGLDEAX8_HgEu&oh=db4fba2f68a103ce555c7fe291b05b79&oe=5F578D24" alt=""/>
              {/* <video className="post" controls>
                <source src="https://youtu.be/jz-Af48ZTps" type="video/mp4" />
              </video> */}
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