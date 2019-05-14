import React from "react";
import PropTypes from "prop-types";
import {
    Typography,
    Divider,
    withStyles,
    Paper,
    Button
} from "@material-ui/core";

import styles from "./styles";

const Request = ({
    classes,
    createdOn,
    type,
    state,
    receiverUser,
    creatorUser,
    queue,
    queueId,
    isRequestOwner,
    acceptRequest,
    declineRequest,
    expireRequest
}) => {
    const dateString = new Date(createdOn).toLocaleTimeString("en-EN", {
        hour: "numeric",
        minute: "numeric"
    });
    return (
        <div className={classes.root}>
            <Paper className={classes.main}>
                <div className={classes.date}>
                    <Typography variant="subtitle2">{dateString}</Typography>
                </div>
                <div className={classes.infoContainer}>
                    <div>
                        <Typography variant="subtitle2">
                            {isRequestOwner
                                ? `You offered user ${
                                      receiverUser.userName
                                  } to swap places in queue ${queueId}`
                                : `User ${
                                      creatorUser.userName
                                  } offered you to swap places in queue ${queueId}`}
                        </Typography>
                    </div>
                </div>
            </Paper>
            <div className={classes.controls}>
                {!isRequestOwner && state === 0 && (
                    <React.Fragment>
                        <Button
                            onClick={acceptRequest}
                            className={classes.button}
                            variant="contained"
                            color="primary"
                        >
                            <i className="material-icons">done</i>
                        </Button>
                        <Button
                            onClick={declineRequest}
                            className={classes.button}
                            variant="contained"
                            color="secondary"
                        >
                            <i className="material-icons">delete</i>
                        </Button>
                    </React.Fragment>
                )}
                {isRequestOwner && state === 0 && (
                    <React.Fragment>
                        <Button
                            onClick={expireRequest}
                            className={classes.button}
                            variant="contained"
                            color="secondary"
                        >
                            <i className="material-icons">delete</i>
                        </Button>
                    </React.Fragment>
                )}
            </div>
            <Paper className={classes.status}>
                <Typography variant="subtitle2">Status</Typography>
                <Divider />
                <Typography variant="subtitle2">{state}</Typography>
            </Paper>
        </div>
    );
};

Request.propTypes = {
    classes: PropTypes.object.isRequired
};

export default withStyles(styles)(Request);
