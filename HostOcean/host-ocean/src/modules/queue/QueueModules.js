import { withRouter, Switch, Route } from 'react-router';
import * as React from 'react';
import { QueueRoutes } from './QueueRoutes';

class QueueModuleContainer extends React.Component {
    render() {
        const { match } = this.props;
        return (
            <Switch>
                {
                    QueueRoutes.map((item) =>
                        (
                            <Route
                                path={`${match.path}/${item.path}`}
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
