import React from 'react';
import { Router, Switch, Route} from 'react-router-dom';
import History from './common/utils/History';
import Signup from './pages/SignUp';
import Login from './pages/Login';
import Newsfeed from './pages/Newsfeed';
import UserProfile from './pages/UserProfile';
import NotFound from './pages/NotFound';
import PostModal from './common/components/PostModal';
import Edit from './common/components/Edit';
import Create from './pages/Create';

// Background & Location stuff shows how to render two different screens
// (or the same screen in a different context) at the same URL,
// depending on how you got there.

function Routes() {
  let location = History.location;

  // This piece of state is set when one of the
  // gallery links is clicked. The `background` state
  // is the location that we were at when one of
  // the gallery links was clicked. If it's there,
  // use it as the location for the <Switch> so
  // we show the gallery in the background, behind
  // the modal.
  let background = location.state && location.state.background;

  return (
    <Router location={background || location} history={History} basename={"/projects/instagram"}>
      <Switch>
        <Route exact path="/projects/instagram/" component={Login}/>
        <Route path="/projects/instagram/signup" component={Signup}/>
        <Route path="/projects/instagram/newsfeed" component={Newsfeed} />
        <Route path={["/projects/instagram/userprofile/:username", "/projects/instagram/post/:id/:index"]} children={<UserProfile history={History}/>} />
        {/* Add route to get post by id without Modal */}
        <Route path="/projects/instagram/accounts/edit" component={Edit}/>
        <Route path="/projects/instagram/create" component={Create}/>
        <Route path="*" component={NotFound}/>
      </Switch>

      {/* Show the modal when a background page is set */}
      {<Route path="/projects/instagram/post/:id/:index" children={<PostModal />} />}
    </Router>
  );
}

export default Routes;