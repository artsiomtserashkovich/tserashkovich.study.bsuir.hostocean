import { fork, all } from "redux-saga/effects";
import pingSaga from "./pingSaga"
import registrationSaga from "./registrationSaga"

function* accountSaga() {
    yield all([
        fork(pingSaga),
        fork(registrationSaga)
    ])
}

export default accountSaga