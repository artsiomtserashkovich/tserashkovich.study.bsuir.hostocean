import React from "react";
import PropTypes from 'prop-types';
import { Paper, Divider, withStyles } from "@material-ui/core";

import styles from "./styles"
import QueueContainer from "../../containers/QueueContainer";
import LabworkContainer from "../../containers/LabworkContainer";
import EventButtonContainer from "../../containers/EventButtonContainer";

const Event = ({ classes, eventId, queueId, labworkId }) => {
    return (
        <Paper className={classes.root}>
            <LabworkContainer labworkId={labworkId} eventId={eventId}/> 
            <Divider />
            <QueueContainer queueId={queueId} eventId={eventId}/>
            <EventButtonContainer queueId={queueId} eventId={eventId}/>
        </Paper>
    );
}

Event.propTypes = {
    classes: PropTypes.object.isRequired,
    queueId: PropTypes.string.isRequired,
    eventId: PropTypes.string.isRequired,
    labworkId: PropTypes.string.isRequired
}

export default withStyles(styles)(Event);