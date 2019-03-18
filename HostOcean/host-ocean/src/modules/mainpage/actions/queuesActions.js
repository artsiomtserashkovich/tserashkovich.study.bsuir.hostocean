import { createAction } from 'redux-actions'

export const getQueueRequest = createAction('GET_QUEUE_REQUEST')
export const getQueueFailed = createAction('GET_QUEUE_FAILED')
export const getQueueSuccess = createAction('GET_QUEUE_SUCCESS')

export const takeQueueRequest = createAction('TAKE_QUEUE_REQUEST')
export const takeQueueFailed = createAction('TAKE_QUEUE_FAILED')
export const takeQueueSuccess = createAction('TAKE_QUEUE_SUCCESS')

export const leaveQueueRequest = createAction('LEAVE_QUEUE_REQUEST')
export const leaveQueueFailed = createAction('LEAVE_QUEUE_FAILED')
export const leaveQueueSuccess = createAction('LEAVE_QUEUE_SUCCESS')