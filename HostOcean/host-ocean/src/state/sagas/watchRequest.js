import { call, put, takeEvery, select } from 'redux-saga/effects'
import _ from 'lodash'

import ApiMethods from '../requests'
import ApiService from '../services/API'

function* callAPI(action) {
    const apiHostName = "https://localhost:5001/"
    //TODO: add selector
    const accessToken = null
    const data = ApiMethods[_.camelCase(action.type)](action.payload)
    try {
        const response = yield call(ApiService, {
            hostName: apiHostName,
            accessToken,
            data
        })

        const newType = action.type.replace('_REQUEST', '_SUCCESS')
        yield put({ type: newType, response, payload: action.payload })
    } catch (e) {
        const errorModel = {
            type: action.type.replace('_REQUEST', '_FAILED'),
            payload: action.payload,
            message: e.statusText,
            status: e.status,
            response: e.response
        }
        console.error(errorModel)
        yield put(errorModel)
    }
}

export default function* watchRequest() {
    yield takeEvery((action) => /^.*_REQUEST$/.test(action.type), callAPI)
}