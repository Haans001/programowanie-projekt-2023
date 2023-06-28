"use client";
import { _getQuizQuestions } from "@/api/quiz-api";
import { _publishScore } from "@/api/score-api";
import Button from "@/components/button";
import Card from "@/components/card";
import BaseModal from "@/components/modal/base-modal";
import { pages } from "@/helpers/pages";
import { useAxios } from "@/hooks/use-axios";
import { useMutation, useQuery } from "@tanstack/react-query";
import type { NextPage } from "next";
import Link from "next/link";
import { useParams } from "next/navigation";
import * as React from "react";

const ClassPage: NextPage = () => {
  const params = useParams();

  const axios = useAxios();

  const quizId = Number(params.quiz_id);

  const { data: questions } = useQuery({
    queryKey: ["quizQuestions"],
    queryFn: () => _getQuizQuestions(axios, quizId),
  });

  const totalQuestions = questions?.length ?? 0;

  const [currentQuestion, setCurrentQuestion] = React.useState(0);

  const [userAnswer, setUserAnswer] = React.useState(0);

  const [score, setScore] = React.useState(0);

  const { mutate: publishScore, isLoading } = useMutation({
    mutationFn: (score: number) =>
      _publishScore(axios, quizId, score / totalQuestions),
    onSuccess: () => {
      setSummaryModalOpen(true);
    },
  });

  const [summaryModalOpen, setSummaryModalOpen] = React.useState(false);

  const handleNextQuestion = () => {
    let newScore = score;

    if (questions?.[currentQuestion].answersDtos[userAnswer].isCorrect) {
      console.log("pierwszy if", newScore);
      newScore = score + 1;
    }
    if (currentQuestion + 1 < totalQuestions) {
      setCurrentQuestion(currentQuestion + 1);
    } else {
      console.log(newScore);
      publishScore(newScore);
    }
    setScore(newScore);
  };

  const scorePercent = (score / totalQuestions) * 100 + "%";

  return questions ? (
    <div>
      <h1 className="text-3xl font-bold">
        <span className="text-gray-500">Rozwiązywanie Quizu:</span> Pytanie{" "}
        {currentQuestion + 1} / {totalQuestions}
      </h1>
      <Card className="mt-4" title={questions[currentQuestion].content}>
        {questions[currentQuestion].answersDtos.map((answer, index) => (
          <div key={answer.id}>
            <input
              type="radio"
              name="answer"
              id={answer.id.toString()}
              onChange={() => setUserAnswer(index)}
              className="mr-2"
              checked={userAnswer === index}
            />
            <label htmlFor={answer.id.toString()}>{answer.content}</label>
          </div>
        ))}
        <Button
          onClick={handleNextQuestion}
          className="mt-4"
          disabled={isLoading}
        >
          Zatwierdź i przejdź dalej
        </Button>
      </Card>
      <BaseModal
        open={summaryModalOpen}
        title="Quiz Skończony! Twój wynik to:"
        description={scorePercent}
        content={
          <>
            <Link href={pages.dashboard.classes.path}>
              <Button className="mt-4">Wróć do klas</Button>
            </Link>
          </>
        }
      />
    </div>
  ) : null;
};

export default ClassPage;
