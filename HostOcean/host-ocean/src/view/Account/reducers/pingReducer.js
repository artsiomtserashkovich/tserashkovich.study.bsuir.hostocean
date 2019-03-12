import { handleActions, combineActions } from "redux-actions";

import * as actions from "../actions";

const initialState = {
};

export default handleActions(
  {
    [actions.getPingSuccess]: (state, { response: { data } }) => {
      return ({
        ...state,
        ...data
      })
    },
  },
  initialState
);