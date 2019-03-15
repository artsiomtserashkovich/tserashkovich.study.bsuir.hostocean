import React from "react";
import { withStyles } from "@material-ui/core/styles/index"
import {
    Toolbar, Typography,
    Button, AppBar
} from "@material-ui/core";

import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSignInAlt } from '@fortawesome/free-solid-svg-icons'
import styles from "./styles";

library.add(faSignInAlt)

class NavBarComponent extends React.Component {
    render() {
        const { classes } = this.props;
        return (
            <div className={classes.root}>
                <AppBar position="static">
                    <Toolbar>
                        <img alt={"text"} width={"70px"} height={"60px"} />

                        <Typography variant="h6" color="inherit" className={classes.grow}>
                            HostOcean
                        </Typography>
                        <Button color="inherit">Login   <FontAwesomeIcon icon="sign-in-alt" /></Button>
                    </Toolbar>
                </AppBar>
            </div>
        );
    }
}

export default withStyles(styles)(NavBarComponent);
