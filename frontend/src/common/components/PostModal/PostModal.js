import React from 'react';
import { useEffect, useState } from 'react';
import {connect} from 'react-redux';
import { Modal } from 'antd';
import './PostModal.css';

const PostModal = (props) => {
    const [currentIndex, setCurrentIndex] = useState(null);

    const [currentFileData, setCurrentFileData] = useState({});

    useEffect(() => {
        setCurrentIndex(props.activeImage);
    }, []);

    useEffect(() => {
        if (currentIndex != null) {
            var fileData = props.userPosts[currentIndex];
            setCurrentFileData(fileData);
        }
    }, [currentIndex]);

    const handleOk = e => {
        props.toggleModal();
    };
    
    const handleCancel = e => {
        props.toggleModal();
    };

    const postContent = () => {
        var fileType = currentFileData.fileType;
        if (fileType === "image")
        {
            return <img key={currentIndex} className="post-content p-3" src={"/post-api/v1/userposts/file/" + 
            currentFileData.fileId} alt="" /> 
        }
        else if (fileType === "video")
        {
            return (
            <video key={currentIndex} className="post-content p-3" controls>
                <source src={"/post-api/v1/userposts/file/" + currentFileData.fileId} type="video/mp4" />
            </video>
            );
        }
    };

    const prev = () => {
        if (currentIndex >= 0) {
            setCurrentIndex(currentIndex - 1);
        }
    };

    const next = () => {
        setCurrentIndex(currentIndex + 1);
    };

    return (
        <React.Fragment>
            {props.visible &&
                <Modal
                className=""
                visible={props.visible}
                centered="true"
                onOk={handleOk}
                onCancel={handleCancel}
                zIndex="10000"
                footer={null}>
                    <div className="container">
                        <div className="row align-items-center">
                            <div className="col-1">
                                {
                                    (currentIndex > 0) ?
                                    <a className="button-prev" onClick={prev}><i className="fa fa-chevron-left"></i></a>
                                    : null
                                }
                            </div>
                            <div className="container post-content col-10">
                                {currentFileData.fileId ?
                                    <React.Fragment>
                                        {postContent()}
                                    </React.Fragment>
                                    :
                                    null
                                }
                            </div>
                            <div className="col-1">
                                {
                                    currentIndex === (props.userPosts.length - 1) ?
                                    null :
                                    <a className="button-next col-1" onClick={next}><i className="fa fa-chevron-right"></i></a>
                                }
                            </div>
                        </div>
                    </div>
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