import { takeLatest, all, put } from 'redux-saga/effects'

import * as queuesActions from "../actions/queuesActions"
import * as notificationsActions from "./../../notifications/actions"

function* takeQueueSuccess() {
    yield put(notificationsActions.displaySuccessNotification('Вы заняли очередь.'));
}

function* takeQueueFailed() {
    yield put(notificationsActions.displayErrorNotification('Неудалось занять очередь.'));
}

function* leaveQueueSuccess() {
    yield put(notificationsActions.displayErrorNotification('Вы покинули очередь.'));
}

function* leaveQueueFailed() {
    yield put(notificationsActions.displayErrorNotification('Не удалось покинуть очередь.'));
}


function* queueSaga() {
    yield all([
        takeLatest([queuesActions.takeQueueSuccess], takeQueueSuccess),
        takeLatest([queuesActions.takeQueueFailed], takeQueueFailed),
        takeLatest([queuesActions.leaveQueueSuccess], leaveQueueSuccess),
        takeLatest([queuesActions.leaveQueueFailed], leaveQueueFailed),
    ])
}

export default queueSaga