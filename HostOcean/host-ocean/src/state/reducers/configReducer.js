import { handleActions } from "redux-actions";

import * as actions from "../actions/sessionActions";

const initialState = {
    apiHostName: undefined,
    signlarName: undefined
};

export default handleActions(
    {
        [actions.setConfig]: (state, action) => {
            return {...action.payload}
        }
    },
    initialState
);