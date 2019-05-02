import React from "react";
import { withStyles } from "@material-ui/core/styles/index";
import { Button, IconButton, Typography, Menu, MenuItem } from "@material-ui/core";
import { AccountCircle } from "@material-ui/icons";
import { Link } from "react-router-dom";

import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSignInAlt } from '@fortawesome/free-solid-svg-icons'
import styles from "./styles";

library.add(faSignInAlt)

const User = ({
    classes,
    user,
    open,
    handleMenu,
    handleClose,
    anchorEl }) => {
    return (
        !user.id ?
            <Button color="inherit">
                <Link className={classes.link} to="/accounts/login">
                    <Typography variant="button" className={classes.text}>Login</Typography>
                </Link>
                <FontAwesomeIcon icon="sign-in-alt" />
            </Button>
            : <div className={classes.usersBar}>
                <Typography variant="button" className={classes.userName}>
                    {user.userName}
                </Typography>
                <IconButton
                    className={classes.usersIcon}
                    aria-owns={open ? "menu-appbar" : null}
                    aria-haspopup="true"
                    onClick={handleMenu}
                    color="inherit"
                >
                    <AccountCircle />
                </IconButton>
                <Menu
                    id="menu-appbar"
                    anchorEl={anchorEl}
                    anchorOrigin={{
                        vertical: "top",
                        horizontal: "right"
                    }}
                    transformOrigin={{
                        vertical: "top",
                        horizontal: "right"
                    }}
                    open={open}
                    onClose={handleClose}
                >
                    <MenuItem onClick={handleClose}>My account</MenuItem>
                    <Link className={classes.link} to="/accounts/login">
                        <MenuItem onClick={handleClose}>
                            Log out
                        </MenuItem>
                    </Link>
                </Menu>
            </div>
    );
}

export default withStyles(styles)(User);
