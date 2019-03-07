import * as React from 'react';
import { Typography } from '@material-ui/core';

class StatisticsContainer extends React.Component{
    public render(){
        return(
            <Typography align={"left"} variant={"h2"} >
                Its Statistics
            </Typography>
        );
    }
}

export const Statistics =  StatisticsContainer;
