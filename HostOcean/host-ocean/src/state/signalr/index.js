import * as queueActions from "./../../modules/mainpage/actions/queuesActions"

export default (emit, connection) => {
    connection.on('onUserLeftQueue', data => {
        emit(queueActions.removeUserFromQueue(data))
    });

    connection.on('onUserTakeQueue', data => {
        emit(queueActions.addUserToQueue(data))
    });
}