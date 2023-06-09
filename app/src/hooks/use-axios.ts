import { AUTH_TOKEN_NAME } from "@/config/constants";
import axios from "axios";
import Cookies from "js-cookie";

const getToken = () => {
  const token = Cookies.get(AUTH_TOKEN_NAME);
  if (!token) {
    throw new Error("No token found");
  }
  return token;
};

export const useAxios = () => {
  //   const { getToken } = useAuth();
  const instance = axios.create({
    baseURL: process.env.NEXT_PUBLIC_API_URL,
  });

  instance.interceptors.request.use(
    async (req) => {
      req.headers.Authorization = `Bearer ${getToken()}`;
      return req;
    },
    (error) => Promise.reject(error)
  );

  return instance;
};
