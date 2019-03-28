import React from "react";
import PropTypes from "prop-types";
import { Typography, Divider, withStyles } from "@material-ui/core";

import styles from "./styles"
import Event from "../Event";

const EventsList = ({ classes, events, date }) => {
    return (
        <div>
            <div className={classes.header}>
                <Typography className={classes.title} variant="h6">{date}</Typography>
                <Divider />
            </div>
            <div className={classes.container}>
                {
                    events.map((event, index) => (
                        <Event key={index} labworkId={event.laboratoryWorkId} queueId={event.queueId} eventId={event.id} />
                    ))
                }
            </div>
        </div>
    );
}

EventsList.propTypes = {
    classes: PropTypes.object.isRequired,
    events: PropTypes.array.isRequired,
    date: PropTypes.string.isRequired
};

export default withStyles(styles)(EventsList);