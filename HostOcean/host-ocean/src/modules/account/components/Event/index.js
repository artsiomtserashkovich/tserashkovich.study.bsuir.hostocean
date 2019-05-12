import React from "react";
import PropTypes from "prop-types";

import { Paper, Typography, withStyles, Divider } from "@material-ui/core";

import styles from "./styles";

const Event = ({ classes, location, place, title, time }) => {
    const timeString = new Date(time).toLocaleTimeString("en-EN", {
        year: "numeric",
        month: "numeric",
        day: "numeric",
        hour: "numeric",
        minute: "numeric"
    });
    return (
        <Paper className={classes.root}>
            <div className={classes.header}>
                <Typography>{title}</Typography>
                <Divider />
            </div>
            <div className={classes.body}>
                <div className={classes.info}>
                    <i className="material-icons" style={{ color : "red" }}>place</i>
                    <Typography variant="subtitle2">{location}</Typography>
                </div>
                <div className={classes.info}>
                    <i className="material-icons" >star</i>
                    <Typography variant="subtitle2">{place}</Typography>
                </div>
                <div className={classes.info}>
                    <i className="material-icons">access_time</i>
                    <Typography variant="subtitle2">{timeString}</Typography>
                </div>
            </div>
        </Paper>
    );
};

Event.propTypes = {
    classes: PropTypes.object.isRequired,
    location: PropTypes.string.isRequired,
    place: PropTypes.number.isRequired,
    title: PropTypes.string.isRequired,
    time: PropTypes.string.isRequired,
};

export default withStyles(styles)(Event);
