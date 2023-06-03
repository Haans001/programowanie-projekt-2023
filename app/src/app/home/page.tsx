"use client";

import Header from "@/components/Header";
import Navbar from "@/components/Navbar";

const Home = () => {
  return (
    <div className="flex">
      <Navbar />
      <div className="w-full h-screen">
        <Header />
      </div>
    </div>
  );
};

export default Home;
