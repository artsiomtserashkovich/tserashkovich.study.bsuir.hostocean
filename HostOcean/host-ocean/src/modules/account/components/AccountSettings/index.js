import React from "react";

import { Paper, Typography, withStyles } from "@material-ui/core";

import styles from "./styles"
import UserCardContainer from './../../containers/UserCardContainer'

const formName = "login";

const AccountSettings = ({
    classes,
    login,
    handleSubmit
}) => {
    return (
        <Paper className={classes.paper}>
            <UserCardContainer />
        </Paper>
    );
};

export default withStyles(styles)(AccountSettings);