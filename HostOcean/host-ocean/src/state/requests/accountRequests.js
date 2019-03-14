const accountRequests = {
    getPingRequest: () => ({
        url: `api/ping`,
        method: 'get'
    }),
    registerRequest: (data) => ({
        url: `api/user`,
        method: 'post',
        data
    }),
    loginRequest: (data) => ({
        url: `api/user/signin`,
        method: 'post',
        data
    }),
}

export default accountRequests
