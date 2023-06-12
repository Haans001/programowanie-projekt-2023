import type { AxiosInstance } from "axios";

export interface AddClassRequestBody {
  name: string;
  description: string;
}

export const _addClass = async (
  axios: AxiosInstance,
  data: AddClassRequestBody
) => {
  const response = await axios.post("/Class/create", data);

  return response.data;
};

interface Class {
  id: number;
  name: string;
  description: string;
}

export const _getAllClasses = async (
  axios: AxiosInstance
): Promise<Class[]> => {
  const response = await axios.get("/Class");

  return response.data;
};

export const _getClass = async (
  axios: AxiosInstance,
  id: number
): Promise<Class> => {
  const response = await axios.get(`/Class/${id}`);

  return response.data;
};
