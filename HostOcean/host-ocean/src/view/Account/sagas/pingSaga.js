import {takeLatest, all} from 'redux-saga/effects'
import * as actions from "./../actions"

function* doSmthWithPing(action) {
    console.log("PING SUCCESS SAGA")
}

function* pingSaga() {
    yield all([
        takeLatest(actions.getPingSuccess, doSmthWithPing),
    ])
}

export default pingSaga