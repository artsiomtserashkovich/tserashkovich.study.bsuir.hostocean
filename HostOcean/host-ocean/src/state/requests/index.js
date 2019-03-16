import accountRequests from './accountRequests'
import groupRequests from './groupRequests'

const API = {
    ...accountRequests,
    ...groupRequests
}

export default API