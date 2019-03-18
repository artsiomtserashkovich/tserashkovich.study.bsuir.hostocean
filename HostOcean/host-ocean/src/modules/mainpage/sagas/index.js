import { fork, all } from "redux-saga/effects";
import labworkSaga from "./labworkSaga"
import queueSaga from "./queueSaga"

function* mainpageSaga() {
    yield all([
        fork(labworkSaga),
        fork(queueSaga)
    ])
}

export default mainpageSaga