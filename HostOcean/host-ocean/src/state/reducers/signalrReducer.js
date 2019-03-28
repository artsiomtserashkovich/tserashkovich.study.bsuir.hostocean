import { handleActions } from "redux-actions";

import * as actions from "../actions/signalrActions";

const initialState = {
    connection: undefined,
    isEstablished: false
};

export default handleActions(
    {
        [actions.createConnectionSuccess]: (state, action) => {
            return { ...state, connection: action.payload, isEstablished: true }
        },
        [actions.createConnectionFailed]: (state, action) => {
            return { ...state, connection: undefined, isEstablished: false }
        },

        [actions.terminateConnectionSuccess]: (state, action) => {
            return { ...initialState }
        }
    },
    initialState
);