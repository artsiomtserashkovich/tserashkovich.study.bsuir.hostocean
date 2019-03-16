import { takeLatest, all, put } from 'redux-saga/effects'

import * as labworksActions from "../actions/labworksActions"
import * as queuesActions from "../actions/queuesActions"

function* getLabworksSuccess(action) {
    if (action.response.data) {
        const labworks = action.response.data;

        for (let i=0; i < labworks.length; i++) {
            yield put(queuesActions.getQueueRequest({queueId: labworks[i].queueId}))
        }
    }
}

function* labworkSaga() {
    yield all([
        takeLatest(labworksActions.getLabworksSuccess, getLabworksSuccess),
    ])
}

export default labworkSaga