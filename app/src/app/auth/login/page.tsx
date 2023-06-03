"use client";
import { _login } from "@/api/auth-api";
import { TextInputField } from "@/components/forms";
import { AUTH_TOKEN_NAME } from "@/config/constants";
import { pages } from "@/helpers/pages";
import { useMutation } from "@tanstack/react-query";
import { Formik } from "formik";
import type { NextPage } from "next";
import Link from "next/link";
import { useRouter } from "next/navigation";
import * as React from "react";
import * as Yup from "yup";

const LoginPage: NextPage = () => {
  const [showPassword, setShowPassword] = React.useState(false);

  const handleCheckboxChange = () => {
    setShowPassword(!showPassword);
  };

  const router = useRouter();

  const { mutate: login, isLoading } = useMutation({
    mutationFn: _login,
    onSuccess: async (token) => {
      localStorage.setItem(AUTH_TOKEN_NAME, token);
      router.replace(pages.dashboard.home.path);
    },
    onError: (error) => {
      console.log(error);
    },
  });
  return (
    <>
      <h1 className="text-center text-3xl py-8">Logowanie</h1>
      <Formik
        initialValues={{
          email: "",
          password: "",
        }}
        validationSchema={Yup.object().shape({
          email: Yup.string()
            .email("Niepoprawny email")
            .required("Pole wymagane"),
          password: Yup.string().required("Pole wymagane"),
        })}
        onSubmit={login}
      >
        {({ handleSubmit }) => (
          <form
            className="w-full h-full flex flex-col justify-center gap-4 items-center"
            onSubmit={handleSubmit}
          >
            <TextInputField
              type="email"
              name="email"
              placeholder="Email"
              className="w-2/3"
            />
            <TextInputField
              type={showPassword ? "text" : "password"}
              name="password"
              placeholder="Password"
              className="w-2/3"
            />
            <div className="w-2/3">
              <label
                htmlFor="showPassword"
                className="flex items-center gap-2 cursor-pointer"
              >
                <input
                  type="checkbox"
                  name="showPassword"
                  checked={showPassword}
                  onChange={handleCheckboxChange}
                  id="showPassword"
                  className="text-gray-400 h-4 w-4 cursor-pointer"
                />
                Show Password
              </label>
            </div>
            <button
              disabled={isLoading}
              type="submit"
              value="Zaloguj sie"
              className="w-2/3 outline-none p-4 bg-[#66d1f2] cursor-pointer font-medium text-white text-xl hover:bg-[#618cfb]"
            >
              Zaloguj się
            </button>
            <p>
              Nie masz konta?{" "}
              <Link href={pages.auth.register.path}>Zarejestruj sie</Link>
            </p>
          </form>
        )}
      </Formik>
    </>
  );
};

export default LoginPage;
