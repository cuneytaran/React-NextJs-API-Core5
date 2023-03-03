import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";

import Layout from "../layout/Layout";
import store from "../redux/store";
import router from "next/router";
import NProgress from "nprogress";


import { ToastContainer } from "react-toastify";
import { Provider } from "react-redux";


import "../styles/globals.css";
import "nprogress/nprogress.css";
import "react-toastify/dist/ReactToastify.css";
import { useState } from "react";
import React, { useEffect } from "react";
import { useSelector, useDispatch } from 'react-redux'
import { setUserToken, setEmail } from "@/redux/userSlice";
import jwt_decode from "jwt-decode";

router.events.on("routeChangeStart", () => NProgress.start());
router.events.on("routeChangeComplete", () => NProgress.done());
router.events.on("routeChangeError", () => NProgress.done());

import { getCookie } from "cookies-next";

function App({ Component, pageProps: { session, ...pageProps } }) {

  const [isFirstRender, setIsFirstRender] = useState(true)
  const user_Data = useSelector(state => state.user.token);
  const dispatch = useDispatch();

  useEffect(() => {
    if (!user_Data) {
      //cookie okuma
      const cookie_Data = getCookie("access_token");
      if (cookie_Data) {
        //cokie decode
        const decoded_token = jwt_decode(cookie_Data);
        dispatch(setEmail(decoded_token.email));

        //cookie varsa redux e at
        dispatch(setUserToken(cookie_Data));
      }
    }
  }, [user_Data])


  useEffect(() => {
    setIsFirstRender(false);
  }, [])

  if (!isFirstRender && router.pathname.includes("login")) {
    return (
      <>
        <Provider store={store}>
          <ToastContainer />
          <Component {...pageProps} />
        </Provider>
      </>
    );
  }

  return (
    <Provider store={store}>
      <ToastContainer />
      <Layout>
        <Component {...pageProps} />
      </Layout>
    </Provider>
  );
}


function MyApp({ Component, pageProps: { session, ...pageProps } }) {
  return (

    <Provider store={store}>
      <ToastContainer />
      <App Component={Component} pageProps={pageProps} />
    </Provider>

  );
}

export default MyApp;
