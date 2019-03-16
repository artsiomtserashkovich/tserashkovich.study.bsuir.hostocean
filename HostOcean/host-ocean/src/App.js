import * as React from 'react';
import { persistStore } from "redux-persist";
import { PersistGate } from "redux-persist/integration/react";
import { Provider, ReactReduxContext } from 'react-redux';
import { ConnectedRouter } from 'connected-react-router'

import { MainModule } from './modules/MainModule';

import * as actions from "./state/actions/sessionActions"

import config from "./config/index"
import NavBar from './modules/navbar';

import createStore, { history } from './state';

const store = createStore();
const persistor = persistStore(store);

class App extends React.Component {
  componentWillMount() {
    store.dispatch(actions.setConfig(config))
  }

  render() {
    return (
      <Provider store={store} context={ReactReduxContext}>
        <PersistGate loading={null} persistor={persistor}>
          <ConnectedRouter history={history} context={ReactReduxContext}>
            <div>
              <NavBar />
              <MainModule />
            </div>
          </ConnectedRouter>
        </PersistGate>
      </Provider >
    );
  }
}

export default App;
