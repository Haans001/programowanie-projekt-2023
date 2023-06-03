import { MdQuiz } from "react-icons/md";
import { FiUsers } from "react-icons/fi";

const Navbar = () => {
  return (
    <nav className="h-screen w-[12%] py-4 bg-[#29348e] flex flex-col items-center justify-between">
      <ul className="my-4 ">
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
      </ul>
      <button className="w-1/10 outline-none py-2 px-6 bg-[#618cfb] hover:bg-[#426bd3] cursor-pointer font-medium text-white text-xl">
        Wyloguj się
      </button>
    </nav>
  );
};

export default Navbar;
