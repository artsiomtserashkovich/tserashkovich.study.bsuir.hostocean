import * as React from "react";
import { persistStore } from "redux-persist";
import { PersistGate } from "redux-persist/integration/react";
import { Provider, ReactReduxContext } from "react-redux";
import { SnackbarProvider } from "notistack";

import * as actions from "./state/actions/sessionActions";
import DatePickerProvider from "./modules/shared/providers/MUIDatePickerProvider/index";
import config from "./config/index";

import createStore from "./state";
import UI from "./UI";

const store = createStore();
const persistor = persistStore(store);

class App extends React.Component {
    componentWillMount() {
        store.dispatch(actions.setConfig(config));
    }

    render() {
        return (
            <Provider store={store} context={ReactReduxContext}>
                <PersistGate loading={null} persistor={persistor}>
                  <DatePickerProvider locale="en">
                    <SnackbarProvider>
                        <UI />
                    </SnackbarProvider>
                  </DatePickerProvider>
                </PersistGate>
            </Provider>
        );
    }
}

export default App;
