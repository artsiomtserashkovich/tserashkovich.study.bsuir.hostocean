import React from "react";
import { Typography, Divider, withStyles } from "@material-ui/core";

import styles from "./styles"
import LabworkContainer from "../../containers/LabworkContainer";

const LabworksList = ({ classes, laboratoryWorks, date }) => {
    return (
        <div>
            <div className={classes.header}>
                <Typography className={classes.title} variant="h6">{date}</Typography>
                <Divider />
            </div>
            <div className={classes.container}>
                {
                    laboratoryWorks.map((labwork, index) => (
                        <LabworkContainer key={index} id={labwork.id} />
                    ))
                }
            </div>
        </div>
    );
}

export default withStyles(styles)(LabworksList);