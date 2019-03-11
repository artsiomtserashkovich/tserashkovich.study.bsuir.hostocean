import { RouteComponentProps, withRouter, Switch, Route } from 'react-router';
import * as React from 'react';
import { QueueRoutes } from './QueueRoutes';

interface Props extends RouteComponentProps{
}

class QueueModuleContainer extends React.Component<Props> {
    public render() {
        const { match } = this.props;
        return(
            <Switch>
                {
                    QueueRoutes.map((item) =>
                    (
                        <Route
                            path={ `${match.url}/${item.path}` }
                            component={item.component}
                            exact={item.exact}
                        />
                    ))
                }
            </Switch>
        );
    }
};

export const QueueModule = withRouter(QueueModuleContainer);
