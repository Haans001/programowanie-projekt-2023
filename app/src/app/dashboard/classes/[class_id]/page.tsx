"use client";
import { _getClass } from "@/api/class-api";
import { _getClassQuizzes } from "@/api/quiz-api";
import Button from "@/components/button";
import Card from "@/components/card";
import { pages } from "@/helpers/pages";
import { useAxios } from "@/hooks/use-axios";
import { useQuery } from "@tanstack/react-query";
import type { NextPage } from "next";
import Link from "next/link";
import { useParams } from "next/navigation";

const ClassPage: NextPage = () => {
  const params = useParams();

  const axios = useAxios();

  const { data: classData } = useQuery({
    queryKey: ["class"],
    queryFn: () => _getClass(axios, Number(params.class_id)),
  });

  const { data: quizData } = useQuery({
    queryKey: ["classQuizes"],
    queryFn: () => _getClassQuizzes(axios, Number(params.class_id)),
  });
  console.log(quizData);

  return classData ? (
    <div>
      <h1 className="text-4xl font-bold">
        <span className="text-gray-500">Klasa:</span> {classData.name}
      </h1>
      <p className="mt-2 text-gray-700">{classData.description}</p>
      <div>
        <h2 className="text-2xl font-semibold mt-8">Quizy</h2>
        <Link href={pages.dashboard.addQuiz.path + params.class_id}>
          <Button className="mt-4">Dodaj Quiz</Button>
        </Link>
        {quizData?.length > 0 ? (
          <div className="grid lg:grid-cols-3 md:grid-cols-2 grid-cols-1 mt-6 gap-4">
            {quizData.map((quiz: any) => (
              <Card title={quiz.name} key={quiz.id}>
                <Button>Rozpocznij quiz</Button>
              </Card>
            ))}
          </div>
        ) : (
          <div className="flex flex-col items-center">
            <p className="text-center text-sm text-gray-700 mt-4">
              Nie dodano jeszcze żadnych quizów do tej klasy
            </p>
          </div>
        )}
      </div>
    </div>
  ) : null;
};

export default ClassPage;
