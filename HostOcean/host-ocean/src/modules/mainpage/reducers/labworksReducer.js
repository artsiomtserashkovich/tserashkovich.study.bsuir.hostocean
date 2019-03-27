import { handleActions } from "redux-actions";

import * as eventsActions from "../actions/eventsActions";
import * as stateActions from "../../../state/actions/sessionActions";

const initialState = {
};

export default handleActions(
    {
        [stateActions.resetState]: (state,action) => {
            return { ...initialState }
        },
        [eventsActions.getEventsSuccess]: (state, action) => {
            const newState = { ...initialState };
            action.response.data.forEach(event => newState[event.laboratoryWorkId] = event.laboratoryWork);
            return { ...newState }
        }
    },
    initialState
);