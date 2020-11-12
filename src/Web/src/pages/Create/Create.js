import React, { useState, useEffect } from 'react';
import Navbar from '../../common/components/Navbar';
import CreatePost from './services/createPost';
import TokenChecker from '../../common/helpers/TokenChecker';
import { Spin, message } from 'antd';
import { LoadingOutlined } from '@ant-design/icons';

const antIcon = <LoadingOutlined style={{ fontSize: 24 }} spin />;

const Create = (props) => {
    const [post, setPost] = useState({
        caption: "",
        file: {}
    });
    const [loading, setLoading] = useState(true);
    const [showMessage, setMessage] = useState(false);

    useEffect(() => {
        const tokenValidator = TokenChecker();

        if (tokenValidator === false) {
            props.history.push('/');
        }

        setTimeout(() => {
            setLoading(false)
        }, 1000)
    }, []);

    const handleChange = event => {
        event.preventDefault();

        event.target.name === 'file' ?
            setPost({
                ...post,
                file: event.target.files[0]
            }) :
            setPost({
                ...post,
                [event.target.name]: event.target.value
            })
    };

    const handleSubmit = event => {
        event.preventDefault();

        const data = new FormData();
        data.append('Caption', post.caption);
        data.append('File', post.file);

        Promise.resolve(CreatePost(data))
            .then(result => {
                setMessage(true);
            })
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
                                content: 'Post Created!',
                                style: {
                                    marginTop: '20vh'
                                },
                                onClose: () => {
                                    setMessage(false)
                                }
                            })
                        : null}

                    <div className="container p-5">
                        <div className="row justify-content-center">
                            <h4>Create a Post</h4>
                        </div>

                        <div className="row justify-content-center">
                            <div className="col-8">
                                <form onSubmit={handleSubmit}>
                                    <div className="form-group row">
                                        <label htmlFor="text" className="col-sm-3 col-form- font-weight-bold">Text</label>
                                        <div className="col-sm-9">
                                            <input
                                                type="text"
                                                className="field-text form-control"
                                                name="caption"
                                                placeholder="Caption"
                                                value={post.caption}
                                                onChange={handleChange}
                                            />
                                        </div>
                                    </div>

                                    <div className="form-group row">
                                        <label htmlFor="text" className="col-sm-3 col-form- font-weight-bold">Image/Video</label>
                                        <div className="col-sm-9">
                                            <div className="custom-file">
                                                <input type="file" name="file" className="custom-file-input" id="customFile" onChange={handleChange} />
                                                <label className="custom-file-label" htmlFor="customFile">{ !post.file.name ? "Choose file" : post.file.name.slice(0, 5) + '...' }</label>
                                            </div>
                                        </div>
                                    </div>

                                    <div className="row justify-content-center">
                                        <button type="submit" className="btn btn-primary text-light">Submit</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </>
            }
        </>
    );
};

export default Create;