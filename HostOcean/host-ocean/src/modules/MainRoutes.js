import { MainPage } from './MainPage';
import { AccountModule } from './account/AccountModule';
import { QueueModule } from './queue/QueueModules';
import { Statistics } from './statistics/Statistics';

export const MainRoutes = [
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
