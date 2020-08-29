import React from 'react';
import { useEffect, useState } from 'react';
import {connect} from 'react-redux';
import { Modal } from 'antd';
import './PostModal.css';

const PostModal = (props) => {
    const [localState, setLocalState] = useState({
        currentIndex: null,
        currentFileData: {}
        // loading
    });

    useEffect(() => {
        setLocalState({
            ...localState,
            currentIndex: props.activeImage
        });
    }, []);

    useEffect(() => {
        if (localState.currentIndex != null) {
            var fileData = props.userPosts[localState.currentIndex];
            setLocalState({
                ...localState,
                currentFileData: fileData
            });
        }
    }, [localState.currentIndex]);

    const handleOk = e => {
        props.toggleModal();
    };
    
    const handleCancel = e => {
        props.toggleModal();
    };

    return (
        <React.Fragment>
            {props.visible &&
                <Modal
                    visible={props.visible}
                    centered="true"
                    onOk={handleOk}
                    onCancel={handleCancel}
                    zIndex="10000"
                    footer={null}
                >
                    {localState.currentFileData.fileId ?
                        <img className="post-content p-3" src={"/post-api/v1/userposts/file/" + 
                            localState.currentFileData.fileId} alt="" /> 
                            :
                        null
                    }
                </Modal>
            }
        </React.Fragment>
    )
};

const mapStateToProps = state => {
  return {
    userPosts: state.UserProfile.userPosts
  }
};

export default connect(mapStateToProps)(PostModal);