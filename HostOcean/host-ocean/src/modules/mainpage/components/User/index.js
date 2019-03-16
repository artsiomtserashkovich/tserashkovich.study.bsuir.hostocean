import React from "react";
import { Typography, Avatar, withStyles } from "@material-ui/core";

import styles from "./styles"

const User = ({ classes, order, user }) => {
    return (
        <div className={classes.userInfo}>
            <Typography variant="subtitle1">{order}.</Typography>
            <Avatar alt="Remy Sharp" className={classes.userAvatar}>VR</Avatar>
            <Typography variant="subtitle1">{user.userName}</Typography>
        </div>);
}

export default withStyles(styles)(User);