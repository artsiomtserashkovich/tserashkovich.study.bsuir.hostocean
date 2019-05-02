import React from "react";
import { withStyles } from "@material-ui/core/styles/index"
import {
    Toolbar,
    AppBar
} from "@material-ui/core";
import LabelLink from "../LabelLink/LabelLink";

import UserContainer from "./../../containers/UserContainer";

import styles from "./styles";

class NavBarComponent extends React.Component {
    render() {
        const { classes } = this.props;
        return (
            <div className={classes.root}>
                <AppBar position="static">
                    <Toolbar>
                        <LabelLink to={"/"} label={"HostOcean"}/>
                        <LabelLink to={"/statistics"} label={"Statistics"}/>
                        <UserContainer />
                    </Toolbar>
                </AppBar>
            </div>
        );
    }
}

export default withStyles(styles)(NavBarComponent);
