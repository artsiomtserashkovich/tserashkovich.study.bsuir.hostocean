import { createAction } from 'redux-actions'

export const getPingRequest = createAction('GET_PING_REQUEST')
export const getPingSuccess = createAction('GET_PING_SUCCESS')
export const getPingFailed = createAction('GET_PING_FAILED')

export const registerRequest = createAction('REGISTER_REQUEST')
export const registerSuccess = createAction('REGISTER_SUCCESS')
export const registerFailed = createAction('REGISTER_FAILED')