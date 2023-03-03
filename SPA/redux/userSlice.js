import { createSlice } from "@reduxjs/toolkit";

const userSlice = createSlice({
    name: "user",
    initialState: {
        email:"",
        token: false,
        userData: [],
    },
    reducers: {
        addUser: (state, action) => {
            state.email=action.payload.email;
            state.token=action.payload.token;
            state.userData.push(action.payload);
        },
        setUserToken: (state, action) => {
            state.token = !!action.payload;
        },
        setEmail:(state,action) => {           
            state.email = action.payload                
        },
        reset: (state, action) => {
            state.email="";
            state.token= false;
            state.userData = [];
        },
    },
});

export const { addUser,setUserToken,setEmail,reset } = userSlice.actions;
export default userSlice.reducer;