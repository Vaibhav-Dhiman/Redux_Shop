import {DECREASE,INCREASE,CLEAR_CART,REMOVE} from "./Actions";

// reducer here will dispatch action
function reducer(state,action) {
  if(action.type === CLEAR_CART) {
    return {...state,cart:[]};
  }

  if(action.type === DECREASE) {
    let tempCart = [];
    if(action.payload.amount === 1) {
      return {...state,
        cart:state.cart.filter(item=> item.id !== action.payload.id)}
    }
    else {
      let tempCart = state.cart.map((cartItem) => {
        if(cartItem.id === action.payload.id) {
          cartItem = {...cartItem,amount:cartItem.amount -1}
        }
        return cartItem;
      })
      return {...state,cart:tempCart}
    }
  }

  if(action.type === INCREASE) {
    let tempCart = state.cart.map((cartItem) => {
      if(cartItem.id === action.payload.id) {
        cartItem = {...cartItem,amount:cartItem.amount +1}
      }
      return cartItem;
    })

    return {...state,cart:tempCart}
  }

  if(action.type === REMOVE) {
    return {...state,
      cart:state.cart.filter(item=> item.id !== action.payload.id)}
  }
   return state;

      // switch(action.type) {
  //   case CLEAR_CART:
  //       return {...state,cart:[],amount:0}
  //   default:
  //     return state;
  // }
  }

  export default reducer;