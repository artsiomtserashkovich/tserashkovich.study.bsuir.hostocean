import { takeLatest, all, put } from 'redux-saga/effects'
import { updateSyncErrors } from 'redux-form'
import { push } from 'connected-react-router'
import * as _ from "lodash"

import * as actions from "../actions"
import * as sessionActions from "../../../state/actions/sessionActions"

function* authSuccess(action) {
    const token = action.response.data;
    yield put(sessionActions.setToken(token))
    yield put(sessionActions.getUserRequest())

}

function* enterSite(action) {
    yield put(push("/"))
}

function* registerFailed(action) {
    const errors = action.response.data.errors;
    const errorFields = [];

    if (action.response.data && action.response.data.errors) {
        for (var key in action.response.data.errors) {
            errorFields.push({ field: _.toLower(key), message: errors[key] })

            yield put(updateSyncErrors('register', {
                [_.toLower(key)]: errors[key]
            }));
        }
    }
}

function* loginFailed(action) {
    yield put(updateSyncErrors('login', {
        username: "Incorrect username or password!"
    }));
}

function* registrationSaga() {
    yield all([
        takeLatest([actions.registerSuccess, actions.loginSuccess], authSuccess),
        takeLatest(sessionActions.getUserSuccess, enterSite),
        takeLatest(actions.registerFailed, registerFailed),
        takeLatest(actions.loginFailed, loginFailed),
    ])
}

export default registrationSaga