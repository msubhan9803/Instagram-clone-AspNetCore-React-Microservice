import React from 'react';
import { BrowserRouter, Switch, Route} from 'react-router-dom';
import Signup from './pages/SignUp/component/SignUp';
import Login from './pages/Login/components/Login';

function App() {
  return (
    <BrowserRouter>
      <Switch>
        <Route path="/signup" component={Signup}/>
        <Route path="/login" component={Login}/>
      </Switch>
    </BrowserRouter>
  );
}

export default App;
