import { takeLatest, all, put, select } from "redux-saga/effects";

import * as actions from "../actions";
import * as notificationsActions from "./../../notifications/actions";
import { RequestState } from "../../shared/enums";

function* createSwapRequest(action) {
    const data = action.response ? action.response.data : action.payload;
    const { creatorUser, receiverUser } = data;

    const { id } = yield select(state => state.user);

    if (creatorUser.id === id) {
        yield put(
            notificationsActions.displaySuccessNotification(
                "Swap request created"
            )
        );
    }

    if (receiverUser.id === id) {
        yield put(
            notificationsActions.displayInfoNotification(
                `You have a new request from ${creatorUser.userName}`
            )
        );
    }
}

function* updateRequest(action) {
    const data = action.response ? action.response.data : action.payload;

    const { state, creatorUser, receiverUser } = data;

    const { id } = yield select(state => state.user);

    if (state === RequestState.Accepted) {
        if (creatorUser.id === id) {
            yield put(
                notificationsActions.displayInfoNotification(
                    `User ${receiverUser.userName} accepted your request!`
                )
            );
        }
    }

    if (state === RequestState.Declined) {
        if (creatorUser.id === id) {
            yield put(
                notificationsActions.displayInfoNotification(
                    `User ${receiverUser.userName} declined your request!`
                )
            );
        }
    }

    if (state === RequestState.Expired) {
        if (receiverUser.id === id && action.response) {
            yield put(
                notificationsActions.displayWarningNotification(
                    `Request expired!`
                )
            );
        }
    }
}

function* requestsSaga() {
    yield all([
        takeLatest(
            [actions.createSwapRequestSuccess, actions.requestCreated],
            createSwapRequest
        ),
        takeLatest(
            [actions.updateRequestSuccess, actions.requestUpdated],
            updateRequest
        )
    ]);
}

export default requestsSaga;
