import { fork, all } from "redux-saga/effects";
import watchRequest from "./watchRequest"
import signalrConnection from "./signalrConnection"
import tokenExpirationSaga from "./tokenExpirationSaga"
import accountSaga from "./../../modules/account/sagas/index"
import mainpageSaga from "./../../modules/mainpage/sagas/index"

function* rootSaga() {
    yield all([
        fork(watchRequest),
        fork(signalrConnection),
        fork(tokenExpirationSaga),
        fork(accountSaga),
        fork(mainpageSaga)
    ])
}

export default rootSaga