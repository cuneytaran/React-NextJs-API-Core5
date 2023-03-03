import axios from "axios";
import { getCookie, setCookie } from "cookies-next";

// https://github.com/vercel/next.js/issues/19420
// => This is a workaround for the issue with the next server not being able to access the environment variables
// eslint-disable-next-line prefer-destructuring
const BACKEND_BASE_URL = process.env.BACKEND_BASE_URL;
// eslint-disable-next-line prefer-destructuring
const FRONTEND_BASE_URL = process.env.FRONTEND_BASE_URL;

// This is the axios instance that will be used to make requests between the next server and the backend server
export const axiosBackendServer = axios.create({
  baseURL: BACKEND_BASE_URL,
  headers: { "Content-Type": "application/json" },
  withCredentials: true,
});

export const backendServer = async (req, res, method, url, data) => {
  // Get the access and refresh tokens from the cookies
  const accessToken = getCookie("access_token", { req, res });
  const refreshToken = getCookie("refresh_token", { req, res });

  // If there is an access token, set the Authorization header
  if (accessToken) {
    axiosBackendServer.defaults.headers.common.Authorization = `Bearer ${accessToken}`;
  }

  // console.log("axiosBackendServer", url);

  try {
    // console.log("try", url, data);

    // Make the request
    const response = await axiosBackendServer[method](url, data);
    // console.log("response", url, response);

    return response;
  } catch (error) {
    // console.log("error", url, error);
    // If the request fails, check if the error is a 401
    if (error.response.status === 401) {
      if (refreshToken) {
        // If there is a refresh token, try to get a new access token
        try {
          const response = await axios.post(`${BACKEND_BASE_URL}/auth/refreshlogin/`, {
            refresh: refreshToken,
          });

          const { access, refresh } = response.data;

          // Set the new access token in the cookies
          setCookie("access", access, {
            req,
            res,
            maxAge: 60 * 60 * 24 * 7,
            path: "/",
          });

          // Set the new refresh token in the cookies
          setCookie("refresh", refresh, {
            req,
            res,
            maxAge: 60 * 60 * 24 * 30,
            path: "/",
          });

          // Set the Authorization header with the new access token
          axiosBackendServer.defaults.headers.common.Authorization = `Bearer ${access}`;

          // Make the request again
          const response2 = await axiosBackendServer[method](url, data);
          return response2;
        } catch (error) {
          // console.log("Error getting a new access token: ", error.response.data);
          return error.response;
        }
      } else {
        // console.log("No refresh token");
        return error.response;
      }
    } else {
      // console.log("Error making the request: ", error.response.data);
      return error.response;
    }
  }
};

// Add the methods to the backendServer function so that it can be used like axios
backendServer.get = (req, res, url) => backendServer(req, res, "get", url);
backendServer.post = (req, res, url, data) => backendServer(req, res, "post", url, data);
backendServer.put = (req, res, url, data) => backendServer(req, res, "put", url, data);
backendServer.delete = (req, res, url) => backendServer(req, res, "delete", url);
backendServer.patch = (req, res, url, data) => backendServer(req, res, "patch", url, data);

// This is the axios instance that will be used to make requests between the client and the next server
export const axiosFrontendServer = axios.create({
  baseURL: FRONTEND_BASE_URL ?? "http://localhost:3000/api",
  headers: { "Content-Type": "application/json" },
  withCredentials: true,
});