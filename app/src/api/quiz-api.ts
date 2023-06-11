import type { AxiosInstance } from "axios";

export const _getClassQuizzes = async (axios: AxiosInstance, id: number) => {
  const response = await axios.get(`/Quiz/${id}/Class`);

  return response.data;
};
