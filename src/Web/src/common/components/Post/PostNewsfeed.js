import React from 'react';
import ReactPlayer from "react-player";
import './Common.css';
import * as Constants from './constants';

const PostNewsfeed = (props) => {
    return (
        <div className="card mt-5 mb-5">
            <div className="card-body">
                <div className="row align-items-center border-bottom">
                    <div className="col-1">
                        <img className="mx-auto d-block rounded-circle border m-2" width="35px" height="35px"
                            src={require('../../../assets/images/iron-man.jpg')} alt="profile-img" />
                    </div>

                    <div className="col-9">
                        <div><b>user1</b></div>
                    </div>
                </div>

                <div className="post-newsfeed-content bg-white row p-0 d-flex text-white align-items-center justify-content-center">
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

                <div className="post-newsfeed-details bg-white p-1">
                    <div className="container-fluid h-100">
                        <div className="row justify-content-center h-100">
                            <div className="h-100 d-flex flex-column text-black">
                                <div className="row custom-flex-grow">
                                    <div className="col-12">
                                        <div className="row mt-3 border-bottom">
                                            <div className="col-12">
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
                                            <div className="col-12">
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
                                    <div className="col-1">
                                        <i className="fa fa-2x fa-heart"></i>
                                    </div>

                                    <div className="col-1">
                                        <i className="fa fa-2x fa-comment"></i>
                                    </div>
                                </div>

                                <div className="row mt-2">
                                    <div className="col-12">
                                        <h6>174 Likes</h6>
                                        <p className="text-secondary"><small>JUNE 15</small></p>
                                    </div>
                                </div>

                                <div className="row">
                                    <div className="col-10">
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
        </div>
    )
};

export default PostNewsfeed;