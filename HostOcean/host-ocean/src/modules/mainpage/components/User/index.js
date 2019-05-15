import React from "react";
import {
    Typography,
    Avatar,
    withStyles,
    Button,
    IconButton
} from "@material-ui/core";

import styles from "./styles";

function stringToColor(string) {
    let hash = 0;

    for (let i = 0; i < string.length; i += 1) {
        hash = string.charCodeAt(i) + ((hash << 5) - hash);
    }

    let colour = "#";

    for (let i = 0; i < 3; i += 1) {
        const value = (hash >> (i * 8)) & 0xff;
        colour += `00${value.toString(16)}`.substr(-2);
    }

    return colour;
}

const User = ({
    classes,
    order,
    user,
    createSwapRequest,
    declineSwapRequest,
    acceptSwapRequest,
    isRequestAlreadySended,
    isPedingRequestFromUser,
    isUser,
    isRequestLoading,
    isUserInQueue
}) => {
    const accountLetter = user.userName.substr(0, 1).toUpperCase();

    return (
        <div className={classes.userInfo}>
            <Typography variant="subtitle1">{order}.</Typography>
            <Avatar
                alt="Remy Sharp"
                className={classes.userAvatar}
                style={{
                    backgroundColor: stringToColor(user.userName)
                }}
            >
                {accountLetter}
            </Avatar>
            <Typography variant="subtitle1">{user.userName}</Typography>
            <div className={classes.controls}>
                {!isUser && !isPedingRequestFromUser && isUserInQueue && (
                    <IconButton
                        disabled={isRequestAlreadySended || isRequestLoading}
                        className={classes.button}
                        onClick={createSwapRequest(user.id)}
                        color="primary"
                    >
                        <i
                            style={{ fontSize: 20, padding: 3 }}
                            className="material-icons"
                        >
                            {isRequestAlreadySended ? "whatshot" : "swap_vert"}
                        </i>
                    </IconButton>
                )}
                {!isUser && isUserInQueue && isPedingRequestFromUser && (
                    <React.Fragment>
                        <IconButton
                            className={classes.button}
                            disabled={isRequestLoading}
                            onClick={declineSwapRequest}
                            color="secondary"
                        >
                            <i
                                style={{ fontSize: 20, padding: 3 }}
                                className="material-icons"
                            >
                                clear
                            </i>
                        </IconButton>
                        <IconButton
                            className={classes.button}
                            disabled={isRequestLoading}
                            onClick={acceptSwapRequest}
                            color="primary"
                        >
                            <i
                                style={{ fontSize: 20, padding: 3 }}
                                className="material-icons"
                            >
                                done
                            </i>
                        </IconButton>
                    </React.Fragment>
                )}
            </div>
        </div>
    );
};

export default withStyles(styles)(User);
