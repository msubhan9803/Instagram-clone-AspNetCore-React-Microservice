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
                                        src={`${process.env.REACT_APP_BACKEND_URL}/user-api/v1/userbios/file/${props.currentFileData.userId}`} alt="profile-img" />
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
                                                src={`${process.env.REACT_APP_BACKEND_URL}/user-api/v1/userbios/file/${props.currentFileData.userId}`} alt="profile-img" />
                                        </div>

                                        <div className="col-8">
                                                <p>
                                                    <b>{props.currentFileData.userName}</b> <>{props.currentFileData.caption}</>
                                                    👍⁠
                                                    ⁠-
                                                    -⁠
                                                    -⁠⁠
                                                    <span className="hashtag">
                                                        #FeelingHappy #FollowMe #SUPERHERO
                                                    </span>
                                                </p>
                                                <p className="font-weight-lighter"><small>{props.currentFileData.createdAt} &nbsp;&nbsp; 1 like</small></p>
                                        </div>
                                    </div>

                                    <div className="row mt-3 border-bottom">
                                        <div className="col-2">
                                            <img className="mx-auto d-block rounded-circle border m-2" width="35px" height="35px"
                                                src={require('../../../assets/images/user-male.png')} />
                                        </div>

                                        <div className="col-8">
                                            <p>
                                                <b>Superman33</b>
                                                    &nbsp; Cool bro...👏
                                            </p>
                                            <p className="font-weight-lighter"><small>100h &nbsp;&nbsp; 1 like</small></p>
                                        </div>
                                    </div>

                                    <div className="row mt-3 border-bottom">
                                        <div className="col-2">
                                            <img className="mx-auto d-block rounded-circle border m-2" width="35px" height="35px"
                                                src={require('../../../assets/images/user-female.png')} />
                                        </div>

                                        <div className="col-8">
                                            <p>
                                                <b>Batman23</b>
                                                    &nbsp; Nice bro...👏
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
                                    <button type="button" className="btn btn-primary btn-sm" disabled>POST</button>
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