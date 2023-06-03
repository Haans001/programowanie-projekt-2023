import MainSection from "@/components/MainSection";
import { pages } from "@/helpers/pages";
import Link from "next/link";
import "./globals.css";

const LandingPage = () => {
  return (
    <div className="w-screen h-screen bg-white">
      <div className="w-screen flex justify-between items-center p-4">
        <h1 className="text-4xl font-medium">QuizApp</h1>
        <Link href={pages.auth.login.path}>
          <button className="w-1/10 outline-none py-2 px-6 bg-[#66d1f2] cursor-pointer font-medium text-white text-xl">
            Zaloguj się
          </button>
        </Link>
      </div>
      <MainSection />
    </div>
  );
};

export default LandingPage;
