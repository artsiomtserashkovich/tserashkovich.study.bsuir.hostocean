import React from "react";
import PropTypes from "prop-types";
import { Typography, Divider, withStyles } from "@material-ui/core";

import styles from "./styles"

const LaboratoryWork = ({ classes, startDate, title, lecturer, location }) => {
    const dateString = new Date(startDate).toLocaleTimeString("en-EN", { hour: "numeric", minute: "numeric" })
    return (
        <React.Fragment>
            <Typography className={classes.title} variant="h6">{title}</Typography>
            <Divider />
            <div className={classes.infoContainer}>
                <div className={classes.info}>
                    <i className="material-icons">access_time</i>
                    <Typography variant="subtitle2">{dateString}</Typography>
                </div>
                <div className={classes.info}>
                    <i className="material-icons" style={{ color: "red" }}>location_on</i>
                    <Typography variant="subtitle2">{location}</Typography>
                </div>
                <div className={classes.info}>
                    <i className="material-icons">person</i>
                    <Typography variant="subtitle2">{lecturer}</Typography>
                </div>
            </div>
        </React.Fragment>
    );
}

LaboratoryWork.propTypes = {
    classes: PropTypes.object.isRequired,
    startDate: PropTypes.string.isRequired,
    title: PropTypes.string.isRequired,
    lecturer: PropTypes.string.isRequired,
    location: PropTypes.string.isRequired
}

export default withStyles(styles)(LaboratoryWork);