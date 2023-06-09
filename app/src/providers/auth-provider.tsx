"use client";

import { _getUser } from "@/api/auth-api";
import { AUTH_TOKEN_NAME } from "@/config/constants";
import { pages } from "@/helpers/pages";
import { useAxios } from "@/hooks/use-axios";
import type { RoleEnum } from "@/types";
import { useQuery } from "@tanstack/react-query";
import Cookies from "js-cookie";
import { useRouter } from "next/navigation";
import * as React from "react";
interface Props {
  children: React.ReactNode;
}

export interface User {
  id: number;
  name: string;
  email: string;
  firstName: string;
  lastName: string;
  role: RoleEnum;
  roleId: number;
}

interface AuthContextType {
  user: User | null;
  logout: () => void;
}

const AuthContext = React.createContext<AuthContextType>({
  user: null,
  logout: () => {
    throw new Error("Not implemented");
  },
});

export const useAuth = () => React.useContext(AuthContext);

const AuthProvider: React.FunctionComponent<Props> = ({ children }) => {
  const [user, setUser] = React.useState<User | null>(null);
  const [loaded, setLoaded] = React.useState(false);

  const axios = useAxios();

  const { replace } = useRouter();

  useQuery({
    queryKey: ["userData"],
    queryFn: () => _getUser(axios),
    onSuccess: (data) => {
      setUser(data);
      setLoaded(true);
    },
    onError: () => {
      Cookies.remove(AUTH_TOKEN_NAME);
      replace(pages.auth.login.path);
    },
  });

  const logout = () => {
    setUser(null);
    Cookies.remove(AUTH_TOKEN_NAME);
    replace(pages.auth.login.path);
  };

  return loaded ? (
    <AuthContext.Provider value={{ user, logout }}>
      {children}
    </AuthContext.Provider>
  ) : null;
};

export default AuthProvider;
