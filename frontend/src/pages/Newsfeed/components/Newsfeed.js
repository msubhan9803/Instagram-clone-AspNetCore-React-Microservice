import React, { useEffect } from 'react';
import { connect } from 'react-redux';
import Navbar from '../../../common/components/Navbar';
import { fetchInitial } from '../../../actions/Newsfeed';
import PostNewsfeed from '../../../common/components/Post/PostNewsfeed';

const Newsfeed = (props) => {
    useEffect(() => {
        var userId = props.currentUserData.userId;
        props.fetchInitialNewsfeed(userId);
    }, []);

    return (
        <>
            <Navbar />

            <div className="container">
                <div className="row">
                    <div className="col-8">
                        {
                            props.newsfeed.map((post, index) => (
                                <PostNewsfeed currentPostId={post.id} currentFileData={post} />
                            ))
                        }
                    </div>
                </div>
            </div>
        </>
    );
};

const mapStateToProps = (state) => {
    return {
        currentUserData: state.Login.currentUserData,
        newsfeed: state.Newsfeed.newsfeed
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        fetchInitialNewsfeed: userId => dispatch(fetchInitial(userId))
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(Newsfeed);