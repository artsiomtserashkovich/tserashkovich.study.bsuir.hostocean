import React from "react";
import { Switch, Route } from "react-router";
import { QueueListPage } from "./QueueList";

export class QueueRoute extends React.Component {
    public render() {
        return(
            <Switch>
                <Route exact path="/queue" component={QueueListPage} />
            </Switch>
        );
    }
};