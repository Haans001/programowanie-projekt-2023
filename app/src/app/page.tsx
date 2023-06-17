import { pages } from "@/helpers/pages";
import Image from "next/image";
import Link from "next/link";
import heroImage from "../assets/hero-image.jpg";
import "./globals.css";

const LandingPage = () => {
  return (
    <div className="w-screen h-screen bg-white">
      <div className="w-screen flex justify-between items-center p-4">
        <h1 className="text-4xl font-medium">QuizApp</h1>
        <Link href={pages.auth.login.path}>
          <button className="w-1/10 outline-none py-2 px-6 bg-[#49c7ee] hover:bg-[#618cfb] cursor-pointer font-medium text-white text-xl">
            Zaloguj się
          </button>
        </Link>
      </div>
      <main className="flex w-screen">
        <section className="w-1/2 flex flex-col text-center justify-center items-center gap-4">
          <h2 className="text-6xl font-medium">
            Twój najlepszy towarzysz w nauce i sprawdzianach!
          </h2>
          <p className="text-2xl">
            Zanurz się w świat interaktywnej nauki i sprawdzianów z QuizApp -
            Twoim niezawodnym przewodnikiem do sukcesu edukacyjnego!
          </p>
          <Link href={pages.auth.register.path}>
            <button className="w-1/10 outline-none py-2 px-6 bg-[#66d1f2] hover:bg-[#618cfb] cursor-pointer font-medium text-white text-xl">
              Dołącz do nas
            </button>
          </Link>
        </section>
        <section className="w-1/2">
          <Image src={heroImage} alt="students photo" />
        </section>
      </main>
    </div>
  );
};

export default LandingPage;
