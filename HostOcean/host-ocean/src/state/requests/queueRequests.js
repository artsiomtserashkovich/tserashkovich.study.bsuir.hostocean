const queueRequests = {
    getQueueRequest: ({queueId}) => ({
        url: `api/queue?id=${queueId}`,
        method: 'get'
    })
}

export default queueRequests
