"use client";
import { _getQuizScores } from "@/api/score-api";
import { useAxios } from "@/hooks/use-axios";
import { useQuery } from "@tanstack/react-query";
import type { NextPage } from "next";
import { useParams } from "next/navigation";

const ScoresPage: NextPage = () => {
  const params = useParams();

  const axios = useAxios();

  const quizId = Number(params.quiz_id);

  const { data: scores } = useQuery({
    queryKey: ["quizScore"],
    queryFn: () => _getQuizScores(axios, quizId),
  });

  return (
    <div>
      <h1 className="text-4xl font-bold">Wyniki dla: </h1>
      <table className="min-w-full divide-y divide-gray-200 mt-4">
        <thead className="bg-gray-50">
          <tr>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Wynik
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Data
            </th>
            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
              Imie i nazwisko ucznia
            </th>
          </tr>
        </thead>
        <tbody className="bg-white divide-y divide-gray-200">
          {scores?.map((score) => (
            <tr>
              <td className="px-6 py-4 whitespace-nowrap">
                {score.percentOfCorrectAnswers * 100}%
              </td>
              <td className="px-6 py-4 whitespace-nowrap">
                {new Date(score.dateOfCompletion).toLocaleDateString()}
              </td>
              <td className="px-6 py-4 whitespace-nowrap">
                {score.user.firstName} {score.user.lastName}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ScoresPage;
