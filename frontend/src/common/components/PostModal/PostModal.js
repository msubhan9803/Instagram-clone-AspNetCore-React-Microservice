import React from 'react';
import { Modal } from 'antd';

const PostModal = (props) => {
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
                    <p>Some contents...</p>
                    <p>Some contents...</p>
                    <p>Some contents...</p>
                </Modal>
            }
        </React.Fragment>
    )
};

export default PostModal;