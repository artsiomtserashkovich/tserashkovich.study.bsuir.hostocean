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
                    <StatisticChart
                        chartId={"testChart"}
                        colorSchema={"#722452"}
                        seriesDataField={"queueStartTime"}
                        seriesValueField={"place"}
                        seriesTooltipTextPattern={"{queueStartTime}:{place}; TakeTime:{takeQueueTime}"}
                        data={
                            [
                                {place: 3, queueStartTime: "2019-05-01", takeQueueTime: "0.2h"},
                                {place: 2, queueStartTime: "2019-05-02", takeQueueTime: "0.2h"},
                                {place: 1, queueStartTime: "2019-05-04", takeQueueTime: "0.2h"},
                                {place: 4, queueStartTime: "2019-05-08", takeQueueTime: "0.2h"},
                                {place: 2, queueStartTime: "2019-05-10", takeQueueTime: "0.2h"},
                                {place: 10,queueStartTime: "2019-05-20", takeQueueTime: "0.2h"},
                                {place: 8, queueStartTime: "2019-05-28", takeQueueTime: "0.2h"},
                                {place: 5, queueStartTime: "2019-05-30", takeQueueTime: "0.2h"},
                                {place: 3, queueStartTime: "2019-06-01", takeQueueTime: "0.2h"}
                            ]
                        }

                    />
                    <StatisticChart
                        chartId={"testChart1"}
                        colorSchema={"#4c6859"}
                        seriesDataField={"queueStartTime"}
                        seriesValueField={"place"}
                        seriesTooltipTextPattern={"{queueStartTime}:{place}; TakeTime:{takeQueueTime}"}
                        data={
                            [
                                {place: 3, queueStartTime: "2019-05-01", takeQueueTime: "0.2h"},
                                {place: 2, queueStartTime: "2019-05-02", takeQueueTime: "0.2h"},
                                {place: 1, queueStartTime: "2019-05-04", takeQueueTime: "0.2h"},
                                {place: 4, queueStartTime: "2019-05-08", takeQueueTime: "0.2h"},
                                {place: 2, queueStartTime: "2019-05-10", takeQueueTime: "0.2h"},
                                {place: 10,queueStartTime: "2019-05-20", takeQueueTime: "0.2h"},
                                {place: 8, queueStartTime: "2019-05-28", takeQueueTime: "0.2h"},
                                {place: 5, queueStartTime: "2019-05-30", takeQueueTime: "0.2h"},
                                {place: 3, queueStartTime: "2019-06-01", takeQueueTime: "0.2h"}
                            ]
                        }

                    />
                    <StatisticChart
                        chartId={"testChart2"}
                        colorSchema={"#554b63"}
                        seriesDataField={"queueStartTime"}
                        seriesValueField={"place"}
                        seriesTooltipTextPattern={"{queueStartTime}:{place}; TakeTime:{takeQueueTime}"}
                        data={
                            [
                                {place: 3, queueStartTime: "2019-05-01", takeQueueTime: "0.2h"},
                                {place: 2, queueStartTime: "2019-05-02", takeQueueTime: "0.2h"},
                                {place: 1, queueStartTime: "2019-05-04", takeQueueTime: "0.2h"},
                                {place: 4, queueStartTime: "2019-05-08", takeQueueTime: "0.2h"},
                                {place: 2, queueStartTime: "2019-05-10", takeQueueTime: "0.2h"},
                                {place: 10,queueStartTime: "2019-05-20", takeQueueTime: "0.2h"},
                                {place: 8, queueStartTime: "2019-05-28", takeQueueTime: "0.2h"},
                                {place: 5, queueStartTime: "2019-05-30", takeQueueTime: "0.2h"},
                                {place: 3, queueStartTime: "2019-06-01", takeQueueTime: "0.2h"}
                            ]
                        }

                    />
                </Grid>
            </Grid>
        );
    }
}
