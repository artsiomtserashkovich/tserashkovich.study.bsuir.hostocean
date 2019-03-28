import { handleActions } from "redux-actions";

import * as actions from "../actions/eventsActions";
import * as stateActions from "../../../state/actions/sessionActions";

const initialState = {
};

export default handleActions(
    {
        [stateActions.resetState]: (state,action) => {
            return { ...initialState }
        },
        [actions.getEventsSuccess]: (state, action) => {
            const newState = { ...initialState };
            action.response.data.forEach(event => newState[event.id] = event);

            return { ...newState }
        }
    },
    initialState
);