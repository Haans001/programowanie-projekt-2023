const authPages = {
  login: {
    title: "Login",
    path: "/auth/login",
  },
  register: {
    title: "Register",
    path: "/auth/register",
  },
};

const publicPages = {
  landing: {
    title: "Landing",
    path: "/",
  },
};

const dashboardPages = {
  home: {
    title: "Home",
    path: "/dashboard/home",
  },
  classes: {
    title: "Klasy",
    path: "/dashboard/classes",
  },
};

export const pages = {
  public: publicPages,
  auth: authPages,
  dashboard: dashboardPages,
};
