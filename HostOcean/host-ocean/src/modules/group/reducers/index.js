import { handleActions } from "redux-actions";

import * as actions from "../actions";

const initialState = {};

export default handleActions(
    {
        [actions.getGroupRequest]: (state, { response: { data } }) => {
            return ({
                ...data
            })
        },
    },
    initialState
);