import { createAction } from 'redux-actions'

export const getPingRequest = createAction('GET_PING_REQUEST')
export const getPingSuccess = createAction('GET_PING_SUCCESS')
export const getPingFailed = createAction('GET_PING_FAILED')

export const registerRequest = createAction('REGISTER_REQUEST')
export const registerSuccess = createAction('REGISTER_SUCCESS')
export const registerFailed = createAction('REGISTER_FAILED')

export const loginRequest = createAction('LOGIN_REQUEST')
export const loginSuccess = createAction('LOGIN_SUCCESS')
export const loginFailed = createAction('LOGIN_FAILED')