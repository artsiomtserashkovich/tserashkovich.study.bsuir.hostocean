import { createAction } from 'redux-actions'

export const setConfig = createAction('SET_CONFIG')

export const setToken = createAction('SET_TOKEN')
export const removeToken = createAction('REMOVE_TOKEN')

export const removeUser = createAction('GET_USER_REQUEST')
export const getUserRequest = createAction('GET_USER_REQUEST')
export const getUserFailed = createAction('GET_USER_FAILED')
export const getUserSuccess = createAction('GET_USER_SUCCESS')