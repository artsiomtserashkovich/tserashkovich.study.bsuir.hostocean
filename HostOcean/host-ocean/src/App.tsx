import React, { Component } from 'react';
import { NavBar } from './components/navbar';
import { MainRoute } from './view/MainRoute';
import { BrowserRouter } from 'react-router-dom';

class App extends Component {
  render() {
    return (
      <BrowserRouter>
        <div>
          <NavBar />
          <MainRoute />
        </div>        
      </BrowserRouter>
    );
  }
}

export default App;
