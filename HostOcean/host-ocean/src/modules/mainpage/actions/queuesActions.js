import { createAction } from 'redux-actions'

export const getQueueRequest = createAction('GET_QUEUE_REQUEST')
export const getQueueFailed = createAction('GET_QUEUE_FAILED')
export const getQueueSuccess = createAction('GET_QUEUE_SUCCESS')