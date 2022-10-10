import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import './Edit.css';
import Navbar from '../Navbar';
import {
    Layout, Menu, Form, Input, Button, Radio, Select,
    Cascader, DatePicker, InputNumber, TreeSelect, Switch, message
} from 'antd';
import { fetchUserBio, postUserBioRequest, updateUserBio } from './services/editUserBio';
import { Spin } from 'antd';
import { LoadingOutlined } from '@ant-design/icons';
import Avatar from 'react-avatar-edit';

const { Content, Sider } = Layout;
const antIcon = <LoadingOutlined style={{ fontSize: 24 }} spin />;

const Edit = (props) => {
    const [formData, setFormData] = useState({
        id: null,
        text: "",
        gender: "",
        websiteUrl: "",
        profileImageName: "",
        profileImage: null,
        src: ""
    });
    const [showMessage, setMessage] = useState(false);
    const [loading, setLoading] = useState(true);
    const [postUserBio, setPostUserBio] = useState(false);

    useEffect(() => {
        Promise.resolve(fetchUserBio(props.currentUserData.userId))
            .then(result => {
                if (result !== null) {
                    setFormData({
                        ...formData,
                        id: result.id,
                        text: result.text,
                        gender: result.gender,
                        websiteUrl: result.websiteUrl,
                        profileImageName: result.profileImageName,
                    });
                } else {
                    setPostUserBio(true);
                }

                setLoading(false);
            });
    }, []);

    const handleChange = event => {
        event.preventDefault();
        setFormData({
            ...formData,
            [event.target.name]: event.target.value
        });
    };

    const b64toBlob = (b64Data, contentType, sliceSize) => {
        contentType = contentType || '';
        sliceSize = sliceSize || 512;

        var byteCharacters = atob(b64Data);
        var byteArrays = [];

        for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
            var slice = byteCharacters.slice(offset, offset + sliceSize);

            var byteNumbers = new Array(slice.length);
            for (var i = 0; i < slice.length; i++) {
                byteNumbers[i] = slice.charCodeAt(i);
            }

            var byteArray = new Uint8Array(byteNumbers);

            byteArrays.push(byteArray);
        }

        var blob = new Blob(byteArrays, { type: contentType });
        return blob;
    }

    const handleSubmit = event => {
        event.preventDefault();

        if (postUserBio === true) {
            var imageUrl = formData.profileImage;
            var block = imageUrl.split(";");
            // Get the content type of the image
            var contentType = block[0].split(":")[1];// In this case "image/gif"
            // get the real base64 content of the file
            var realData = block[1].split(",")[1];// In this case "R0lGODlhPQBEAPeoAJosM...."

            // Convert it to a blob to upload
            var blob = b64toBlob(realData, contentType);

            const data = new FormData();
            // data.append('ProfileImage', formData.profileImage);
            data.append('Text', formData.text);
            data.append('Gender', formData.gender);
            data.append('WebsiteUrl', formData.websiteUrl);
            data.append("ProfileImage", blob);

            Promise.resolve(postUserBioRequest(data))
                .then(result => {
                    setMessage(true);
                });
        } else {
            Promise.resolve(updateUserBio(formData))
                .then(result => {
                    setMessage(true);
                });
        }
    };

    const onClose = () => {
        setFormData({ ...formData, profileImage: null })
    };

    const onCrop = (profileImage) => {
        setFormData({ ...formData, profileImage })
    };

    return (
        <>
            {loading ?
                <div className="container" style={{ height: '100vh' }}>
                    <div className="row h-100 text-center  align-items-center">
                        <div className="col">
                            <Spin indicator={antIcon} />
                        </div>
                    </div>
                </div> :
                <>
                    <Navbar />

                    {showMessage ?
                        message.success(
                            {
                                content: 'Changes made successfully!',
                                style: {
                                    marginTop: '20vh'
                                },
                                onClose: () => {
                                    setMessage(false)
                                }
                            })
                        : null}

                    <Content className="container settings-wrapper">
                        <Layout className="settings-layout site-layout-background">
                            <Sider className="site-layout-background" width={200}>
                                <Menu
                                    mode="inline"
                                    defaultSelectedKeys={['1']}
                                    style={{ height: '100%' }}
                                >
                                    <Menu.Item key="1">Edit Profile</Menu.Item>
                                    <Menu.Item key="2">option2</Menu.Item>
                                </Menu>
                            </Sider>

                            <div className="container settings-content">
                                <div className="row">
                                    <div className="col-sm-12 col-md-8 m-auto p-4">
                                        <form onSubmit={handleSubmit}>
                                            <div className="form-group row">
                                                {
                                                    formData.profileImageName ?
                                                        <>
                                                            <label htmlFor="profileImage" className="col-sm-2 col-form- font-weight-bold">Profile Image</label>
                                                            <img className="col-6" src={`${process.env.REACT_APP_BACKEND_URL}/user-api/v1/userbios/file/${props.currentUserData.userId}`} alt="Preview" />
                                                        </>
                                                        :
                                                        <>
                                                            <label htmlFor="profileImage" className="col-sm-2 col-form- font-weight-bold">Profile Image</label>
                                                            <div className="col-sm-8">
                                                                <Avatar
                                                                    width={300}
                                                                    height={180}
                                                                    onCrop={onCrop}
                                                                    onClose={onClose}
                                                                    src={formData.src}
                                                                />
                                                            </div>
                                                        </>
                                                }

                                            </div>

                                            <div className="form-group row">
                                                <label htmlFor="text" className="col-sm-2 col-form- font-weight-bold">Text</label>
                                                <div className="col-sm-10">
                                                    <input
                                                        type="text"
                                                        className="field-text form-control"
                                                        name="text"
                                                        placeholder="text"
                                                        value={formData.text}
                                                        onChange={handleChange}
                                                    />
                                                </div>
                                            </div>

                                            <div className="form-group row">
                                                <label htmlFor="text" className="col-sm-2 col-form-label font-weight-bold">Gender</label>
                                                <div className="col-sm-10">
                                                    <select name="gender" className="form-control" value={formData.gender} onChange={handleChange}>
                                                        {!formData.gender ? <option selected>choose gender</option> : null}
                                                        <option value="male">Male</option>
                                                        <option value="female">Female</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div className="form-group row">
                                                <label htmlFor="websiteUrl" className="col-sm-2 col-form-label font-weight-bold">Website Url</label>
                                                <div className="col-sm-10">
                                                    <input
                                                        type="text"
                                                        className="field-text form-control"
                                                        name="websiteUrl"
                                                        placeholder="websiteUrl"
                                                        value={formData.websiteUrl}
                                                        onChange={handleChange}
                                                    />
                                                </div>
                                            </div>

                                            <div className="row">
                                                <div className="col-10 offset-2">
                                                    <button type="submit" className="btn btn-primary text-light">Submit</button>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </Layout>
                    </Content>
                </>
            }
        </>
    );
};

const mapStateToProps = state => {
    return {
        currentUserData: state.Login.currentUserData
    }
};

export default connect(mapStateToProps)(Edit);