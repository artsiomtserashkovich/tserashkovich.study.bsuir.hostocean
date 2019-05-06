import { handleActions } from "redux-actions";
import * as rawActions from "./../actions/index"

const initialState = {
    isEditing: false
};

export const loginFormReducer = handleActions(
    {
        [rawActions.editUserInfo]: (state, action) => {
            return {...state, isEditing: true}
        },
        [rawActions.updateUserSuccess]: (state, action) => {
            return {...state, isEditing: false}
        }
    },
    initialState
);

export default loginFormReducer;