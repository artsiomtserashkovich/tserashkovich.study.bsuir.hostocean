import { handleActions } from "redux-actions";
import * as statisticsActions from "../actions/statisticActions";

const initialState = {
    isLoaded: false,
};

export default handleActions(
    {
        [statisticsActions.getStatisticSuccess]: (state, { response: { data } }) => {           
            return { ...data, isLoaded: true };
        }
    },
    initialState
);