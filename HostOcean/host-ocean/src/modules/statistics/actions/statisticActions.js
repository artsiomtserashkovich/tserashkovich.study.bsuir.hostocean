import { createAction } from 'redux-actions'

export const statisticsRequest = createAction('GET_STATISTIC_REQUEST')
export const statisticsFailed = createAction('GET_STATISTIC_FAILED')
export const statisticsSuccess = createAction('GET_STATISTIC_SUCCESS')