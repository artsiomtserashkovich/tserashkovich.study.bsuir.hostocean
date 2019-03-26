import { takeLatest, all } from 'redux-saga/effects'

import * as labworksActions from "../actions/labworksActions"

function* getLabworksSuccess() {
}

function* labworkSaga() {
    yield all([
        takeLatest(labworksActions.getLabworksSuccess, getLabworksSuccess),
    ])
}

export default labworkSaga