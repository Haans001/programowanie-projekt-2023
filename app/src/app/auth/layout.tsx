interface AuthLayoutProps {
  children: React.ReactNode;
}

const AuthLayout = ({ children }: AuthLayoutProps) => (
  <div className="w-screen h-screen flex justify-center items-center bg-gray-200">
    <div className="w-1/4 h-content bg-white px-2 py-4">{children}</div>
  </div>
);

export default AuthLayout;
