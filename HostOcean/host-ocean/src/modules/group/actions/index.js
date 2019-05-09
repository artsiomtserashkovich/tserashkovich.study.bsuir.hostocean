import { createAction } from 'redux-actions'

export const getGroupRequest = createAction('GET_GROUP_REQUEST')
export const getGroupSuccess = createAction('GET_GROUP_SUCCESS')
export const getGroupFailed = createAction('GET_GROUP_FAILED')