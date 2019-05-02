const statisticRequests = {
    statisticRequest : ({startPeriod, endPeriod}) => ({
        url: `api/statistic/?startPeriod=${startPeriod}&endPeriod=${endPeriod}`,
        method: "get"
    })
}

export default statisticRequests;
