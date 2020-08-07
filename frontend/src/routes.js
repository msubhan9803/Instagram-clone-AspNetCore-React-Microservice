import React from 'react';
import { Router, Switch, Route} from 'react-router-dom';
import History from './common/utils/History';
import Signup from './pages/SignUp';
import Login from './pages/Login';
import UserProfile from './pages/UserProfile';
import NotFound from './pages/NotFound';

function Routes() {
  return (
    <Router history={History}>
      <Switch>
        <Route exact path="/" component={Login}/>
        <Route path="/signup" component={Signup}/>
        <Route path="/userprofile" component={UserProfile}/>
        <Route path="*" component={NotFound}/>
      </Switch>
    </Router>
  );
}

export default Routes;