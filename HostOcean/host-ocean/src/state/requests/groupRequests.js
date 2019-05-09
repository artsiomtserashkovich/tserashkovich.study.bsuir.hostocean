const groupRequests = {
    getGroupsRequest: () => ({
        url: `api/groups/all`,
        method: 'get'
    }),
    getGroupRequest: (name) => ({
        url: `api/groups/${name}`,
        method: 'get'
    })
}

export default groupRequests
