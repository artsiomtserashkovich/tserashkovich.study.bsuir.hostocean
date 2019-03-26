import React from "react";
import { Field, reduxForm } from "redux-form";

import { Paper, Button, Typography, withStyles } from "@material-ui/core";
import Avatar from '@material-ui/core/Avatar';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';

import PasswordInputContainer from "../../../shared/components/PasswordInputField/containers/PasswordInputContainer";
import DefaultInput from '../../../shared/components/DefaultInput';
import * as urls from "./../../constants/urls";

import styles from "./styles"
import { Link } from "react-router-dom";

const formName = "login";

const LoginForm = ({
    classes,
    login,
    handleSubmit
}) => {
    return (
        <div className={classes.formsLayout}>
            <Paper className={classes.paper}>
                <div className={classes.header}>
                    <Avatar className={classes.avatar}>
                        <LockOutlinedIcon />
                    </Avatar>
                    <Typography component="h1" variant="h5">
                        Login
                    </Typography>
                </div>
                <form className={classes.form} onSubmit={handleSubmit(login)} >
                    <Field
                        name="username"
                        title="Username"
                        component={DefaultInput}
                        classes={classes}
                    />
                    <Field
                        name="password"
                        title="Password"
                        component={PasswordInputContainer}
                        classes={classes}
                    />
                    <Typography>
                        <Link className={classes.link} to={urls.accountRegister}>Doesn't have an account? Sign Up!</Link>
                    </Typography>
                    <Button
                        type="submit"
                        color="primary"
                        variant="contained"
                        className={classes.submitButton}
                    >
                        Login
                    </Button>
                </form>
            </Paper>
        </div>
    );
};

export default reduxForm({
    form: formName,
    touchOnChange: false,
    touchOnBlur: true,
    initialValues: {
        username: "",
        password: ""
    }
})(withStyles(styles)(LoginForm));