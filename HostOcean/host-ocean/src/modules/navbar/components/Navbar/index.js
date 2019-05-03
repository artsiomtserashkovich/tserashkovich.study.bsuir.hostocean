import React from "react";
import { withStyles } from "@material-ui/core/styles/index"
import {
    Grid,
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
                    <Grid container direction="row" alignItems={"center"} className={classes.grid}>
                        <Grid item lg={2}>
                            <LabelLink to={"/"} label={"HostOcean"} primary/>
                        </Grid>
                        <Grid item lg={1}>
                            <LabelLink to={"/statistics"} label={"Statistics"}/>
                        </Grid>                        
                        <Grid item lg={9} >
                            <Grid container justify={"flex-end"}>
                                <Grid item>
                                    <UserContainer/>
                                </Grid>
                            </Grid>
                        </Grid>
                    </Grid>
                </AppBar>
            </div>
        );
    }
}

export default withStyles(styles)(NavBarComponent);
