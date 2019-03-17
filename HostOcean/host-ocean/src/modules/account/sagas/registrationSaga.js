import { takeLatest, all, put } from 'redux-saga/effects'
import { updateSyncErrors } from 'redux-form'
import { push } from 'connected-react-router'
import * as _ from "lodash"

import * as actions from "../actions"
import * as sessionActions from "../../../state/actions/sessionActions"

function* registerSuccess(action) {
    const token = action.response.data;
    yield put(sessionActions.setToken(token))
    yield put(sessionActions.getUserRequest())
    yield put(push("/queue"))

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

function* registrationSaga() {
    yield all([
        takeLatest(actions.registerSuccess, registerSuccess),
        takeLatest(actions.registerFailed, registerFailed),
    ])
}

export default registrationSaga