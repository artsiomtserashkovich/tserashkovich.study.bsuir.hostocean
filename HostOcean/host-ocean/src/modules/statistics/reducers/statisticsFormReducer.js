import { handleActions } from "redux-actions";

const initialState = {
    startPeriod: new Date(),
    endPeriod: new Date(),
};

export const statisticsFormReducer = handleActions(
    {},
    initialState
);

export default statisticsFormReducer;
