"use client";
import { TextInputField } from "@/components/forms";
import { pages } from "@/helpers/pages";
import { Formik } from "formik";
import { NextPage } from "next";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { useState } from "react";
import * as Yup from "yup";

interface LoginFormValues {
  email: string;
  password: string;
}

const LoginPage: NextPage = () => {
  const [showPassword, setShowPassword] = useState(false);

  const router = useRouter();

  const handleCheckboxChange = () => {
    setShowPassword(!showPassword);
  };

  const handleSubmit = (values: LoginFormValues) => {
    console.log(values);
  };

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
        onSubmit={handleSubmit}
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
              type="submit"
              value="Zaloguj sie"
              className="w-2/3 outline-none p-4 bg-[#66d1f2] cursor-pointer font-medium text-white text-xl"
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