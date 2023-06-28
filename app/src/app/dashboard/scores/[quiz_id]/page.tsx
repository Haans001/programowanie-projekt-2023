"use client";
import { _getClass } from "@/api/class-api";
import { _getClassQuizzes } from "@/api/quiz-api";
import { useAxios } from "@/hooks/use-axios";
import { useQuery } from "@tanstack/react-query";
import type { NextPage } from "next";
import { useParams } from "next/navigation";
import * as React from "react";

const ScoresPAge: NextPage = () => {
  const params = useParams();

  const axios = useAxios();

  const classId = Number(params.class_id);

  const [addUserToClassModalOpen, setAddUserToClassModalOpen] =
    React.useState(false);

  const { data: classData, refetch } = useQuery({
    queryKey: ["class"],
    queryFn: () => _getClass(axios, classId),
  });

  const { data: quizData } = useQuery({
    queryKey: ["classQuizes"],
    queryFn: () => _getClassQuizzes(axios, classId),
  });

  const students = classData?.usersDtos ?? [];

  const quizes = quizData ?? [];

  return (
    <div>
      <h1 className="text-4xl font-bold">Wyniki dla: </h1>
    </div>
  );
};

export default ScoresPAge;
