import {DECREASE,INCREASE,CLEAR_CART,REMOVE,GET_TOTALS} from "./Actions";

// reducer here will dispatch action
function reducer(state,action) {
  if(action.type === CLEAR_CART) {
    return {...state,cart:[]};
  }

  if(action.type === DECREASE) {
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

  if(action.type === GET_TOTALS) {
     let {total, amount} = state.cart.reduce(
       (cartTotal,cartItem) => {
         const {price,amount} = cartItem;
         cartTotal.amount += amount;
       return cartTotal;
     },{
       total:0,
       amount:0
      });
      return {...state,total,amount}
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