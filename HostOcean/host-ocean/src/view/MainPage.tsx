import { WithStyles, Typography, withStyles } from '@material-ui/core';
import * as React from 'react';
import { accountStab } from '../Core/AccountStab';
import { AboutAccountView } from '../Components/MainPage/AboutAccountView';

const styles ={
    root: {
        flexGrow: 1,
      },
};

interface Props extends WithStyles<typeof styles>{

}

class MainPageView extends React.Component<Props> {
    public render(){
        const accountAbout = accountStab;
        return(
            <div>                
               <Typography  align={"left"} variant={"h4"} >
                    Лабораторные работы <br/>на завтра
                </Typography>
                <AboutAccountView account={accountAbout} /> 
            </div>
        );
    }
}

export const MainPage = withStyles(styles)(MainPageView)