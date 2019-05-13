import React from 'react';
import PropTypes from 'prop-types';
import DefaultInput from '../../../DefaultInput';
import { Field } from "redux-form";

const Input = ({ classes, inputRef = () => { }, ref, ...other }) => {
    return (
        <Field
            {...other}
            InputProps={{
                inputRef: node => {
                    ref(node);
                    inputRef(node);
                },
                classes: {
                    input: classes.input,
                },
            }}
            component={DefaultInput}
            classes={classes}
        />
    );
}

Input.propTypes = {
    classes: PropTypes.object.isRequired
};

export default Input;