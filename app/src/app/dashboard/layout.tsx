import Header from "@/components/Header";
import Navbar from "@/components/Navbar";

interface DashboardLayoutProps {
  children: React.ReactNode;
}

const Home = ({ children }: DashboardLayoutProps) => {
  return (
    <div className="flex">
      <Navbar />
      <div className="w-full h-screen">
        <Header />

        <div className="w-full bg-gray-200 h-full p-6">{children}</div>
      </div>
    </div>
  );
};

export default Home;
