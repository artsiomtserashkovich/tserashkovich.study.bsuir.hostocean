import { handleActions } from "redux-actions";

import * as actions from "../actions";

const initialState = {
    colorScheme: "light"
};

export default handleActions(
    {
        [actions.changeColorScheme]: (state, action) => {
            return { ...state, colorScheme: action.payload };
        }
    },
    initialState
);
