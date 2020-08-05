import React from 'react';
import { Router, Switch, Route} from 'react-router-dom';
import Signup from './pages/SignUp';
import Login from './pages/Login';
import History from './common/utils/History';

function App() {
  return (
    <Router history={History}>
      <Switch>
        <Route path="/signup" component={Signup}/>
        <Route path="/login" component={Login}/>
      </Switch>
    </Router>
  );
}

export default App;
