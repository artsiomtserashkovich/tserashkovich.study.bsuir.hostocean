import { eventChannel  } from 'redux-saga';
import { put, select, fork, call, take, delay } from 'redux-saga/effects'
import * as sessionActions from "./../actions/sessionActions"
import * as signalR from "@aspnet/signalr";
import registerSignalREvents from "./../signalr";

function* registerActions(connection) {
    return eventChannel(emit => {
        registerSignalREvents(emit,connection)

        return () => { };
    });
}

function* handle(connection) {
    const channel = yield call(registerActions, connection);
    while (true) {
        let action = yield take(channel);
        yield put(action);
    }
}

function* tryToConnect(action) {
    const { signlarName } = yield select(state => state.config)
    const { accessToken } = yield select(state => state.session)
    const { isEstablished } = yield select(state => state.signalr)

    if (!signlarName || !accessToken || isEstablished) {
        return;
    }

    try {
        var connection = new signalR.HubConnectionBuilder()
            .withUrl(signlarName, { accessTokenFactory: () => accessToken })
            .configureLogging(signalR.LogLevel.Information)
            .build();

        yield fork(handle, connection)

        connection.start();

        yield put(sessionActions.createConnectionSuccess(connection))
    }
    catch {
        yield put(sessionActions.createConnectionFailed(connection))
    }
}

export default function* signalrConnection() {
    yield delay(1000);
    while (true) {
        yield fork(tryToConnect);
        yield delay(5000);
    }
}