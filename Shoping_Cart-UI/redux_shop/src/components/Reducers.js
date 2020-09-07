// reducer here will dispatch action
import {INCREASE,DECREASE} from "../components/Actions";

function reducer(state,action) {
    if(action.type === DECREASE) {
        // state.count = state.count -1;
        return {...state,count:state.count-1};
    }
  
    if(action.type === INCREASE) {
      return {...state,count:state.count+1};
    }
  
    return state;
  }

  export default reducer;