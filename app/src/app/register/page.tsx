"use client";
import { ChangeEvent, FormEvent, use, useState } from "react";
import Link from "next/link";
import { useRouter } from "next/navigation";

const LoginForm = () => {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmedPassword, setConfirmedPassword] = useState("");
  const [role, setRole] = useState("");

  const [showPasswordError, setShowPasswordError] = useState(false);
  const [showEmptyInputError, setShowEmptyInputError] = useState(false);

  const router = useRouter();

  const handleFirstNameChange = (e: ChangeEvent<HTMLInputElement>) => {
    setFirstName(e.target.value);
  };

  const handleLastNameChange = (e: ChangeEvent<HTMLInputElement>) => {
    setLastName(e.target.value);
  };

  const handlePasswordChange = (e: ChangeEvent<HTMLInputElement>) => {
    setPassword(e.target.value);
  };

  const handleConfirmedPasswordChange = (e: ChangeEvent<HTMLInputElement>) => {
    setConfirmedPassword(e.target.value);
  };

  const handleEmailChange = (e: ChangeEvent<HTMLInputElement>) => {
    setEmail(e.target.value);
  };

  const handleRoleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setRole(e.target.value);
  };

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log(firstName, lastName, password, confirmedPassword, email, role);
    if (
      !firstName ||
      !lastName ||
      !password ||
      !confirmedPassword ||
      !email ||
      !role
    ) {
      setShowEmptyInputError(true);
    } else {
      if (password !== confirmedPassword) {
        setShowPasswordError(true);
      } else {
        //jakis zapis usera do db, sprawdzenie czy nie istnieje juz taki
        router.push("./home");
      }
    }
  };

  return (
    <div className="w-screen h-screen flex justify-center items-center bg-gray-200">
      <div className="w-1/4 h-content bg-white px-2 py-4">
        <h1 className="text-center text-3xl py-8">Rejestracja</h1>
        <form
          action=""
          className="w-full h-full flex flex-col justify-center gap-4 items-center"
          onSubmit={handleSubmit}
        >
          <div className="w-4/5 flex justify-center gap-2 items-center box-border">
            <input
              type="text"
              value={firstName}
              onChange={handleFirstNameChange}
              placeholder="Imię"
              className="w-1/2 outline-none p-2 border-2 border-gray-200"
            />
            <input
              type="text"
              value={lastName}
              onChange={handleLastNameChange}
              placeholder="Nazwisko"
              className="w-1/2 outline-none p-2 border-2 border-gray-200"
            />
          </div>
          <input
            type="email"
            value={email}
            onChange={handleEmailChange}
            placeholder="Email"
            className="w-4/5 outline-none p-2 border-2 border-gray-200"
          />
          <input
            type="password"
            value={password}
            onChange={handlePasswordChange}
            placeholder="Hasło"
            className={`w-4/5 outline-none p-2 border-2 border-gray-200 ${
              showPasswordError ? "border-red-500" : ""
            }`}
          />
          <input
            type="password"
            value={confirmedPassword}
            onChange={handleConfirmedPasswordChange}
            placeholder="Powtórz hasło"
            className={`w-4/5 outline-none p-2 border-2 border-gray-200 ${
              showPasswordError ? "border-red-500" : ""
            }`}
          />
          {showPasswordError ? (
            <p className="text-red-500">Podane hasła nie są takie same</p>
          ) : (
            ""
          )}
          <div className="w-4/5">
            <p className="text-left">Wybierz role:</p>
          </div>
          <div className="flex w-4/5 gap-2">
            <div className="w-1/2">
              <input
                id="teacher"
                type="radio"
                value="teacher"
                onChange={handleRoleChange}
                checked={role === "teacher"}
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
                onChange={handleRoleChange}
                checked={role === "student"}
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
          {showEmptyInputError ? (
            <p className="text-red-500">Proszę uzupełnić wszystkie pola</p>
          ) : (
            ""
          )}
          <input
            type="submit"
            name="submit"
            id="submit"
            value="Zarejestruj sie"
            className="w-2/3 outline-none p-4 bg-[#66d1f2] cursor-pointer font-medium text-white text-xl"
          />
          <p>
            Masz już konto? <Link href="./login">Zaloguj się</Link>
          </p>
        </form>
      </div>
    </div>
  );
};

export default LoginForm;
