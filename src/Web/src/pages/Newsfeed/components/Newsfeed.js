import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import Navbar from '../../../common/components/Navbar';
import { fetchInitial, fetchUpdatedNewsfeed } from '../../../actions/Newsfeed';
import PostNewsfeed from '../../../common/components/Post/PostNewsfeed';
import { HubConnectionBuilder, HttpTransportType, LogLevel } from '@microsoft/signalr';
import { newsfeedHubUrl } from '../constants';

const Newsfeed = (props) => {
    const [connection, setConnection] = useState(null);
    const [connectionStarted, setConnectionStarted] = useState(false);

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
        if (connection && props.timeStamp) {
            var userId = props.currentUserData.userId;
            var timeStamp = props.timeStamp;

            if (!connectionStarted) {
                connection.start()
                    .then(result => {
                        console.log('Connection started!');
                        setConnectionStarted(true);
                        
                        connection.on('FetchNewsfeed', () => {
                            console.log('FetchNewsfeed message received!');
                            props.fetchUpdatedNewsfeed(userId, timeStamp);
                        });
                    })
                    .catch(e => console.log('Connection failed: ', e));
            }
        }
    }, [connection, props.timeStamp]);

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
        newsfeed: state.Newsfeed.newsfeed,
        timeStamp: state.Newsfeed.fetchedAt
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        fetchInitialNewsfeed: userId => dispatch(fetchInitial(userId)),
        fetchUpdatedNewsfeed: (userId, timeStamp) => dispatch(fetchUpdatedNewsfeed(userId, timeStamp))
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(Newsfeed);