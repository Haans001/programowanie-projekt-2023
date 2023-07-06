export enum RoleEnum {
  Teacher = 1,
  Student = 2,
}

export interface IQuizzies {
  id: number;
  name: string;
  subject: string;
}

export interface IQuizList {
  quizzies: IQuizzies[];
}
