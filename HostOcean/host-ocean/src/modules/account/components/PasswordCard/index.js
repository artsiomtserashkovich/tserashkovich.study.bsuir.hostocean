import React from "react";
import PropTypes from "prop-types";
import { Field, reduxForm } from "redux-form";

import {
    Paper,
    Typography,
    withStyles,
    Avatar,
    Divider,
    Button
} from "@material-ui/core";

import PasswordInputContainer from "../../../shared/components/PasswordInputField/containers/PasswordInputContainer";
import styles from "./styles";
import { connect } from "react-redux";

const formName = "userInfo";

const PasswordCard = ({
    classes,
    handleSubmit,
    changePassword
}) => {
    return (
        <Paper className={classes.card}>
            <form onSubmit={handleSubmit(changePassword)}>
                <div className={classes.header}>
                    <div className={classes.title}>
                        <Avatar className={classes.avatar}>
                            <i className="material-icons">security</i>
                        </Avatar>
                        <Typography>Security</Typography>
                    </div>
                </div>
                <Divider />
                <div className={classes.body}>
                    <div className={classes.fields}>
                        <Field
                            name="currentPassword"
                            title="Current password"
                            component={PasswordInputContainer}
                            classes={classes}
                        />
                        <Field
                            name="newPassword"
                            title="New password"
                            component={PasswordInputContainer}
                            classes={classes}
                        />
                        <Field
                            name="newPasswordConfirmation"
                            title="Confirm password"
                            component={PasswordInputContainer}
                            classes={classes}
                        />
                        <Button type="submit" variant="contained">CHANGE PASSWORD</Button>
                    </div>
                </div>
            </form>
        </Paper>
    );
};

PasswordCard.propTypes = {
    classes: PropTypes.object.isRequired,
    changePassword: PropTypes.func.isRequired,
};

let PasswordCardForm = withStyles(styles)(PasswordCard);

PasswordCardForm = reduxForm({
    form: formName,
    touchOnChange: false,
    touchOnBlur: true,
    enableReinitialize: true
})(PasswordCardForm);

PasswordCardForm = connect(state => ({
    initialValues: {
        ...state.user,
        isEditing: false,
        group: state.user.group.name
    }
}))(PasswordCardForm);

export default PasswordCardForm
