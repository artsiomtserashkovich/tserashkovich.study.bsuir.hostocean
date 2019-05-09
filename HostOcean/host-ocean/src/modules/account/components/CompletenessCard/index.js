import React from "react";
import PropTypes from "prop-types";

import {
    Paper,
    Typography,
    withStyles,
    Avatar,
    Divider
} from "@material-ui/core";

import styles from "./styles";
import CircularProgressbar from "react-circular-progressbar";
import "react-circular-progressbar/dist/styles.css";

function CustomContentProgressbar(props) {
    const { children, ...otherProps } = props;

    return (
        <div
            style={{
                position: "relative",
                width: "100%",
                height: "100%"
            }}
        >
            <div style={{ position: "absolute" }}>
                <CircularProgressbar {...otherProps} />
            </div>
            <div
                style={{
                    position: "absolute",
                    height: "100%",
                    width: "100%",
                    display: "flex",
                    flexDirection: "column",
                    justifyContent: "center",
                    alignItems: "center"
                }}
            >
                {props.children}
            </div>
        </div>
    );
}

const CompletenessCard = ({ classes, completeness }) => {
    return (
        <Paper className={classes.card}>
            <div className={classes.header}>
                <div className={classes.title}>
                    <Avatar className={classes.avatar}>
                        <i className="material-icons">star_border</i>
                    </Avatar>
                    <Typography variant="subtitle1">Completness</Typography>
                </div>
            </div>
            <Divider />
            <div className={classes.body}>
                <div
                    style={{
                        width: "150px",
                        height: "150px"
                    }}
                >
                    <CustomContentProgressbar
                        percentage={completeness}
                        styles={{
                            path: {
                                stroke: `rgba(15, 158, 0, ${completeness / 100})`,
                                transition: "stroke-dashoffset 0.5s ease 0s"
                            }
                        }}
                    >
                        <Typography variant="h6">{completeness}% </Typography>
                    </CustomContentProgressbar>
                </div>
            </div>
        </Paper>
    );
};

CompletenessCard.propTypes = {
    classes: PropTypes.object.isRequired,
    completeness: PropTypes.number.isRequired
};

export default withStyles(styles)(CompletenessCard);
