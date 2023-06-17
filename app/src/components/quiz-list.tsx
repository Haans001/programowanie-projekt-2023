import type { IQuizList } from "@/types";
import Button from "./button";
import Card from "./card";

const QuizList = ({ quizzies }: IQuizList) => (
  <div className="my-4 grid grid-cols-5 gap-8">
    {quizzies.map((quiz) => (
      <Card description={quiz.subject} title={quiz.name} key={quiz.id}>
        <Button>Rozpocznij quiz</Button>
      </Card>
    ))}
  </div>
);

export default QuizList;
