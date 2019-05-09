import React from "react";
import PropTypes from "prop-types";

import CircularProgressbar from "react-circular-progressbar"

import {
    Paper,
    Typography,
    withStyles,
    Avatar,
    Divider,
    FormControlLabel,
    Switch
} from "@material-ui/core";

import styles from "./styles";

const GuiCard = ({ classes, changeColorTheme, isDarkThemeEnabled }) => {
    return (
        <Paper className={classes.card}>
            <div className={classes.header}>
                <div className={classes.title}>
                    <Avatar className={classes.avatar}>
                        <i className="material-icons">brush</i>
                    </Avatar>
                    <Typography variant="subtitle1">Interface</Typography>
                </div>
            </div>
            <Divider />
            <div className={classes.body}>
                <div className={classes.fields}>
                    <FormControlLabel
                        control={
                            <Switch
                                checked={isDarkThemeEnabled}
                                onChange={changeColorTheme}
                                value="emailNotifications"
                            />
                        }
                        label="Dark theme"
                    />
                </div>
            </div>
        </Paper>
    );
};

GuiCard.propTypes = {
    classes: PropTypes.object.isRequired,
    changeColorTheme: PropTypes.func.isRequired,
    isDarkThemeEnabled: PropTypes.bool.isRequired
};

export default withStyles(styles)(GuiCard);
