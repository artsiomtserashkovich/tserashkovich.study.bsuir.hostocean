import { handleActions } from "redux-actions";

import * as sessionActions from "../actions/sessionActions";
import * as userActions from "../../modules/account/actions/index";

const initialState = {
};

export default handleActions(
    {
        [sessionActions.getUserSuccess]: (state, action) => {
            return {...action.response.data}
        },
        [userActions.updateUserSuccess]: (state, action) => {
            return {...action.response.data}
        },  
        [sessionActions.removeUser]: (state, action) => {
            return {...initialState}
        },
    },
    initialState
);