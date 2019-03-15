import { fork, all } from "redux-saga/effects";
import pingSaga from "./pingSaga"

function* accountSaga() {
    yield all([
        fork(pingSaga)
    ])
}

export default accountSaga