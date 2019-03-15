import storage from "redux-persist/lib/storage";
import { createStore, applyMiddleware, compose } from "redux";
import createSagaMiddleware from "redux-saga";
import { persistReducer } from "redux-persist";

import rootReducer from './reducers'
import rootSaga from './sagas'

export default () => {
    let store;

    const persistConfig = {
        key: "root",
        storage,
        whitelist: ["session"]
    };

    const composeEnhancer = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

    const sagaMiddleware = createSagaMiddleware();
    store = createStore(
        persistReducer(persistConfig, rootReducer),
        composeEnhancer(applyMiddleware(sagaMiddleware))
    );

    sagaMiddleware.run(rootSaga);

    return store
}