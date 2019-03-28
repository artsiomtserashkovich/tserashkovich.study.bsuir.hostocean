import { combineReducers } from "redux";

import labworks from "./labworksReducer";
import queues from "./queuesReducer";
import events from "./eventsReducer";

export default combineReducers({
    labworks,
    events,
    queues
})
