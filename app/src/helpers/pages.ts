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
    path: "/dashboard/classes",
  },
  classes: {
    title: "Klasy",
    path: "/dashboard/classes",
  },
  class: {
    title: "Klasa",
    path: "/dashboard/classes/",
  },
  addQuiz: {
    title: "Dodaj quiz",
    path: "/dashboard/add-quiz/",
  },
  solveQuiz: {
    title: "Rozwiąż quiz",
    path: "/dashboard/solve-quiz/",
  },
  scores: {
    title: "Wyniki",
    path: "/dashboard/scores/",
  },
};

export const pages = {
  public: publicPages,
  auth: authPages,
  dashboard: dashboardPages,
};
