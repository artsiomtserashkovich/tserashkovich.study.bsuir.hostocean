import React from "react";
import StatisticForm from "../components/StatisticsForm";
import StatisticChartList from "../components/StatisticChartList"
import { Grid } from "@material-ui/core";
import * as am4core from "@amcharts/amcharts4/core";
import am4themes_animated from "@amcharts/amcharts4/themes/animated";

am4core.useTheme(am4themes_animated);

export class StatisticsContainer extends React.Component {
    state = {
        isProceedSearch: false,
    }

    render() {
        return (
            <Grid container direction={"column"}>
                <Grid item lg={6} mg={12} xs={12}>
                    <StatisticForm />
                </Grid>
                <Grid item xs={12} lg={12} mg={12}>
                    <StatisticChartList/>
                </Grid>
            </Grid>
        );
    }
}
