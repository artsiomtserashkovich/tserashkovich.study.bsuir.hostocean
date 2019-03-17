const queueRequests = {
    getQueueRequest: ({queueId}) => ({
        url: `api/queue?id=${queueId}`,
        method: 'get'
    }),
    takeQueueRequest: (data) => ({
        url: `api/userqueue/take`,
        method: 'post',
        data
    }),
    leaveQueueRequest: (data) => ({
        url: `api/userqueue/leave`,
        method: 'post',
        data
    }),
}

export default queueRequests
