import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import './UserHub.css';
import FetchUsersList from './services/fetchUsersList';
import { fetchUserRelation, followUserRequest, unFollowUserRequest } from '../../services/followUnfollowUser';

const UserHub = props => {
    const [usersList, setUsersList] = useState([]);
    const [fetchUserList, setFetchUseList] = useState(false);
    const userId = props.currentUserData.userId;

    useEffect(() => {
        const fetchedUsersList = Promise.resolve(FetchUsersList())
            .then(result => {
                const data = result.filter(d => d.id !== userId);
                setUsersList(data);
                setFetchUseList(true);
            })
    }, []);

    useEffect(() => {
        if (fetchUserList) {
            const newUsersList = usersList.map((user, index) => (
                Promise.resolve(fetchUserRelation(userId, user.id))
                    .then(result => {
                        if (result.relation === 1) {
                            return { ...user, relation: 1 }
                        } else {
                            return { ...user, relation: 0 }
                        }
                    })
            ));

            const mapPromisesToValues = promises => {
                return Promise.all(promises);
            }

            mapPromisesToValues(newUsersList).then(values => setUsersList(values));
            setFetchUseList(false);
        }
    }, [fetchUserList]);

    return (
        <div className="card text-center fixed-top float-right mr-0">
            <div className="card-header text-light">
                <p style={{ fontSize: "1rem" }}>Suggestions For You</p>
            </div>
            <div className="card-body">
                {
                    usersList ?
                        usersList.map((user, index) => (
                            <div className="row align-items-center text-left mt-2" key={index}>
                                <div className="col-6">
                                    <h6>{user.userName}</h6>
                                </div>
                                <div className="col-6">
                                    {
                                        user.relation === 1 ?
                                            <button className="btn btn-secondary" onClick={() => {
                                                Promise.resolve(unFollowUserRequest(userId, user.id))
                                                    .then(result => setFetchUseList(true))
                                            }}>Following</button>
                                            :
                                            <button className="btn btn-primary" onClick={() => {
                                                Promise.resolve(followUserRequest(userId, user.id))
                                                    .then(result => setFetchUseList(true))
                                            }}>Follow</button>
                                    }
                                </div>
                            </div>
                        ))
                        : null
                }
            </div>
            <div className="card-footer text-muted">
                <p style={{ fontSize: "0.75rem" }}>© 2020 MADE WITH &#x2764; By MOHAMMAD SUBHAN</p>
            </div>
        </div >
    );
};

const mapStateToProps = state => {
    return {
        currentUserData: state.Login.currentUserData
    }
};

export default connect(mapStateToProps, null)(UserHub);