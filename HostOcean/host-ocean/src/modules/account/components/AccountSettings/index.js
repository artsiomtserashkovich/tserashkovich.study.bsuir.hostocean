import React from "react";

import { withStyles } from "@material-ui/core";

import styles from "./styles";
import UserCardContainer from "./../../containers/UserCardContainer";
import PasswordCardContainer from "../../containers/PasswordCardContainer";
import NotificationsCardContainer from "../../containers/NotificationsCardContainer";
import UserEventsContainer from "../../containers/UserEventsContainer";
import GuiCardContainer from "../../containers/GuiCardContainer";
import CompletenessCardContainer from "../../containers/CompletenessCardContainer";

const AccountSettings = ({ classes }) => {
    return (
        <div className={classes.root}>
            <div className={classes.main}>
                <UserCardContainer />
                <div className={classes.mid}>
                    <PasswordCardContainer />
                    <NotificationsCardContainer />
                </div>
                <div className={classes.mid}>
                    <CompletenessCardContainer />
                    <GuiCardContainer />
                </div>
            </div>
            <div>
                <UserEventsContainer />
            </div>
        </div>
    );
};

export default withStyles(styles)(AccountSettings);
