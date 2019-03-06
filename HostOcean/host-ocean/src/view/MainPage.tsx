import { WithStyles, Typography, withStyles } from '@material-ui/core';
import * as React from 'react';

const styles ={
    root: {
        flexGrow: 1,
      },
};

interface Props extends WithStyles<typeof styles>{

}

class MainPageView extends React.Component<Props> {
    public render(){
        return(
            <Typography align={"left"} variant={"h2"} >
                Its Main Page
            </Typography>
        );
    }
}

export const MainPage = withStyles(styles)(MainPageView)