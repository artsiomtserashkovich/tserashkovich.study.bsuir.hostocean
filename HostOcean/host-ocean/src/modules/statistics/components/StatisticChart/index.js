import React from 'react';
import styles from "./styles";
import { Paper, withStyles } from "@material-ui/core";
import * as am4core from "@amcharts/amcharts4/core";
import * as am4charts from "@amcharts/amcharts4/charts";

const chartId = "statisticdiv"

class StatisticChart extends React.Component {
    componentDidMount() {    }
    render() {
        const { classes } = this.props;
        return(
            <Paper className={classes.paper}>
                <div id={chartId} style={classes.chartContainetDiv}></div>
            </Paper>
        );
    }
}

export default withStyles(styles)(StatisticChart);
