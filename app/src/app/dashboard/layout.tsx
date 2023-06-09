import Header from "@/components/Header";
import Navbar from "@/components/Navbar";
import AuthProvider from "@/providers/auth-provider";

interface DashboardLayoutProps {
  children: React.ReactNode;
}

const DashboardLayout = ({ children }: DashboardLayoutProps) => {
  return (
    <AuthProvider>
      <div className="flex">
        <Navbar />
        <div className="w-full h-screen">
          <Header />
          <div className="w-full bg-gray-200 h-full p-6">{children}</div>
        </div>
      </div>
    </AuthProvider>
  );
};

export default DashboardLayout;
