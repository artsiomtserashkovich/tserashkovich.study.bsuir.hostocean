import React from "react";
import { Field, reduxForm } from "redux-form";

import { Paper, withStyles } from "@material-ui/core";
import Button from "@material-ui/core/Button";
import Typography from "@material-ui/core/Typography";

import PasswordInputContainer from "../../../shared/components/PasswordInputField/containers/PasswordInputContainer";
import DefaultInput from '../../../shared/components/DefaultInput';

import styles from "./styles"

const formName = "login";

const LoginForm = ({
    classes,
    login,
    handleSubmit
}) => {
    return (
        <div className={classes.formsLayout}>
            <Paper className={classes.paper}>
                <Typography variant="headline">Login</Typography>
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