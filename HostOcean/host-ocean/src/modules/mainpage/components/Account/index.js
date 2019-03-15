import React from "react";
import { Typography } from "@material-ui/core";

const Account = ({ account }) => {
    return (
        <div>
            <Typography align={"right"} variant={"h5"} >
                {account.name}
            </Typography>
            <Typography align={"right"} variant={"h5"} >
                {account.surname}
            </Typography>
            <Typography align={"right"} variant={"h5"} >
                {account.groupId}
            </Typography>
        </div>
    );
}

export default Account;