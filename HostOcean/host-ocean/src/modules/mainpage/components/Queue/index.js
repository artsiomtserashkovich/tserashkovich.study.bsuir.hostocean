import { Button, withStyles, CircularProgress } from '@material-ui/core';
import * as React from 'react';
import User from "./../User"

import styles from "./styles";

const Queue = ({ classes, queue, onTakeQueue, onLeaveQueue, isAlreadyInQueue }) => {
    return (
        (queue && !queue.isLoading) ?
            <React.Fragment>
                <div className={classes.queueContainer}>
                    {
                        queue.userQueues.map((userQueue, index) => (
                            <User key={index} order={index + 1} user={userQueue.user} />
                        ))
                    }
                </div>
                {isAlreadyInQueue ?
                    <Button className={classes.button} onClick={onLeaveQueue} variant="contained" color="secondary">Покинуть очередь</Button>
                    : <Button className={classes.button} onClick={onTakeQueue} variant="contained" color="primary">Занять очередь</Button>}
            </React.Fragment> :
            <div className={classes.spinnerContainer}>
                <CircularProgress color="secondary" />
            </div>
    );
}

export default withStyles(styles)(Queue)