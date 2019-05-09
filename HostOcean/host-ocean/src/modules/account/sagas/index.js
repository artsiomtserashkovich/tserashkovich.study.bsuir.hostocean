import { fork, all } from "redux-saga/effects";
import pingSaga from "./pingSaga";
import registrationSaga from "./registrationSaga";
import userInfoSaga from "./userInfoSaga";

function* accountSaga() {
    yield all([
        fork(pingSaga),
        fork(registrationSaga),
        fork(userInfoSaga)
    ])
}

export default accountSaga