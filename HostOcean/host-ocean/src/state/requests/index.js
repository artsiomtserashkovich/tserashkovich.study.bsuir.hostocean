import accountRequests from './accountRequests'
import groupRequests from './groupRequests'
import labworkRequests from './labworkRequests'
import queueRequests from './queueRequests'
import statisticRequests from './statisticRequests';

const API = {
    ...accountRequests,
    ...groupRequests,
    ...labworkRequests,
    ...queueRequests,
    ...statisticRequests,
}

export default API