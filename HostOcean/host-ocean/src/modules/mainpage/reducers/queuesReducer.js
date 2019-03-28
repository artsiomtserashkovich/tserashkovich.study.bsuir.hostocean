import { handleActions } from "redux-actions";

import * as actions from "../actions/queuesActions";
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
            action.response.data.forEach(event => newState[event.queueId] = event.queue);
            return { ...newState }
        },

        [actions.takeQueueRequest]: (state, action) => {
            return setIsLoading(state,action);
        },  
        [actions.takeQueueFailed]: (state, action) => {
            return resetIsLoading(state,action);
        }, 
        [actions.takeQueueSuccess]: (state, action) => {
            return resetIsLoading(state,action);
        }, 

        [actions.leaveQueueRequest]: (state, action) => {
            return setIsLoading(state,action);
        },  
        [actions.leaveQueueFailed]: (state, action) => {
            return resetIsLoading(state,action);
        },
        [actions.leaveQueueSuccess]: (state, action) => {
            return resetIsLoading(state,action);
        }, 
        [actions.getQueueRequest]: (state, action) => {
            const { queueId } = action.payload;

            const newState = { ...state };
            newState[queueId] = { ...newState[queueId], isLoading: true }

            return newState;
        },
        [actions.getQueueSuccess]: (state, action) => {
            const newState = { ...state };
            const newQueue = action.response.data;

            newState[newQueue.id] = {
                ...state[newQueue.id],
                ...newQueue,
                isLoading: false
            };

            return { ...newState }
        },

        [actions.removeUserFromQueue]: (state, action) => {
            const { queueId, userId } = action.payload;

            const newState = { ...state };
            let newUserQueue = [...newState[queueId].userQueues];
            newUserQueue = newUserQueue.filter(uq => uq.userId !== userId)
            newState[queueId] = { ...newState[queueId], userQueues: newUserQueue }

            return newState;
        },
        [actions.addUserToQueue]: (state, action) => {
            const data = action.payload;
            const {queueId, userId} = data;

            const newState = { ...state };
            let newUserQueue = newState[queueId].userQueues.filter(uq => uq.userId !== userId);
            newUserQueue.push(data);

            newState[queueId] = { ...newState[queueId], userQueues: newUserQueue }

            return newState;
        },
    },
    initialState
);

function setIsLoading(state, action) {
    const { queueId } = action.payload;

    const newState = { ...state };
    newState[queueId] = { ...newState[queueId], isLoading: true }

    return newState;
}

function resetIsLoading(state,action) {
    const { queueId } = action.payload;

    const newState = { ...state };
    newState[queueId] = { ...newState[queueId], isLoading: false }

    return newState;
}