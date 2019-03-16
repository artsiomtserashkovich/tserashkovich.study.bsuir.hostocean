import { fork, all } from "redux-saga/effects";
import labworkSaga from "./labworkSaga"

function* mainpageSaga() {
    yield all([
        fork(labworkSaga),
    ])
}

export default mainpageSaga