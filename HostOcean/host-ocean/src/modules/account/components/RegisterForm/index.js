import React from "react";
import { Field, reduxForm } from "redux-form";

import { Paper, Button, Typography, withStyles } from "@material-ui/core";
import Avatar from '@material-ui/core/Avatar';

import PasswordInputContainer from "../../../shared/components/PasswordInputField/containers/PasswordInputContainer";
import AutocompleteInputFieldContainer from "../../../shared/components/AutocompleteInputField/containers/AutocompleteInputFieldContainer";
import DefaultInput from '../../../shared/components/DefaultInput';

import styles from "./styles"

const formName = "register";

const RegisterForm = ({
  classes,
  register,
  groupsList,
  handleSubmit
}) => {
  return (
    <div className={classes.formsLayout}>
      <Paper className={classes.paper}>
        <form className={classes.form} onSubmit={handleSubmit(register)} >
          <div className={classes.header}>
            <Avatar className={classes.avatar}>
              <i class="material-icons">how_to_reg</i>
            </Avatar>
            <Typography component="h1" variant="h5">
              Register
            </Typography>
          </div>
          <Field
            name="username"
            title="Username"
            component={DefaultInput}
            classes={classes}
          />
          <AutocompleteInputFieldContainer
            name="group"
            title="Group"
            formName={formName}
            classes={classes}
            suggestions={groupsList} />
          <Field
            name="email"
            title="Email"
            type="email"
            component={DefaultInput}
            classes={classes} />
          <Field
            name="password"
            title="Password"
            component={PasswordInputContainer}
            classes={classes}
          />
          <Field
            name="confirm"
            title="Confirm password"
            component={PasswordInputContainer}
            classes={classes}
          />
          <Button
            type="submit"
            color="primary"
            variant="contained"
            className={classes.submitButton}
          >
            Register
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
    email: "",
    password: "",
    confirm: "",
    group: ""
  }
})(withStyles(styles)(RegisterForm));