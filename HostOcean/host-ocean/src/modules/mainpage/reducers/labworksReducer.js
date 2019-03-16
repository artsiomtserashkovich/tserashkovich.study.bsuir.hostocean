import { handleActions } from "redux-actions";

import * as actions from "../actions/labworksActions";

const initialState = {
};

export default handleActions(
    {
        [actions.getLabworksSuccess]: (state, action) => {
            const newState = { ...initialState };
            action.response.data.forEach(lab => newState[lab.id] = lab);

            return { ...newState }
        }
    },
    initialState
);