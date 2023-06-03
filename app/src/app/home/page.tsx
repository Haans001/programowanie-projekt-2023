"use client";

import Header from "@/components/Header";
import MainHome from "@/components/MainHome";
import Navbar from "@/components/Navbar";

const Home = () => {
  return (
    <div className="flex">
      <Navbar />
      <div className="w-full h-screen">
        <Header />
        <MainHome />
      </div>
    </div>
  );
};

export default Home;
