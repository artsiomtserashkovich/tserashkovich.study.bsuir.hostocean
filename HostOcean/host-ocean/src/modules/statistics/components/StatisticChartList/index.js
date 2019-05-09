import { Paper, Divider, Typography} from "@material-ui/core";
import React from "react";
import StatisticsInformation from "../StatisticInformation";
import StatisticChart from "../StatisticChart";
import PropTypes from "prop-types";
import * as _ from 'lodash';

export default class StatisticsChartList extends React.Component {
    render() {
        const { statistic } = this.props;
        const queueCharts = statistic.queueStatistics 
            ?   _(statistic.queueStatistics)
                .groupBy(val => val.queueTitle)
                .map((value, key) => ({queueTitle: key, queueStatistic: value}))
                .value()
            : [];
        return(
            <Paper>
                <StatisticsInformation information={statistic}/>
                <Divider/>
                {
                    queueCharts.map(({ queueTitle, queueStatistic }, index) => (
                        <>
                            <Typography variant={"h6"} align="center">
                                {queueTitle}
                            </Typography>                           
                              <StatisticChart
                                    chartId={"statchart" + index}
                                    colorSchema={"#722452"}
                                    seriesDataField={"queueStartTime"}
                                    seriesValueField={"place"}
                                    seriesTooltipTextPattern={"Place:{place}; TakeTime:{takeQueueTime}, Participant: {participantsCount}"}
                                    data={
                                        [
                                            ...queueStatistic,
                                            {place: 0, queueStartTime: "2019-05", takeQueueTime: ""},
                                        ]
                                    }
                                />
                            <Divider/>
                        </>
                    ))
                }
            </Paper>
        )
    }
}

StatisticsChartList.propType = {
    statistic: PropTypes.object.isRequired,
};