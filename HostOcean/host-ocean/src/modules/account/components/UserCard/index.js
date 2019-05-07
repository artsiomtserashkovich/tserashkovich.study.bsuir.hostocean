import React from "react";
import PropTypes from "prop-types";
import { Field, reduxForm } from "redux-form";

import {
    Paper,
    Typography,
    withStyles,
    Avatar,
    Divider,
    IconButton
} from "@material-ui/core";

import DefaultInput from "../../../shared/components/DefaultInput";
import styles from "./styles";
import { connect } from "react-redux";

const formName = "userInfo";

const UserCard = ({
    classes,
    handleSubmit,
    user,
    isEditing,
    editInfo,
    saveInfo
}) => {
    return (
        <Paper className={classes.card}>
            <form onSubmit={handleSubmit(saveInfo)}>
                <div className={classes.header}>
                    <div className={classes.title}>
                        <Avatar className={classes.avatar}>
                            <i className="material-icons">info</i>
                        </Avatar>
                        <Typography>User information</Typography>
                    </div>
                    {!isEditing && (
                        <IconButton onClick={editInfo}>
                            <i
                                className="material-icons"
                                style={{ color: "blue" }}
                            >
                                edit
                            </i>
                        </IconButton>
                    )}
                    {isEditing && (
                        <IconButton type="submit" onClick={editInfo}>
                            <i
                                className="material-icons"
                                style={{ color: "red" }}
                            >
                                save
                            </i>
                        </IconButton>
                    )}
                </div>
                <Divider />
                <div className={classes.body}>
                    <div className={classes.fields}>
                        <Field
                            name="userName"
                            title="Username"
                            disabled={!isEditing}
                            required={false}
                            component={DefaultInput}
                            classes={classes}
                        />
                        <Field
                            name="group"
                            title="Group"
                            disabled={!isEditing}
                            required={false}
                            component={DefaultInput}
                            classes={classes}
                        />
                        <Field
                            name="firstName"
                            title="First name"
                            disabled={!isEditing}
                            required={false}
                            component={DefaultInput}
                            classes={classes}
                        />
                        <Field
                            name="lastName"
                            title="Last name"
                            disabled={!isEditing}
                            required={false}
                            component={DefaultInput}
                            classes={classes}
                        />
                        <Field
                            name="email"
                            title="Email"
                            disabled={!isEditing}
                            required={false}
                            component={DefaultInput}
                            classes={classes}
                        />
                        <Field
                            name="phoneNumber"
                            title="Phone number"
                            disabled={!isEditing}
                            required={false}
                            component={DefaultInput}
                            classes={classes}
                        />
                    </div>
                </div>
            </form>
        </Paper>
    );
};

UserCard.propTypes = {
    classes: PropTypes.object.isRequired,
    user: PropTypes.object.isRequired,
    editInfo: PropTypes.func.isRequired,
    saveInfo: PropTypes.func.isRequired,
    isEditing: PropTypes.bool
};

let UserCardForm = withStyles(styles)(UserCard);

UserCardForm = reduxForm({
    form: formName,
    touchOnChange: false,
    touchOnBlur: true,
    enableReinitialize: true
})(UserCardForm);

UserCardForm = connect(state => ({
    initialValues: {
        ...state.user,
        isEditing: false,
        group: state.user.group.name
    }
}))(UserCardForm);

export default UserCardForm
