import moment from "moment";

const statisticRequests = {
    getStatisticRequest : ({startPeriod, endPeriod}) => ({
        url: `api/statistic/?startPeriod=${moment(startPeriod).format('YYYY MM DD')}&endPeriod=${moment(endPeriod).format('YYYY MM DD')}`,
        method: "get"
    })
}

export default statisticRequests;
