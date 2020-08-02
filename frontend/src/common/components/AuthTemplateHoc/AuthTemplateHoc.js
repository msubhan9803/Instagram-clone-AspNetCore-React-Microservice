import React from 'react';
import './AuthTemplateHoc.css';

const authTemplate = (WrapComponent) => {
    const componentWithAuthTemplate = () =>{
        return (
            <div className="wrapper">
                <div className="wrapper-left col-md-6">
                    <img src={require('../../../assets/images/auth-slideshow-phone.png')} alt="slideshow-phone"/>
                </div>
                <div className="wrapper-right ml-1 col-md-6">
                    <WrapComponent />
                </div>
            </div>
        );
    };

    return componentWithAuthTemplate;
};

export default authTemplate;