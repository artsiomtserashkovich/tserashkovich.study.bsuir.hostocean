import { createAction } from 'redux-actions'

export const getLabworksRequest = createAction('GET_LABWORKS_REQUEST')
export const getLabworksFailed = createAction('GET_LABWORKS_FAILED')
export const getLabworksSuccess = createAction('GET_LABWORKS_SUCCESS')