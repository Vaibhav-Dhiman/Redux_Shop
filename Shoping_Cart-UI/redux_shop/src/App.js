import React from "react";
// components
import Navbar from "./components/Navbar";
import CartContainer from "./components/CartContainer";
// items
import cartItems from "./cart-items";
import {INCREASE,DECREASE,REMOVE} from "./components/Actions";
import reducer from "./components/Reducers";

// redux stuff

// store -> single source of truth
// reducer -> function that used to update store
// dispatch -> send actions to the store

import {createStore} from 'redux';

// initial state value
const initialStore = {
  count: 0
};

/// store creating
const store = createStore(reducer,initialStore);
store.dispatch({type: DECREASE});
store.dispatch({type: INCREASE});
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
