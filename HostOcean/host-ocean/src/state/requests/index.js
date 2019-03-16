import accountRequests from './accountRequests'
import groupRequests from './groupRequests'
import labworkRequests from './labworkRequests'
import queueRequests from './queueRequests'

const API = {
    ...accountRequests,
    ...groupRequests,
    ...labworkRequests,
    ...queueRequests
}

export default API