import { put, delay, select } from "redux-saga/effects";

import * as actions from "./../actions/sessionActions";

export default function* tokenExpirationSaga() {
    try {
        while (true) {
            yield delay(1000);

            const { accessToken, refreshToken } = yield select(state => state.session);
            if (accessToken && refreshToken) {
                yield put(actions.refreshTokenRequest({ refreshToken }))
                yield delay(60000);
            }
        }
    } catch (error) {
        console.log(error);
    }
}