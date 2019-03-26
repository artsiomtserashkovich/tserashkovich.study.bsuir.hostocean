import { createAction } from 'redux-actions'

export const getEventsRequest = createAction('GET_EVENTS_REQUEST')
export const getEventsFailed = createAction('GET_EVENTS_FAILED')
export const getEventsSuccess = createAction('GET_EVENTS_SUCCESS')