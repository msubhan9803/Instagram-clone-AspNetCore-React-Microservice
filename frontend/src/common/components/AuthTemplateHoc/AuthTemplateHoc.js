import React from 'react';
import './AuthTemplateHoc.css';
import { Fade } from 'react-slideshow-image';

const slideshowProps = {
    duration: 2000,
    transitionDuration: 1500,
    arrows: false
  };

const authTemplate = (WrapComponent) => {
    const componentWithAuthTemplate = () =>{
        return (
            <div className="wrapper">
                <div className="wrapper-left col-sm-6 col-md-6">
                    <div className="slide-container">
                        <Fade {...slideshowProps}>
                            <div className="each-fade">
                                <div className="image-container">
                                    <img src={require('../../../assets/images/slideshow-img-1.jpg')} alt="slideshow-1"/>
                                </div>
                            </div>
                            <div className="each-fade">
                                <div className="image-container">
                                    <img src={require('../../../assets/images/slideshow-img-2.jpg')} alt="slideshow-2"/>
                                </div>
                            </div>
                            <div className="each-fade">
                                <div className="image-container">
                                    <img src={require('../../../assets/images/slideshow-img-3.jpg')} alt="slideshow-3"/>
                                </div>
                            </div>
                            <div className="each-fade">
                                <div className="image-container">
                                    <img src={require('../../../assets/images/slideshow-img-4.jpg')} alt="slideshow-4"/>
                                </div>
                            </div>
                            <div className="each-fade">
                                <div className="image-container">
                                    <img src={require('../../../assets/images/slideshow-img-5.jpg')} alt="slideshow-5"/>
                                </div>
                            </div>
                        </Fade>
                    </div>
                </div>
                <div className="wrapper-right ml-1 col-sm-6 col-md-6">
                    <WrapComponent />
                </div>
            </div>
        );
    };

    return componentWithAuthTemplate;
};

export default authTemplate;