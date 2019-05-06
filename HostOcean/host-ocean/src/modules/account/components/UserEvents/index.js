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
        <div style={{marginTop: 20}}>
            <UserCardContainer />
        </div>
    );
};

export default withStyles(styles)(AccountSettings);