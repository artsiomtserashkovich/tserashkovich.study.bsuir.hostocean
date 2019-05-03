import React from "react";
import StatisticForm from "../components/StatisticsForm"
import StatisticChart from "../components/StatisticChart"
import { Grid } from "@material-ui/core";
import * as am4core from "@amcharts/amcharts4/core";
import am4themes_animated from "@amcharts/amcharts4/themes/animated";

am4core.useTheme(am4themes_animated);

export class StatisticsContainer extends React.Component {
    render() {
        return (
            <Grid container direction={"column"}>
                <Grid item>
                    <StatisticForm/>
                </Grid>
                <Grid item>
                    <StatisticChart/>
                </Grid>
            </Grid>
        );
    }
}
