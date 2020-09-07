import React from "react";
// components
import Navbar from "./components/Navbar";
import CartContainer from "./components/CartContainer";
// items
import cartItems from "./cart-items";
import reducer from "./components/Reducers";
import {Provider} from "react-redux";
// redux stuff

// store -> single source of truth
// reducer -> function that used to update store
// dispatch -> send actions to the store

import {createStore} from 'redux';

// initial state value
const initialStore = {
  cart:cartItems,
  total:0,
  amount:5
};

/// store creating
const store = createStore(reducer,initialStore);

function App() {
  // cart setup
  return (
    <Provider store={store}>
      <Navbar />
      <CartContainer cart={cartItems} />
    </Provider>
  );
}

export default App;
