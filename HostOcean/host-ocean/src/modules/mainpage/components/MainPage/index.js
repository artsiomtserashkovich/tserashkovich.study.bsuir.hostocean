import { withStyles } from '@material-ui/core';
import * as React from 'react';
import DailyEventsContainer from '../../containers/DailyEventsContainer';

import styles from "./styles";

const MainPage = () => {
    return (
        <div>
            <DailyEventsContainer />
        </div>
    );
}

export default withStyles(styles)(MainPage)