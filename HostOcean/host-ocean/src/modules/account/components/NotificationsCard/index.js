import React from "react";
import PropTypes from "prop-types";

import {
    Paper,
    Typography,
    withStyles,
    Avatar,
    Divider,
    FormControlLabel,
    Switch
} from "@material-ui/core";

import styles from "./styles";

const NotificationsCard = ({
    classes
}) => {
    return (
        <Paper className={classes.card}>
            <div className={classes.header}>
                <div className={classes.title}>
                    <Avatar className={classes.avatar}>
                        <i className="material-icons">notifications</i>
                    </Avatar>
                    <Typography variant="subtitle1">Notifications</Typography>
                </div>
            </div>
            <Divider />
            <div className={classes.body}>
                <div className={classes.fields}>
                    <FormControlLabel control={<Switch value="emailNotifications" />} label="Email notifications" />
                </div>
            </div>
        </Paper>
    );
};

NotificationsCard.propTypes = {
    classes: PropTypes.object.isRequired
};

export default withStyles(styles)(NotificationsCard);
