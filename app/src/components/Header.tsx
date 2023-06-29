"use client";
import { useAuth } from "@/providers/auth-provider";
import { BiUser } from "react-icons/bi";
import { BsBook } from "react-icons/bs";
import { TbSchool } from "react-icons/tb";
import Link from "next/link";

const Header = () => {
  const { user, logout } = useAuth();
  console.log(user);
  return (
    <header className="w-full h-16 p-8 bg-white flex justify-between items-center">
      <div className="flex w-1/6 justify-between space-x-4 items-center">
        <h1 className="text-3xl font-medium">Quiz App</h1>
        <Link
          className="hover:text-blue-500 flex text-xl gap-1 items-center justify-between"
          href="/dashboard/classes"
        >
          <BsBook className="mr-1" />
          Moje klasy
        </Link>
      </div>
      <div className="flex space-x-4 items-center">
        <span className="flex text-xl gap-1 items-center justify-between">
          <BiUser />
          <span>
            {user?.firstName} {user?.lastName}
          </span>
        </span>
        <p className="flex text-xl gap-1 items-center justify-between">
          <TbSchool /> {user?.roleId == 1 ? "Nauczyciel" : "Uczeń"}
        </p>
        <button
          onClick={logout}
          className="w-1/10 outline-none py-2 px-6 bg-[#618cfb] hover:bg-[#426bd3] cursor-pointer font-medium text-white text-xl"
        >
          Wyloguj się
        </button>
      </div>
    </header>
  );
};

export default Header;
