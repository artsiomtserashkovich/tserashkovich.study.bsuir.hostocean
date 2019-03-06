import { Switch, Route, withRouter, RouteComponentProps } from "react-router";
import { MainRoutes } from './MainRoutes';
import * as React from 'react';
import urljoin from "url-join"

interface Props extends RouteComponentProps{
}

class MainModuleContainer extends React.Component<Props> {
    public render() {
        const { match } = this.props;
        return(
            <Switch>
                {
                    MainRoutes.map((item) =>
                    (
                        <Route
                            path={ urljoin(match.url,item.path) }
                            component={item.component}
                            exact={item.exact}
                        />
                    ))
                }
            </Switch>
        );
    }
};

export const MainModule =  withRouter(MainModuleContainer);