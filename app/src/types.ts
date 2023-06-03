export enum RoleEnum {
  Student = "student",
  Teacher = "teacher",
}

export interface IQuizzies {
  id: number;
  name: string;
  subject: string;
}

export interface IQuizList {
  quizzies: IQuizzies[];
}
