import React from 'react';
import ReactPlayer from "react-player";
import './Common.css';
import * as Constants from './constants';

const Post = (props) => {
    return (
        <div className="row justify-content-center p-2">
            <div className="post-content bg-white col-7 col-lg-8 p-0 d-flex text-white align-items-center justify-content-center">
                {
                    props.currentFileData.fileType === "image" ?
                        <img key={props.currentPostId} src={Constants.postFileUrl +
                            props.currentFileData.fileId} alt="" /> :
                        <ReactPlayer
                            key={props.currentPostId}
                            url={Constants.postFileUrl + props.currentFileData.fileId}
                            playing
                            controls
                            playIcon={<i className="fa fa-4x fa-play"></i>}
                            light={Constants.postFileThumbnailUrl + props.currentFileData.fileId}
                        />
                }
            </div>

            <div className="post-details bg-white col-md-5 col-lg-4 p-3">
                <div className="container-fluid h-100">
                    <div className="row justify-content-center h-100">
                        <div className="h-100 d-flex flex-column text-black">
                            <div className="row align-items-center border-bottom">
                                <div className="col-2">
                                    <img className="mx-auto d-block rounded-circle border m-2" width="35px" height="35px"
                                        src={require('../../../assets/images/iron-man.jpg')} alt="profile-img" />
                                </div>

                                <div className="col-8">
                                    <div><b>{props.currentFileData.userName}</b></div>
                                </div>
                            </div>

                            <div className="row custom-flex-grow">
                                <div className="col-12">
                                    <div className="row mt-3 border-bottom">
                                        <div className="col-2">
                                            <img className="mx-auto d-block rounded-circle border m-2" width="35px" height="35px"
                                                src="https://instagram.flyp1-1.fna.fbcdn.net/v/t51.2885-19/s320x320/17266075_1962256160661159_275316685097926656_a.jpg?_nc_ht=instagram.flyp1-1.fna.fbcdn.net&_nc_ohc=I5K0c7zdHEYAX8Zany2&oh=99cd3a6ef60a648a4f3ce49f92f0ec6f&oe=5F839354" alt="profile-img" />
                                        </div>

                                        <div className="col-8">
                                            <p>
                                                <b>msubhan33</b> <>{props.currentFileData.caption}</>
                                                    Follow @businessfather for more business tips 👍⁠
                                                    ⁠-
                                                    -⁠
                                                    -⁠⁠
                                                    <span className="hashtag">
                                                    #entrepreneur #business #girlboss #smallbusiness
                                                    #womeninbusiness #success #leadership #womeninbiz
                                                    #businesswomen #entrepreneurship #smallbiz #entrepreneurs
                                                    #successtip #businesswoman
                                                    </span>
                                            </p>
                                            <p className="font-weight-lighter"><small>100h &nbsp;&nbsp; 1 like</small></p>
                                        </div>
                                    </div>

                                    <div className="row mt-3 border-bottom">
                                        <div className="col-2">
                                            <img className="mx-auto d-block rounded-circle border m-2" width="35px" height="35px"
                                                src="https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.thenews.com.pk%2Flatest%2F718025-esra-bilgic-speaks-out-on-gender-equality&psig=AOvVaw2ZnMsk3uJpITOTLDAEUJy6&ust=1602502284512000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCOiH-8O4rOwCFQAAAAAdAAAAABAD" alt="profile-img" />
                                        </div>

                                        <div className="col-8">
                                            <p>
                                                <b>esrabilgic</b>
                                                    Branding is all about your public image.
                                                    Your company's IG page can either look
                                                    professional and welcoming or amateurish and boring.
                                                    your company and share it to others. 💻👏

                                                    <span className="hashtag">
                                                    #entrepreneur #business #girlboss #smallbusiness
                                                    #womeninbusiness #success #leadership #womeninbiz
                                                    #businesswomen #entrepreneurship #smallbiz #entrepreneurs
                                                    #successtip #businesswoman
                                                    </span>
                                            </p>
                                            <p className="font-weight-lighter"><small>100h &nbsp;&nbsp; 1 like</small></p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div className="row mt-2">
                                <div className="col-2">
                                    <i className="fa fa-2x fa-heart"></i>
                                </div>

                                <div className="col-2">
                                    <i className="fa fa-2x fa-comment"></i>
                                </div>
                            </div>

                            <div className="row mt-2">
                                <div className="col-12">
                                    <h6>174 views</h6>
                                    <p className="text-secondary"><small>JUNE 15</small></p>
                                </div>
                            </div>

                            <div className="row">
                                <div className="col-9">
                                    <input type="text" className="form-control add-comment-field" placeholder="Add a comment..." />
                                </div>
                                <div className="col-2">
                                    <button type="button" className="btn btn-primary btn-sm">POST</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
};

export default Post;