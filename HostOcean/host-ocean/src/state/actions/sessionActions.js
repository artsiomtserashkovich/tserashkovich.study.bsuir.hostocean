import { createAction } from 'redux-actions'

export const setConfig = createAction('SET_CONFIG')

export const setToken = createAction('SET_TOKEN')
export const removeToken = createAction('REMOVE_TOKEN')

export const removeUser = createAction('GET_USER_REQUEST')
export const getUserRequest = createAction('GET_USER_REQUEST')
export const getUserFailed = createAction('GET_USER_FAILED')
export const getUserSuccess = createAction('GET_USER_SUCCESS')

export const createConnection = createAction('CREATE_CONNECTION')
export const createConnectionSuccess = createAction('CREATE_CONNECTION_SUCCESS')
export const createConnectionFailed = createAction('CREATE_CONNECTION_FAILED')