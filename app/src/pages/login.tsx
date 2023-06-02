import { ChangeEvent, FormEvent, use, useState } from "react";
import Link from "next/link";
import { useRouter } from "next/router";
import "../app/globals.css";

const LoginForm = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const [showPassword, setShowPassword] = useState(false);

  const router = useRouter();

  const handleCheckboxChange = () => {
    setShowPassword(!showPassword);
  };

  const handlePasswordChange = (e: ChangeEvent<HTMLInputElement>) => {
    setPassword(e.target.value);
  };

  const handleEmailChange = (e: ChangeEvent<HTMLInputElement>) => {
    setEmail(e.target.value);
  };

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log(email, password);
    if (email && password) {
      //uwierzytelnianie
      router.push(".home");
    }
  };

  return (
    <div className="w-screen h-screen flex justify-center items-center bg-gray-200">
      <div className="w-1/4 h-content bg-white px-2 py-4">
        <h1 className="text-center text-3xl py-8">Logowanie</h1>
        <form
          action=""
          className="w-full h-full flex flex-col justify-center gap-4 items-center"
          onSubmit={handleSubmit}
        >
          <input
            type="email"
            name="email"
            id="email"
            value={email}
            onChange={handleEmailChange}
            placeholder="Email"
            className="w-2/3 outline-none p-2 border-2 border-gray-200"
          />
          <input
            type={showPassword ? "text" : "password"}
            name="password"
            id="password"
            value={password}
            onChange={handlePasswordChange}
            placeholder="Password"
            className="w-2/3 outline-none p-2 border-2 border-gray-200"
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
          <input
            type="submit"
            name="submit"
            id="submit"
            value="Zaloguj sie"
            className="w-2/3 outline-none p-4 bg-[#66d1f2] cursor-pointer font-medium text-white text-xl"
          />
          <p>
            Nie masz konta? <Link href="./register">Zarejestruj sie </Link>
          </p>
        </form>
      </div>
    </div>
  );
};

export default LoginForm;
