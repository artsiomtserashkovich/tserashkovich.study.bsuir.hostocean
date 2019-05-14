const queueRequests = {
    getQueueRequest: ({ queueId }) => ({
        url: `api/queue?id=${queueId}`,
        method: "get"
    }),
    takeQueueRequest: data => ({
        url: `api/userqueue/take`,
        method: "post",
        data
    }),
    leaveQueueRequest: data => ({
        url: `api/userqueue/leave`,
        method: "post",
        data
    }),

    createSwapRequestRequest: data => ({
        url: `api/requests/swap`,
        method: "post",
        data
    }),
    updateRequestRequest: data => ({
        url: `api/requests`,
        method: "put",
        data
    }),
    getRequestsRequest: () => ({
        url: `api/requests`,
        method: "get"
    })
};

export default queueRequests;
