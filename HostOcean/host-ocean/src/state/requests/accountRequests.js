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
    getUserRequest: () => ({
        url: `api/user/me`,
        method: 'get'
    }),
    refreshTokenRequest: (data) => ({
        url: `api/token/refresh`,
        method: 'post',
        data
    }),
    updateUserRequest: (data) => ({
        url: `api/user/update`,
        method: 'put',
        data
    }),
}

export default accountRequests
