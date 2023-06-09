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

interface Classes {
  id: number;
  name: string;
  description: string;
}

export const _getAllClasses = async (
  axios: AxiosInstance
): Promise<Classes[]> => {
  const response = await axios.get("/Class");

  return response.data;
};
