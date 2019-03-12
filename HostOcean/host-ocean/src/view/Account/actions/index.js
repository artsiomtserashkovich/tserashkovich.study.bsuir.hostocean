import { createAction } from 'redux-actions'

export const getPingRequest = createAction('GET_PING_REQUEST')
export const getPingSuccess = createAction('GET_PING_SUCCESS')
export const getPingFailed = createAction('GET_PING_FAILED')