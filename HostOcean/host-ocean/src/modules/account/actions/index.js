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

export const updateUserRequest = createAction('UPDATE_USER_REQUEST')
export const updateUserSuccess = createAction('UPDATE_USER_SUCCESS')
export const updateUserFailed = createAction('UPDATE_USER_FAILED')

export const editUserInfo = createAction('EDIT_USER_INFO')
export const saveUserInfo = createAction('SAVE_USER_INFO')