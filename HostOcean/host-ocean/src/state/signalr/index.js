import * as queueActions from "./../../modules/mainpage/actions/queuesActions";
import * as requestsActions from "./../../modules/requests/actions";

export default (emit, connection) => {
    connection.on("onUserLeftQueue", data => {
        emit(queueActions.removeUserFromQueue(data));
    });

    connection.on("onUserTakeQueue", data => {
        emit(queueActions.addUserToQueue(data));
    });

    connection.on("onUserQueuesSwap", data => {
        emit(queueActions.swapUsers(data))
    });

    connection.on("onRequestCreated", data => {
        emit(requestsActions.requestCreated(data));
    });

    connection.on("onRequestUpdated", data => {
        emit(requestsActions.requestUpdated(data));
    });
};
