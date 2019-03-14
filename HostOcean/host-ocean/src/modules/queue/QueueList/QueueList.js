import * as React from 'react';
import { Typography } from '@material-ui/core';

class QueueListContainer extends React.Component {
    render() {
        return (
            <Typography align={"left"} variant={"h2"} >
                Its Queue List
            </Typography>
        );
    }
}

export const QueueList = QueueListContainer;
