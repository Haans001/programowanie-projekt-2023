import type { AxiosInstance } from "axios";

export interface Answers {
  id: number;
  content: string;
  isCorrect: boolean;
}

export interface Questions {
  id: number;
  content: string;
  answersDtos: Answers[];
}

export interface Quiz {
  id: number;
  name: string;
  dateOfCreation: string;
  isOpen: boolean;
  user_id: number;
  classId: number;
}

export const _getClassQuizzes = async (
  axios: AxiosInstance,
  id: number
): Promise<Quiz[]> => {
  const response = await axios.get(`/Quiz/${id}/Class`);

  return response.data;
};

export const _createQuiz = async (axios: AxiosInstance, values: any) => {
  const response = await axios.post("/Quiz/create", values, {
    baseURL: process.env.NEXT_PUBLIC_API_URL,
  });

  return response.data;
};

export const _getQuizQuestions = async (
  axios: AxiosInstance,
  id: number
): Promise<Questions[]> => {
  const response = await axios.get(`/Quiz/${id}/questions`);

  return response.data;
};

export const _closeQuiz = async (axios: AxiosInstance, id: number) => {
  const response = await axios.post(`/Quiz/${id}/close`, {
    baseURL: process.env.NEXT_PUBLIC_API_URL,
  });
  return response.data;
};

export const _removeQuiz = async (axios: AxiosInstance, id: number) => {
  const response = await axios.delete(`/Quiz/${id}`, {
    baseURL: process.env.NEXT_PUBLIC_API_URL,
  });
  return response.data;
};
