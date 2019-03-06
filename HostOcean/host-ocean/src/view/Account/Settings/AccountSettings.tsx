import * as React from 'react';
import { Typography } from '@material-ui/core';

class AccountSettingsContainer extends React.Component{
    public render(){
        return(
            <Typography align={"left"} variant={"h2"} >
                Its Account Settings
            </Typography>
        );
    }
}

export const AccountSettings =  AccountSettingsContainer;
