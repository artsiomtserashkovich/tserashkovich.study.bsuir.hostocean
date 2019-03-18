import React from "react";
import { Paper, Typography, Divider, withStyles } from "@material-ui/core";

import styles from "./styles"
import QueueContainer from "../../containers/QueueContainer";

const LaboratoryWork = ({ classes, startDate, title, lecturer, location, id }) => {
    const dateString = new Date(startDate).toLocaleTimeString("en-EN", { hour: "numeric", minute: "numeric" })
    return (
        <Paper className={classes.root}>
            <Typography className={classes.title} variant="h6">{title}</Typography>
            <Divider />
            <div className={classes.infoContainer}>
                <div className={classes.info}>
                    <i className="material-icons">access_time</i>
                    <Typography variant="subtitle2">{dateString}</Typography>
                </div>
                <div className={classes.info}>
                    <i className="material-icons">location_on</i>
                    <Typography variant="subtitle2">{location}</Typography>
                </div>
                <div className={classes.info}>
                    <i className="material-icons">person</i>
                    <Typography variant="subtitle2">{lecturer}</Typography>
                </div>
            </div>
            <Divider />
            <QueueContainer labworkId={id} />
        </Paper>
    );
}

export default withStyles(styles)(LaboratoryWork);