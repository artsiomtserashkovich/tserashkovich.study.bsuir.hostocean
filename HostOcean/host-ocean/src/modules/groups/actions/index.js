import { createAction } from 'redux-actions'

export const getGroupsRequest = createAction('GET_GROUPS_REQUEST')
export const getGroupsSuccess = createAction('GET_GROUPS_SUCCESS')
export const getGroupsFailed = createAction('GET_GROUPS_FAILED')