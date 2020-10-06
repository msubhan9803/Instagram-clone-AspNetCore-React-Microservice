import React from 'react';
import { useEffect, useState } from 'react';
import { Link, useLocation, useParams, withRouter } from 'react-router-dom';
import { connect } from 'react-redux';
import { Modal } from 'antd';
import './PostModal.css';
import Post from '../../../common/components/Post';
import PostData from './services/fetchPostData';

const PostModal = (props) => {
    let location = useLocation();
    let { id, index } = useParams();

    const [state, setLocalState] = useState({
        currentPostId: null,
        currentIndex: null,
        currentFileData: null,
        postListLength: null
    });

    const [postModalState, setPostModalState] = useState({
        visible: true
    });

    useEffect(() => {
        const postListLength = props.location.state.postList === "userposts"
            ? props.userPosts.length
            : null;

        setLocalState({
            ...state,
            currentPostId: id,
            currentIndex: parseInt(index),
            postListLength
        });
    }, []);

    useEffect(() => {
        let mounted = true

        if (mounted) {
            if (state.currentPostId != null) {
                Promise.resolve(PostData(state.currentPostId)).then(result => {
                    setLocalState({
                        ...state,
                        currentFileData: result
                    });
                });
            }
        }

        return () => mounted = false;
    }, [state.currentPostId]);

    const toggleModal = () => {
        setPostModalState({
            ...postModalState,
            visible: !postModalState.visible
        });
    };

    const handleOk = e => {
        e.stopPropagation();
        const parentUrl = getParentUrl(props.location.state.background);
        props.history.push(parentUrl);
        toggleModal();
    };

    const handleCancel = e => {
        e.stopPropagation();
        const parentUrl = getParentUrl(props.location.state.background);
        props.history.push(parentUrl);
        toggleModal();
    };

    const prevPost = () => {
        const newPostId = props.location.state.postList === "userposts"
            ? props.userPosts[state.currentIndex - 1].id
            : null;

        setLocalState({
            ...state,
            currentPostId: newPostId,
            currentIndex: state.currentIndex - 1
        });
    };

    const nextPost = () => {
        const newPostId = props.location.state.postList === "userposts"
            ? props.userPosts[state.currentIndex + 1].id
            : null;

        setLocalState({
            ...state,
            currentPostId: newPostId,
            currentIndex: state.currentIndex + 1
        });
    };

    const getParentUrl = (x) => {        
        if (typeof x.state !== 'object') {
            return x.pathname;
        }

        let prop;
        for (prop in x) {
            if (prop === 'state') {
                return getParentUrl(x[prop].background)
            }
        }
    };

    return (
        <React.Fragment>
            <Modal
                visible={true}
                centered="true"
                onOk={handleOk}
                onCancel={handleCancel}
                zIndex="10000"
                footer={null}>
                <div className="container postModal-wrapper">
                    <div className="row align-items-center">
                        <div className="col-1 text-right">
                            {
                                (state.currentIndex > 0) ?
                                    <Link
                                        onClick={prevPost}
                                        className="button-prev"
                                        to={{
                                            pathname: `/post/${props.userPosts[state.currentIndex - 1].id}/${state.currentIndex - 1}`,
                                            // This is the trick! This link sets
                                            // the `background` in location state.
                                            state: {
                                                background: location,
                                                postList: props.location.state.postList
                                            }
                                        }}
                                    >
                                        <i className="fa fa-chevron-left"></i>
                                    </Link>
                                    : null
                            }
                        </div>
                        <div className="col-10">
                            {state.currentFileData ?
                                <React.Fragment>
                                    <Post currentPostId={state.currentPostId} currentFileData={state.currentFileData} />
                                </React.Fragment>
                                :
                                null
                            }
                        </div>
                        <div className="col-1">
                            {
                                state.currentIndex === (state.postListLength - 1) ?
                                    null :
                                    <Link
                                        onClick={nextPost}
                                        className="button-next"
                                        to={{
                                            pathname: `/post/${props.userPosts[state.currentIndex + 1].id}/${state.currentIndex + 1}`,
                                            // This is the trick! This link sets
                                            // the `background` in location state.
                                            state: {
                                                background: location,
                                                postList: props.location.state.postList
                                            }
                                        }}
                                    >
                                        <i className="fa fa-chevron-right"></i>
                                    </Link>
                            }
                        </div>
                    </div>
                </div>
            </Modal>
        </React.Fragment>
    )
};

const mapStateToProps = state => {
    return {
        userPosts: state.UserProfile.userPosts
    }
};

export default withRouter(connect(mapStateToProps)(PostModal));