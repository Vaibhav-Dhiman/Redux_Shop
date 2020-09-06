import React from "react";
// components
import Navbar from "./components/Navbar";
import CartContainer from "./components/CartContainer";
// items
import cartItems from "./cart-items";
// redux stuff

// store -> single source of truth
// reducer -> function that used to update store
// dispatch -> send actions to the store

import {createStore} from 'redux';

// initial state value
const initialStore = {
  count: 78
};

// reducer here will dispatch action
function reducer(state,action) {
if(action.type === "DECREASE") {
    // state.count = state.count -1;
    return {count:state.count-1};
}
  return state;
}

/// store creating
const store = createStore(reducer,initialStore);
store.dispatch({type:"DECREASE"});
console.log(store.getState());

function App() {
  // cart setup
  return (
    <div>
      <Navbar cart={store.getState()} />
      <CartContainer cart={cartItems} />
    </div>
  );
}

export default App;
