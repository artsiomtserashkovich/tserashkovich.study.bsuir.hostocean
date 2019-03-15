import {takeLatest, all, call} from 'redux-saga/effects'
import * as actions from "./../actions"

function* doSmthWithPing(action) {
    yield call(() => console.log("PING SUCCESS SAGA"))
}

function* pingSaga() {
    yield all([
        takeLatest(actions.getPingSuccess, doSmthWithPing),
    ])
}

export default pingSaga