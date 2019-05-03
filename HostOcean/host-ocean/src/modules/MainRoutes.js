import MainPageContainer from './mainpage/containers/MainPageContainer';
import { AccountModule } from './account/AccountModule';
import { QueueModule } from './queue/QueueModules';
import { StatisticsContainer } from './statistics/containers/StatisticsContainer';

export const MainRoutes = [
    {
        path: "",
        component: MainPageContainer,
        requireAuth: true,
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
        component: StatisticsContainer,
        requireAuth: true,
        exact: false,
    }
];
