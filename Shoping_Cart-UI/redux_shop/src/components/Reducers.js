import {DECREASE,INCREASE,CLEAR_CART,REMOVE} from "./Actions";

// reducer here will dispatch action
function reducer(state,action) {
  if(action.type === CLEAR_CART) {
    return {...state,cart:[]};
  }

  if(action.type === DECREASE) {
    return {...state,cart:state.cart -1};
  }

  if(action.type === INCREASE) {
    return {...state,cart:state.cart +1};
  }

  if(action.type === REMOVE) {
    return {...state,cart:state.cart.filter(item=> item.id !== action.payload.id)}
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