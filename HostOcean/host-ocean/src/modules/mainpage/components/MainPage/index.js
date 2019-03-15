import { Typography, withStyles } from '@material-ui/core';
import * as React from 'react';
import Account from './../Account/index';
import LabworksContainer from '../../containers/LabworksContainer';
import Navigation from './../Navigation/index';

import styles from "./styles";

const MainPage = ({ accountAbout }) => {
    return (
        <div>
            <Typography align={"left"} variant={"h4"} >
                Лабораторные работы <br />на завтра
            </Typography>
            <Account account={accountAbout} />
            <LabworksContainer />
            <Navigation />
        </div>
    );
}

export default withStyles(styles)(MainPage)