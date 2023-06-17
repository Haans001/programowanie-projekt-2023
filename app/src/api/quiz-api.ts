import type { AxiosInstance } from "axios";

export const _getClassQuizzes = async (axios: AxiosInstance, id: number) => {
  const response = await axios.get(`/Quiz/${id}/Class`);

  return response.data;
};

export const _createQuiz = async (axios: AxiosInstance, values: any) => {
  console.log("hujan");
  const response = await axios.post("/Quiz/create", values, {
    baseURL: process.env.NEXT_PUBLIC_API_URL,
  });

  return response.data;
};
