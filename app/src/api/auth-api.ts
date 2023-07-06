import { User } from "@/providers/auth-provider";
import type { RoleEnum } from "@/types";
import axios, { AxiosInstance } from "axios";

export interface SignupRequestBody {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  confirmPassword: string;
  roleId: RoleEnum;
}

export const _register = async (data: SignupRequestBody) => {
  const response = await axios.post("/Account/register", data, {
    baseURL: process.env.NEXT_PUBLIC_API_URL,
  });

  return response.data;
};

export interface LoginRequestBody {
  email: string;
  password: string;
}

export const _login = async (data: LoginRequestBody): Promise<string> => {
  const response = await axios.post("/Account/login", data, {
    baseURL: process.env.NEXT_PUBLIC_API_URL,
  });

  return response.data as string;
};

export const _getUser = async (axios: AxiosInstance): Promise<User> => {
  const response = await axios.get("/Account/me");

  return response.data;
};
