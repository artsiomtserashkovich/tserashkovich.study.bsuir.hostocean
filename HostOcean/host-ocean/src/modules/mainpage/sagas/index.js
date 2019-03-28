import { fork, all } from "redux-saga/effects";
import labworkSaga from "./labworkSaga"
import queueSaga from "./queueSaga"
import eventsSaga from "./eventsSaga"

function* mainpageSaga() {
    yield all([
        fork(labworkSaga),
        fork(queueSaga),
        fork(eventsSaga)
    ])
}

export default mainpageSaga