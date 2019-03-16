import { withStyles } from '@material-ui/core';
import * as React from 'react';
import DailyLabworksContainer from '../../containers/DailyLabworksContainer';

import styles from "./styles";

const MainPage = () => {
    return (
        <div>
            <DailyLabworksContainer />
        </div>
    );
}

export default withStyles(styles)(MainPage)