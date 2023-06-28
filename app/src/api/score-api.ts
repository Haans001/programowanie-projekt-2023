import type { User } from "@/providers/auth-provider";
import type { AxiosInstance } from "axios";

export const _publishScore = async (
  axios: AxiosInstance,
  quizId: number,
  percentOfCorrectAnswers: number
) => {
  const response = await axios.post("/Score", {
    quizId,
    percentOfCorrectAnswers,
  });

  return response.data;
};

export interface Score {
  id: number;
  dateOfCompletion: string;
  percentOfCorrectAnswers: number;
  quizTitle: string;
  quizId: number;
  userId: number;
  user: User;
}

export const _getQuizScores = async (
  axios: AxiosInstance,
  quizId: number
): Promise<Score[]> => {
  const response = await axios.get(`/Score/quiz/${quizId}`);

  return response.data;
};
