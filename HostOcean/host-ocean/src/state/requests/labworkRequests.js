const labworkRequests = {
    getLabworksRequest: ({groupId}) => ({
        url: `api/labworks/upcoming?groupId=${groupId}`,
        method: 'get'
    })
}

export default labworkRequests
