import { takeLatest, all, put } from "redux-saga/effects";

import * as actions from "../actions";
import * as notificationActions from "../../notifications/actions";

function* updateUserSuccess(action) {
    yield put(notificationActions.displaySuccessNotification("User information updated successfully"))
}

function* updateUserFailed(action) {
    yield put(notificationActions.displayErrorNotification("Failed to update user information"))
}

function* changePasswordSuccess(action) {
    yield put(notificationActions.displaySuccessNotification("Users password changed successfully"))
}

function* changePasswordFailed(action) {
    yield put(notificationActions.displayErrorNotification("Failed to change users password"))
}

function* userInfoSaga() {
    yield all([
        takeLatest(actions.updateUserSuccess, updateUserSuccess),
        takeLatest(actions.updateUserFailed, updateUserFailed),
        takeLatest(actions.changePasswordSuccess, changePasswordSuccess),
        takeLatest(actions.changePasswordFailed, changePasswordFailed),
    ])
}

export default userInfoSaga