import { IQuizList } from "@/types";
import Quiz from "./Quiz";

const QuizList = ({ quizzies }: IQuizList) => {
  console.log(quizzies);
  return (
    <div className="my-4 grid grid-cols-5 gap-8">
      {quizzies.map((quiz: any) => (
        <Quiz
          key={quiz.id}
          id={quiz.id}
          name={quiz.name}
          subject={quiz.subject}
        />
      ))}
    </div>
  );
};

export default QuizList;
