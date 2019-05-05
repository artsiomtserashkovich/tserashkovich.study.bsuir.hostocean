import { createAction } from 'redux-actions'

export const getStatisticRequest = createAction('GET_STATISTIC_REQUEST')
export const getStatisticFailed = createAction('GET_STATISTIC_FAILED')
export const getStatisticSuccess = createAction('GET_STATISTIC_SUCCESS')