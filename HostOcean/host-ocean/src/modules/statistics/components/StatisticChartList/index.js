import { Paper, Divider, Typography} from "@material-ui/core";
import React from "react";
import StatisticsInformation from "../StatisticInformation";
import StatisticChart from "../StatisticChart";

export default class StatisticsChartList extends React.Component {
    render() {
        return(
            <Paper>
                <StatisticsInformation information={{
                    countQueues: 4,
                    averageTakeQueueTime: "30 min",
                    averagePlace: 3,
                }}/>
                <Divider/>
                <Typography variant={"h6"}>
                    ЦОСиИ
                </Typography>
                <StatisticChart
                    chartId={"testChart1"}
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
                <Divider/>
                <Typography variant={"h6"}>
                    ТРИТПО
                </Typography>
                <StatisticChart
                    chartId={"testChart2"}
                    colorSchema={"#648931"}
                    seriesDataField={"queueStartTime"}
                    seriesValueField={"place"}
                    seriesTooltipTextPattern={"{queueStartTime}:{place}; TakeTime:{takeQueueTime}"}
                    data={
                        [
                            {place: 7, queueStartTime: "2019-05-01", takeQueueTime: "0.2h"},
                            {place: 3, queueStartTime: "2019-05-02", takeQueueTime: "0.2h"},
                            {place: 8, queueStartTime: "2019-05-04", takeQueueTime: "0.2h"},
                            {place: 2, queueStartTime: "2019-05-08", takeQueueTime: "0.2h"},
                            {place: 1, queueStartTime: "2019-05-10", takeQueueTime: "0.2h"},
                            {place: 8,queueStartTime: "2019-05-20", takeQueueTime: "0.2h"},
                            {place: 4, queueStartTime: "2019-05-28", takeQueueTime: "0.2h"},
                            {place: 9, queueStartTime: "2019-05-30", takeQueueTime: "0.2h"},
                            {place: 3, queueStartTime: "2019-06-01", takeQueueTime: "0.2h"}
                        ]
                    }
                />
                <Divider/>
                <Typography variant={"h6"}>
                    АКСИС
                </Typography>
                <StatisticChart
                    chartId={"testChart3"}
                    colorSchema={"#491c5b"}
                    seriesDataField={"queueStartTime"}
                    seriesValueField={"place"}
                    seriesTooltipTextPattern={"{queueStartTime}:{place}; TakeTime:{takeQueueTime}"}
                    data={
                        [
                            {place: 1, queueStartTime: "2019-05-01", takeQueueTime: "0.2h"},
                            {place: 2, queueStartTime: "2019-05-02", takeQueueTime: "0.2h"},
                            {place: 3, queueStartTime: "2019-05-04", takeQueueTime: "0.2h"},
                            {place: 4, queueStartTime: "2019-05-08", takeQueueTime: "0.2h"},
                            {place: 22, queueStartTime: "2019-05-10", takeQueueTime: "0.2h"},
                            {place: 22,queueStartTime: "2019-05-20", takeQueueTime: "0.2h"},
                            {place: 6, queueStartTime: "2019-05-28", takeQueueTime: "0.2h"},
                            {place: 3, queueStartTime: "2019-05-30", takeQueueTime: "0.2h"},
                            {place: 1, queueStartTime: "2019-06-01", takeQueueTime: "0.2h"}
                        ]
                    }
                />
                <Divider/>
                <Typography variant={"h6"}>
                    АВП
                </Typography>
                <StatisticChart
                    chartId={"testChart4"}
                    colorSchema={"#9e7b74"}
                    seriesDataField={"queueStartTime"}
                    seriesValueField={"place"}
                    seriesTooltipTextPattern={"{queueStartTime}:{place}; TakeTime:{takeQueueTime}"}
                    data={
                        [
                            {place: 8, queueStartTime: "2019-05-01", takeQueueTime: "0.2h"},
                            {place: 23, queueStartTime: "2019-05-02", takeQueueTime: "0.2h"},
                            {place: 12, queueStartTime: "2019-05-04", takeQueueTime: "0.2h"},
                            {place: 21, queueStartTime: "2019-05-08", takeQueueTime: "0.2h"},
                            {place: 7, queueStartTime: "2019-05-10", takeQueueTime: "0.2h"},
                            {place: 2,queueStartTime: "2019-05-20", takeQueueTime: "0.2h"},
                            {place: 1, queueStartTime: "2019-05-28", takeQueueTime: "0.2h"},
                            {place: 7, queueStartTime: "2019-05-30", takeQueueTime: "0.2h"},
                            {place: 3, queueStartTime: "2019-06-01", takeQueueTime: "0.2h"}
                        ]
                    }
                />
            </Paper>
        )
    }
}
