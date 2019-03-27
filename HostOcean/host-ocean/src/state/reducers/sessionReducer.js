import { handleActions } from "redux-actions";

import * as actions from "../actions/sessionActions";

const initialState = {
    accessToken: undefined,
    refreshToken: undefined,
    expires: undefined,
    role: undefined
};

export default handleActions(
    {
        [actions.setToken]: (state, action) => {
            return { ...action.payload }
        },
        [actions.removeToken]: (state, action) => {
            return { ...initialState }
        },
        [actions.refreshTokenSuccess]: (state, action) => {
            return { ...initialState, ...action.response.data }
        },
    },
    initialState
);