import * as React from 'react';
import { Typography } from '@material-ui/core';

class QueueChooseContainer extends React.Component{
    public render(){
        return(
            <Typography align={"left"} variant={"h2"} >
                Its Queue Choose
            </Typography>
        );
    }
}

export const QueueChoose =  QueueChooseContainer;
