import { setCookie } from "cookies-next";
import { axiosBackendServer } from "../../../services/axios";

const handler = async (req, res) => {
  return new Promise((resolve) => {
    if (req.method === "POST") {
      const { email, password } = req.body;

      axiosBackendServer .post("/auth/login", {
          email,
          password,
        })
        .then((result) => {
          const { token, refresh } = result.data.data;
          setCookie("access_token", token, { req, res,
            // httpOnly: true,
          });

          setCookie("refresh_token", refresh, {
            req,
            res,
            // httpOnly: true,
          });

          res.status(200).json(result.data);
          resolve();
        })
        .catch((e) => {     
          res.status(400).json(e.response.data);
          resolve();
        });
    } else {
      res.status(400).json({ message: "Bad request" });
      resolve();
    }
  });
};

export default handler;