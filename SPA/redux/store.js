import { configureStore } from "@reduxjs/toolkit";
import userReducer from "./userSlice";
import cartReducer from "./cartSlice";

export default configureStore({    
  reducer: {    
    user: userReducer,
    cart: cartReducer,
  },
});
//userClice.js işleminede yaptıkdan sonra page altındaki _app.js deki kodları da değiştir
