import React from "react";
import { withStyles } from "@material-ui/core/styles/index"
import {
    Typography,
    Toolbar,
    AppBar,
    List,
    ListItem,
    Divider,
    SwipeableDrawer,
    IconButton
} from "@material-ui/core";
import MenuIcon from '@material-ui/icons/Menu';
import { Link } from "react-router-dom";

import UserContainer from "./../../containers/UserContainer";

import styles from "./styles";

const sideList = (classes) => (
    <List>
        <ListItem>
            <Link className={classes.link} to="/">
                <Typography variant="h6" color="inherit" className={classes.grow}>
                    HostOcean
                </Typography>
            </Link>
        </ListItem>
        <Divider />
        <ListItem>
            <Link className={classes.link} to="/statistics">
                <Typography variant="subtitle1" color="inherit" className={classes.grow}>
                    Statistics
                </Typography>
            </Link>
        </ListItem>
    </List >
);

const NavBarComponent = ({ classes, toggleMenu, isMenuOpened }) => (
    <div className={classes.root}>
        <AppBar position="static">
            <Toolbar className={classes.toolbar}>
                <div className={classes.main}>
                    <div className={classes.sidebar}>
                        <IconButton className={classes.menuButton} onClick={toggleMenu} >
                            <MenuIcon />
                        </IconButton>
                        <SwipeableDrawer open={isMenuOpened} onClose={toggleMenu} onOpen={() => {}}>
                            {sideList(classes)}
                        </SwipeableDrawer>
                    </div>
                    <Link className={classes.link} to="/">
                        <Typography variant="h6" color="inherit" className={classes.grow}>
                            HostOcean
                        </Typography>
                    </Link>
                    <div className={classes.items}>
                        <Link className={classes.link} to="/statistics">
                            <Typography variant="subtitle1" color="inherit" className={classes.grow}>
                                Statistics
                            </Typography>
                        </Link>
                    </div>
                </div>
                <UserContainer />
            </Toolbar>
        </AppBar>
    </div>
);

export default withStyles(styles)(NavBarComponent);
