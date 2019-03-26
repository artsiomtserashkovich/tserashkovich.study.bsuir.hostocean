import { handleActions } from "redux-actions";

import * as actions from "../actions/eventsActions";

const initialState = {
};

export default handleActions(
    {
        [actions.getEventsSuccess]: (state, action) => {
            const newState = { ...initialState };
            action.response.data.forEach(event => newState[event.id] = event);

            return { ...newState }
        }
    },
    initialState
);