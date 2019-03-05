import React from "react";
import { Switch, Route } from "react-router";
import { MainPage } from "./MainPage";
import { QueueRoute } from "./queue/QueueRoute";

export class MainRoute extends React.Component {
    public render() {
        return(
            <Switch>
                <Route exact path="/" component={MainPage} />
                <Route path="/queue" component={QueueRoute}/>
            </Switch>
        );
    }
};