import { takeLatest, all, put } from 'redux-saga/effects'

import * as queuesActions from "../actions/queuesActions"

function* updateQueue(action) {
    const { queueId } = action.payload;

    yield put(queuesActions.getQueueRequest({ queueId }))
}

function* queueSaga() {
    yield all([
        takeLatest([queuesActions.takeQueueSuccess, queuesActions.leaveQueueSuccess], updateQueue),
    ])
}

export default queueSaga