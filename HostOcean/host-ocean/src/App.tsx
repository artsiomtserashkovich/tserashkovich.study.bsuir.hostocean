import { NavBar } from './components/navbar';
import { BrowserRouter } from 'react-router-dom';
import * as React from 'react';
import { MainModule } from './View/MainModule';

class App extends React.Component {
  render() {
    return (
      <BrowserRouter>
        <div>
          <NavBar />
          <MainModule />
        </div>        
      </BrowserRouter>
    );
  }
}

export default App;
