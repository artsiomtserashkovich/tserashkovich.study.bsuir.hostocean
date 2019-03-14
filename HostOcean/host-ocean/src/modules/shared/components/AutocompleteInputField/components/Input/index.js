import React from 'react';
import DefaultInput from '../../../DefaultInput';
import { Field } from "redux-form";

const Input = ({ classes, inputRef = () => { }, ref, ...other }) => {
    return (
        <Field
            {...other}
            component={DefaultInput}
            classes={classes}
        />
    );
}

export default Input;