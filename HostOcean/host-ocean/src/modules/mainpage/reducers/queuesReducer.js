import { handleActions } from "redux-actions";

import * as actions from "../actions/queuesActions";

const initialState = {
};

export default handleActions(
    {
        [actions.getQueueRequest]: (state, action) => {
            const { queueId } = action.payload;

            const newState = { ...initialState };
            newState[queueId] = { ...newState[queueId], isLoading: true }

            return newState;
        },
        [actions.getQueueSuccess]: (state, action) => {
            const newState = { ...initialState };
            const newQueue = action.response.data;

            newState[newQueue.id] = {
                ...state[newQueue.id],
                ...newQueue,
                isLoading: false
            };

            return { ...newState }
        }
    },
    initialState
);