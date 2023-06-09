"use client";
import { _register } from "@/api/auth-api";
import { TextInputField } from "@/components/forms";
import { pages } from "@/helpers/pages";
import { RoleEnum } from "@/types";
import { useMutation } from "@tanstack/react-query";
import { Formik } from "formik";
import type { NextPage } from "next";
import Link from "next/link";
import { useRouter } from "next/navigation";
import * as Yup from "yup";

const RegisterPage: NextPage = () => {
  const router = useRouter();

  const { mutate: register, isLoading } = useMutation({
    mutationFn: _register,
    onSuccess: async () => {
      router.replace(pages.auth.login.path);
    },
    onError: (error) => {
      console.log(error);
    },
  });

  return (
    <>
      <h1 className="text-center text-3xl py-8">Rejestracja</h1>
      <Formik
        initialValues={{
          firstName: "jan",
          lastName: "ra",
          email: "rapacz@gmail.com",
          password: "jasiu123",
          confirmPassword: "jasiu123",
          role: RoleEnum.Student,
        }}
        validationSchema={Yup.object().shape({
          firstName: Yup.string().required("Pole wymagane"),
          lastName: Yup.string().required("Pole wymagane"),
          email: Yup.string()
            .email("Niepoprawny email")
            .required("Pole wymagane"),
          password: Yup.string().required("Pole wymagane"),
          confirmPassword: Yup.string().test(
            "passwords-match",
            "Hasła muszą być takie same",
            function (value) {
              return this.parent.password === value;
            }
          ),
        })}
        onSubmit={register}
      >
        {({ handleSubmit, values, setFieldValue }) => (
          <form
            className="w-full h-full flex flex-col justify-center gap-4 items-center"
            onSubmit={handleSubmit}
          >
            <div className="w-4/5 flex justify-center gap-2 items-center box-border">
              <div className="w-1/2">
                <TextInputField
                  name="firstName"
                  type="text"
                  placeholder="Imię"
                  className="w-full"
                />
              </div>
              <div className="w-1/2">
                <TextInputField
                  name="lastName"
                  type="text"
                  placeholder="Nazwisko"
                  className="w-full"
                />
              </div>
            </div>
            <TextInputField
              name="email"
              type="email"
              placeholder="Email"
              className="w-4/5"
            />
            <TextInputField
              name="password"
              type="password"
              placeholder="Hasło"
              className="w-4/5"
            />
            <TextInputField
              name="confirmPassword"
              type="password"
              placeholder="Powtórz hasło"
              className="w-4/5"
            />
            <div className="w-4/5">
              <p className="text-left">Wybierz role:</p>
            </div>
            <div className="flex w-4/5 gap-2">
              <div className="w-1/2">
                <input
                  id="teacher"
                  type="radio"
                  value="teacher"
                  onChange={() => setFieldValue("role", RoleEnum.Teacher)}
                  checked={values.role === RoleEnum.Teacher}
                  name="role"
                  className="peer hidden"
                />
                <label
                  htmlFor="teacher"
                  className="flex cursor-pointer border-2 border-gray-200 justify-center items-center p-2 font-medium text-[#8e8e8e] peer-checked:border-[#66d1f2] peer-checked:text-[#66d1f2]"
                >
                  Nauczyciel
                </label>
              </div>
              <div className="w-1/2">
                <input
                  id="student"
                  type="radio"
                  value="student"
                  onChange={() => setFieldValue("role", RoleEnum.Student)}
                  checked={values.role === RoleEnum.Student}
                  name="role"
                  className="peer hidden"
                />
                <label
                  htmlFor="student"
                  className="flex cursor-pointer border-2 border-gray-200 justify-center items-center p-2 font-medium text-[#8e8e8e]  peer-checked:border-[#66d1f2] peer-checked:text-[#66d1f2] "
                >
                  Uczeń
                </label>
              </div>
            </div>
            <button
              disabled={isLoading}
              type="submit"
              className="w-2/3 outline-none p-4 bg-[#66d1f2] cursor-pointer font-medium text-white text-xl hover:bg-[#618cfb]"
            >
              Zarejestruj się
            </button>
            <p>
              Masz już konto?{" "}
              <Link href={pages.auth.login.path}>Zaloguj się</Link>
            </p>
          </form>
        )}
      </Formik>
    </>
  );
};

export default RegisterPage;
