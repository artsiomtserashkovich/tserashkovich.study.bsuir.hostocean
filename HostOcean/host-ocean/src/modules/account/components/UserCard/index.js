import React from "react";

import { Paper, Typography, withStyles } from "@material-ui/core";

import styles from "./styles"

const UserCard = ({
    classes,
}) => {
    return (
        <Paper className={classes.paper}>
            'test'
        </Paper>
    );
};

export default withStyles(styles)(UserCard);