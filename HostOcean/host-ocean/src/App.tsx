import { NavBar } from './components/navbar';
import { BrowserRouter } from 'react-router-dom';
import * as React from 'react';
import { persistStore } from "redux-persist";
import { MainModule } from './view/MainModule';
import { PersistGate } from "redux-persist/integration/react";
import { Provider } from 'react-redux';

import createStore from './state';

class App extends React.Component {
  render() {
    const store = createStore();
    const persistor = persistStore(store);

    return (
      <Provider store={store}>
        <PersistGate loading={null} persistor={persistor}>
          <BrowserRouter>
            <div>
              <NavBar />
              <MainModule />
            </div>
          </BrowserRouter>
        </PersistGate>
      </Provider>
    );
  }
}

export default App;
