import { handleActions } from "redux-actions";

import * as actions from "../actions/index";

const initialState = {};

export default handleActions(
    {
        [actions.getRequestsSuccess]: (state, action) => {
            const newState = { ...initialState };
            action.response.data.forEach(
                request => (newState[request.id] = request)
            );

            return { ...newState };
        },
        [actions.requestUpdated]: (state, action) => {
            const data = action.payload;

            const { id } = data;

            let newRequest = { ...state[id], ...data };
            const newState = { ...state, [id]: newRequest };

            return newState;
        },
        [actions.updateRequestSuccess]: (state, action) => {
            const data = action.response.data;

            const { id } = data;

            let newRequest = { ...state[id], ...data };
            const newState = { ...state, [id]: newRequest };

            return newState;
        },
        [actions.requestCreated]: (state, action) => {
            const data = action.payload;

            const { id } = data;

            const newState = { ...state, [id]: data };

            return newState;
        },
        [actions.createSwapRequestSuccess]: (state, action) => {
            const data = action.response.data;

            const { id } = data;

            const newState = { ...state, [id]: data };

            return newState;
        }
    },
    initialState
);
