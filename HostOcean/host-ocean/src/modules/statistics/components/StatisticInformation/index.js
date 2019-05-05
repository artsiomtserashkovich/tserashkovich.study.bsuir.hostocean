import React from "react";
import PropTypes from 'prop-types';
import styles from "./styles";
import { withStyles, Grid, Typography } from "@material-ui/core";

class StatisticsInformation extends React.Component {
    render() {
        const { classes } = this.props;
        return(
            <Grid
                container
                direction="row"
                className={classes.gridContainer}
            >
                <Grid item lg={4} md={6} xs={12}>
                    <Typography variant={"subtitle1"}>
                        Количество очередей: {this.props.information.countQueues || 0}
                    </Typography>
                </Grid>
                <Grid item lg={4} md={6} xs={12}>
                    <Typography variant={"subtitle1"}>
                        Среднее время: {this.props.information.averageTakeQueueTime || 0}
                    </Typography>
                </Grid>
                <Grid item lg={4} md={6} xs={12}>
                    <Typography variant={"subtitle1"}>
                        Среднее место: {this.props.information.averagePlace || 0}
                    </Typography>
                </Grid>
            </Grid>
        );
    }
}

StatisticsInformation.propTypes = {
    information: PropTypes.object.isRequired,
};

export default withStyles(styles)(StatisticsInformation);
