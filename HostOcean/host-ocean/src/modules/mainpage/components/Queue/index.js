import { withStyles, CircularProgress } from '@material-ui/core';
import * as React from 'react';
import User from "./../User"

import styles from "./styles";

const Queue = ({ classes, queue }) => {
    return (
        (queue && !queue.isLoading) ?
            <div className={classes.queueContainer}>
                {
                    queue.userQueues.map((userQueue, index) => (
                        <User key={index} order={index + 1} user={userQueue.user} />
                    ))
                }
            </div> :
            <div className={classes.spinnerContainer}>
                <CircularProgress color="secondary" />
            </div>
    );
}

export default withStyles(styles)(Queue)