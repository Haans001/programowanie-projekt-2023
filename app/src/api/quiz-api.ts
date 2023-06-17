import axios, { AxiosInstance } from "axios";

export const _getClassQuizzes = async (axios: AxiosInstance, id: number) => {
  const response = await axios.get(`/Quiz/${id}/Class`);

  return response.data;
};

export const _createQuiz = async (values: any) => {
  const response = await axios.post("/Quiz/create", values, {
    baseURL: process.env.NEXT_PUBLIC_API_URL,
  });
};
