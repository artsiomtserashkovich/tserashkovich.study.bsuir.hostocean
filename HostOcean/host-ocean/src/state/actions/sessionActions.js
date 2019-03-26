import { createAction } from 'redux-actions'

export const setConfig = createAction('SET_CONFIG')

export const setToken = createAction('SET_TOKEN')
export const removeToken = createAction('REMOVE_TOKEN')
export const removeUser = createAction('REMOVE_USER')

export const getUserRequest = createAction('GET_USER_REQUEST')
export const getUserFailed = createAction('GET_USER_FAILED')
export const getUserSuccess = createAction('GET_USER_SUCCESS')

export const refreshTokenRequest = createAction('REFRESH_TOKEN_REQUEST')
export const refreshTokenSuccess = createAction('REFRESH_TOKEN_SUCCESS')
export const refreshTokenFailed = createAction('REFRESH_TOKEN_FAILED')