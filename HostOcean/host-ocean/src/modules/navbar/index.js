import React from "react";
import { withStyles } from "@material-ui/core/styles/index"
import {
    Toolbar, IconButton, Typography,
    Button, AppBar
} from "@material-ui/core";
import MenuIcon from '@material-ui/icons/Menu';

import styles from "./styles"

class NavBar extends React.Component {
    render() {
        const { classes } = this.props;
        return (
            <div className={classes.root}>
                <AppBar position="static">
                    <Toolbar>
                        <IconButton className={classes.menuButton} color="inherit" aria-label="Menu">
                            <MenuIcon />
                        </IconButton>
                        <Typography variant="h6" color="inherit" className={classes.grow}>
                            Host Ocean
                        </Typography>
                        <Button color="inherit">Login</Button>
                    </Toolbar>
                </AppBar>
            </div>
        );
    }
}

export default withStyles(styles)(NavBar);
