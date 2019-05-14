import { withStyles, CircularProgress } from '@material-ui/core';
import * as React from 'react';

import styles from "./styles";
import UserContainer from '../../containers/UserContainer';

const Queue = ({ classes, queue }) => {
    return (
        (queue && !queue.isLoading) ?
            <div className={classes.queueContainer}>
                {
                    queue.userQueues.map((userQueue, index) => (
                        <UserContainer queueId={queue.id} key={index} order={index + 1} user={userQueue.user} isLoading={userQueue.isLoading} />
                    ))
                }
            </div> :
            <div className={classes.spinnerContainer}>
                <CircularProgress color="secondary" />
            </div>
    );
}

export default withStyles(styles)(Queue)