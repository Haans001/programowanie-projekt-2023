"use client";
import { useAuth } from "@/providers/auth-provider";
import { BiUser } from "react-icons/bi";

const Header = () => {
  const { user } = useAuth();
  return (
    <header className="w-full h-16 p-8 bg-white flex justify-between items-center">
      <h1 className="text-3xl font-medium">Quiz App</h1>
      <span className="flex text-xl gap-2 items-center justify-between">
        <BiUser />
        <span>
          {user?.firstName} {user?.lastName}
        </span>
      </span>
    </header>
  );
};

export default Header;
