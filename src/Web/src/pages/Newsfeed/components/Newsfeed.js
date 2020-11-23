import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import Navbar from '../../../common/components/Navbar';
import { fetchInitial, fetchUpdatedNewsfeed, clearUserNewsfeedAction } from '../../../actions/Newsfeed';
import PostNewsfeed from '../../../common/components/Post/PostNewsfeed';
import { HubConnectionBuilder, HttpTransportType, LogLevel } from '@microsoft/signalr';
import UserHub from '../../../common/components/UserHub';
import TokenChecker from '../../../common/helpers/TokenChecker';
import { Spin } from 'antd';
import { LoadingOutlined } from '@ant-design/icons';

const antIcon = <LoadingOutlined style={{ fontSize: 24 }} spin />;

const Newsfeed = (props) => {
    const [connection, setConnection] = useState(null);
    const [connectionStarted, setConnectionStarted] = useState(false);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const tokenValidator = TokenChecker();
        var userId = props.currentUserData.userId;
        props.fetchInitialNewsfeed(userId);

        if (tokenValidator === false) {
            props.history.push('/');
        }

        const newConnection = new HubConnectionBuilder()
            .withUrl('/hubs/newsfeed', {
                skipNegotiation: true,
                transport: HttpTransportType.WebSockets
            })
            .configureLogging(LogLevel.Debug)
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);

        setLoading(false);

        return () => {
            setConnectionStarted(false);
            props.clearNewsfeed();
            newConnection.stop();
        }
    }, []);

    useEffect(() => {
        if (connection) {
            if (!connectionStarted) {
                connection.start()
                    .then(result => {
                        console.log('Connection started!');
                        setConnectionStarted(true);
                    })
                    .catch(e => console.log('Connection failed: ', e));
            }
        }
    }, [connection]);

    useEffect(() => {
        var fetchedAt = props.newsfeed.fetchedAt;
        var userId = props.currentUserData.userId;

        if (connectionStarted) {
            connection.on('FetchNewsfeed', () => {
                console.log("here");
                console.log('FetchNewsfeed message received!');

                if (fetchedAt) {
                    props.fetchUpdatedNewsfeed(userId, props.newsfeed.newsfeed, fetchedAt);
                }
            });
        }
    }, [connectionStarted, props.newsfeed]);

    return (
        <>
            {
                loading ?
                    <div className="container" style={{ height: '100vh' }}>
                        <div className="row h-100 text-center  align-items-center">
                            <div className="col">
                                <Spin indicator={antIcon} />
                            </div>
                        </div>
                    </div> :
                    <>
                        <Navbar />

                        <div className="container">
                            <div className="row">
                                <div className="col-md-8">
                                    {
                                        props.newsfeed.newsfeed.map((post, index) => (
                                            <PostNewsfeed key={index} currentPostId={post.id} currentFileData={post} />
                                        ))
                                    }
                                </div>

                                <div className="col-md-4 user-hub">
                                    <UserHub />
                                </div>
                            </div>
                        </div>
                    </>
            }
        </>
    );
};

const mapStateToProps = (state) => {
    return {
        currentUserData: state.Login.currentUserData,
        newsfeed: state.Newsfeed
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        fetchInitialNewsfeed: userId => dispatch(fetchInitial(userId)),
        fetchUpdatedNewsfeed: (userId, currentNewsfeed, fetchedAt) => dispatch(fetchUpdatedNewsfeed(userId, currentNewsfeed, fetchedAt)),
        clearNewsfeed: () => dispatch(clearUserNewsfeedAction())
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(Newsfeed);