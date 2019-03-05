import React from "react";
import withStyles, { WithStyles } from "@material-ui/core/styles"
import { Typography } from "@material-ui/core";

const styles ={
    root: {
        flexGrow: 1,
      },
};

interface Props extends WithStyles{

}

class QueueListPageContainer extends React.Component<Props> {
    public render(){
        return(
            <Typography align={"left"} variant={"h2"}>
                Its Queue Page
            </Typography>
        );
    }
}

export const QueueListPage = (QueueListPageContainer)