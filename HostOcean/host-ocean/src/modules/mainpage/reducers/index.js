import { combineReducers } from "redux";

import labworks from "./labworksReducer";
import queues from "./queuesReducer";

export default combineReducers({
    labworks,
    queues
})
