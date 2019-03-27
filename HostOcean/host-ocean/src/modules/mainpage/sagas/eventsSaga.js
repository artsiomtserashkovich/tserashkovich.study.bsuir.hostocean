import { takeLatest, all } from 'redux-saga/effects'

import * as eventsActions from "../actions/eventsActions"

function* getEventsSuccess(action) {
    if (action.response.data) {
        const events = action.response.data;

        for (let i = 0; i < events.length; i++) {
            //yield put(queuesActions.getQueueRequest({queueId: events[i].queueId}))
        }
    }
}

function* eventsSaga() {
    yield all([
        takeLatest(eventsActions.getEventsSuccess, getEventsSuccess),
    ])
}

export default eventsSaga