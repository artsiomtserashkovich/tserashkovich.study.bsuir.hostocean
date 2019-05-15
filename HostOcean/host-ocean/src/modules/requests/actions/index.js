import { createAction } from "redux-actions";

export const requestCreated = createAction(
    "REQUEST_CREATED"
);

export const requestUpdated = createAction(
    "REQUEST_UPDATED"
);

export const createSwapRequestRequest = createAction(
    "CREATE_SWAP_REQUEST_REQUEST"
);
export const createSwapRequestFailed = createAction(
    "CREATE_SWAP_REQUEST_FAILED"
);
export const createSwapRequestSuccess = createAction(
    "CREATE_SWAP_REQUEST_SUCCESS"
);

export const getRequestsRequest = createAction("GET_REQUESTS_REQUEST");
export const getRequestsFailed = createAction("GET_REQUESTS_FAILED");
export const getRequestsSuccess = createAction("GET_REQUESTS_SUCCESS");

export const updateRequestRequest = createAction("UPDATE_REQUEST_REQUEST");
export const updateRequestFailed = createAction("UPDATE_REQUEST_FAILED");
export const updateRequestSuccess = createAction("UPDATE_REQUEST_SUCCESS");
