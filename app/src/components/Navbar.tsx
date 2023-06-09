"use client";
import { pages } from "@/helpers/pages";
import { useAuth } from "@/providers/auth-provider";
import Link from "next/link";
import { useState } from "react";
import { BiRightArrowAlt } from "react-icons/bi";
import { FiUsers } from "react-icons/fi";
import { MdClose, MdQuiz } from "react-icons/md";

const Navbar = () => {
  const [isNavbarClosed, setIsNavbarClosed] = useState(false);

  const handleNavbarClose = () => {
    setIsNavbarClosed(!isNavbarClosed);
  };

  const { logout } = useAuth();

  return (
    <>
      <nav
        className={`${
          isNavbarClosed ? "hidden" : "block"
        } h-screen w-72 py-4 bg-[#29348e]`}
      >
        <div className="text-right h-[10%] pr-4">
          <button onClick={handleNavbarClose}>
            <MdClose className="w-6 h-6 text-gray-400 hover:text-red-500" />
          </button>
        </div>
        <div className="h-[90%] flex flex-col items-center justify-between">
          <ul>
            <li className="flex mb-2 justify-start items-center gap-4 pl-5 hover:bg-[#618cfb] p-2 rounded-md group cursor-pointer hover:shadow-lg m-auto">
              <MdQuiz className="text-2xl text-gray-400 group-hover:text-white " />
              <h3 className="text-lg text-gray-200 group-hover:text-white font-medium ">
                Quizy
              </h3>
            </li>
            <li className="flex mb-2 justify-start items-center gap-4 pl-5 hover:bg-[#618cfb] p-2 rounded-md group cursor-pointer hover:shadow-lg m-auto">
              <FiUsers className="text-2xl text-gray-400 group-hover:text-white " />
              <h3 className="text-lg text-gray-200 group-hover:text-white font-medium ">
                Użytkownicy
              </h3>
            </li>
            <li className="flex mb-2 justify-start items-center gap-4 pl-5 hover:bg-[#618cfb] p-2 rounded-md group cursor-pointer hover:shadow-lg m-auto">
              <FiUsers className="text-2xl text-gray-400 group-hover:text-white " />
              <h3 className="text-lg text-gray-200 group-hover:text-white font-medium">
                <Link href={pages.dashboard.classes.path}>Moje klasy</Link>
              </h3>
            </li>
          </ul>
          <button
            onClick={logout}
            className="w-1/10 outline-none py-2 px-6 bg-[#618cfb] hover:bg-[#426bd3] cursor-pointer font-medium text-white text-xl"
          >
            Wyloguj się
          </button>
        </div>
      </nav>
      <button
        onClick={handleNavbarClose}
        className={`${
          isNavbarClosed ? "block" : "hidden"
        } fixed top-32 bg-[#618cfb] hover:bg-[#426bd3] p-2 rounded-r-full`}
      >
        <BiRightArrowAlt className="text-2xl" />
      </button>
    </>
  );
};

export default Navbar;
