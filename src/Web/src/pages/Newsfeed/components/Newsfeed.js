import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import Navbar from '../../../common/components/Navbar';
import { fetchInitial, fetchUpdatedNewsfeed } from '../../../actions/Newsfeed';
import PostNewsfeed from '../../../common/components/Post/PostNewsfeed';
import { HubConnectionBuilder, HttpTransportType, LogLevel } from '@microsoft/signalr';
import { newsfeedHubUrl } from '../constants';

const Newsfeed = (props) => {
    const [connection, setConnection] = useState(null);
    
    useEffect(() => {
        var userId = props.currentUserData.userId;
        props.fetchInitialNewsfeed(userId);

        const newConnection = new HubConnectionBuilder()
            .withUrl('/hubs/newsfeed', {
                skipNegotiation: true,
                transport: HttpTransportType.WebSockets
            })
            .configureLogging(LogLevel.Debug)
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, []);

    useEffect(() => {
        if (connection) {
            var userId = props.currentUserData.userId;
            var timeStamp = props.newsfeed.fetchedAt;

            connection.start()
                .then(result => {
                    console.log('Connection started!');

                    connection.on('FetchNewsfeed', () => {
                        console.log('FetchNewsfeed message received!');
                        fetchUpdatedNewsfeed(userId, timeStamp);
                    });
                })
                .catch(e => console.log('Connection failed: ', e));
        }
    }, [connection]);

    return (
        <>
            <Navbar />

            <div className="container">
                <div className="row">
                    <div className="col-md-8">
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