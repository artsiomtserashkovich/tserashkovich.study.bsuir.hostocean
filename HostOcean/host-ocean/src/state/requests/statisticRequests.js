const statisticRequests = {
    getCurrentUserStatisticForPeriod : ({startPeriod, endPeriod}) => ({
        url: `api/statistic/?startPeriod=${startPeriod}&endPeriod=${endPeriod}`,
        method: "get"
    })
}

export default statisticRequests;