import React from "react";
import { withStyles } from "@material-ui/core/styles/index"
import {
    Toolbar, Typography,
    AppBar
} from "@material-ui/core";

import UserContainer from "./../../containers/UserContainer";

import styles from "./styles";

class NavBarComponent extends React.Component {
    render() {
        const { classes } = this.props;
        return (
            <div className={classes.root}>
                <AppBar position="static">
                    <Toolbar>
                        <Typography variant="h6" color="inherit" className={classes.grow}>
                            HostOcean
                        </Typography>
                        <UserContainer />
                    </Toolbar>
                </AppBar>
            </div>
        );
    }
}

export default withStyles(styles)(NavBarComponent);
