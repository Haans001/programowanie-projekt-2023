import "../app/globals.css";

const LoginForm = () => {
  return (
    <div className="w-full h-full flex justify-center bg-black">
      <form action="" className="w-1/3 flex flex-col">
        <input type="email" name="email" id="email" placeholder="Email" />
        <input
          type="password"
          name="password"
          id="password"
          placeholder="Password"
        />
        <label htmlFor="showPassword">
          <input type="checkbox" name="showPassword" id="showPassword" />
          Show Password
        </label>
        <input type="submit" name="submit" id="submit" value="Zaloguj sie" />
      </form>
    </div>
  );
};

export default LoginForm;
