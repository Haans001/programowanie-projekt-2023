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
