import { MainPage } from './MainPage';
import { AccountModule } from './Account/AccountModule';
import { QueueModule } from './Queue/QueueModules';
import { Statistics } from './Statistics/Statistics';
import { IRoute } from '../typings';

export const MainRoutes: IRoute[] =[
    {
        path: "",
        component: MainPage,
        exact: true,
    },
    {
        path: "accounts",
        component: AccountModule,
        exact: false,
    },
    {
        path: "queue",
        component: QueueModule,
        exact: false,
    },
    {
        path: "statistics",
        component: Statistics,
        exact: false,
    }
];
