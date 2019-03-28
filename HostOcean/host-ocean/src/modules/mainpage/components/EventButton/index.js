import React from "react";
import PropTypes from "prop-types";
import { Button, withStyles } from "@material-ui/core";

import styles from "./styles"

const EventButton = ({ classes, queue, onLeaveQueue, onTakeQueue, isRegistrationStarted, isAlreadyInQueue, remains }) => {
    return (
        isRegistrationStarted ?
            <React.Fragment>
                {isAlreadyInQueue && <Button className={classes.button} disabled={queue.isLoading} onClick={onLeaveQueue} variant="contained" color="secondary">Покинуть очередь</Button>}
                {!isAlreadyInQueue && <Button className={classes.button} disabled={queue.isLoading} onClick={onTakeQueue} variant="contained" color="primary">Занять очередь</Button>}
            </React.Fragment> :
            <Button className={classes.button} onClick={onLeaveQueue} variant="contained" disabled={true} >
                Регистрация через: {remains}
            </Button>
    );
}

EventButton.propTypes = {
    classes: PropTypes.object.isRequired,
    queue: PropTypes.object.isRequired,
    onLeaveQueue: PropTypes.func.isRequired,
    onTakeQueue: PropTypes.func.isRequired,
    isRegistrationStarted: PropTypes.bool.isRequired,
    isAlreadyInQueue: PropTypes.bool.isRequired,
    remains: PropTypes.string.isRequired
};

export default withStyles(styles)(EventButton);