const labworkRequests = {
    getLabworksRequest: ({groupId}) => ({
        url: `api/labworks/upcoming?groupId=${groupId}`,
        method: 'get'
    }),
    getEventsRequest: ({groupId}) => ({
        url: `api/events/upcoming?groupId=${groupId}`,
        method: 'get'
    })
}

export default labworkRequests
