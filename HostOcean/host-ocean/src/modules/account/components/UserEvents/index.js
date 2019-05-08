import React from "react";
import PropTypes from "prop-types";

import {
    Paper,
    Typography,
    withStyles,
    Divider,
    Avatar
} from "@material-ui/core";

import styles from "./styles";
import EventContainer from "../../containers/EventContainer";

const UserEvents = ({ classes, events }) => {
    return (
        <Paper className={classes.root}>
            <div className={classes.header}>
                <div className={classes.title}>
                    <Avatar className={classes.avatar}>
                        <i className="material-icons">whatshot</i>
                    </Avatar>
                    <Typography variant="subtitle1">Events</Typography>
                </div>
                <Divider />
            </div>
            <div className={classes.body}>
                {events.length > 0 ? (
                    events.map((e, index) => (
                        <EventContainer key={index} id={e.id} />
                    ))
                ) : (
                    <div className={classes.info}>
                        <Typography variant="h5">
                            There is no events ;(
                        </Typography>
                    </div>
                )}
            </div>
        </Paper>
    );
};

UserEvents.propTypes = {
    classes: PropTypes.object.isRequired,
    events: PropTypes.array.isRequired
};

export default withStyles(styles)(UserEvents);
