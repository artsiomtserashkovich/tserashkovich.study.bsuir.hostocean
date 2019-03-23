import { createAction } from 'redux-actions'

export const createConnection = createAction('CREATE_CONNECTION')
export const createConnectionSuccess = createAction('CREATE_CONNECTION_SUCCESS')
export const createConnectionFailed = createAction('CREATE_CONNECTION_FAILED')