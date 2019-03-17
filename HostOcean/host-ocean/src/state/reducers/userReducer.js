import { handleActions } from "redux-actions";

import * as actions from "../actions/sessionActions";

const initialState = {
};

export default handleActions(
    {
        [actions.getUserSuccess]: (state, action) => {
            return {...action.response.data}
        },
    },
    initialState
);