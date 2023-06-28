"use client";
import { _getClass } from "@/api/class-api";
import { _getClassQuizzes } from "@/api/quiz-api";
import Button from "@/components/button";
import Card from "@/components/card";
import AddUserToClassModalContent from "@/components/modal/add-user-to-class-modal-content";
import BaseModal from "@/components/modal/base-modal";
import { pages } from "@/helpers/pages";
import { useAxios } from "@/hooks/use-axios";
import { useQuery } from "@tanstack/react-query";
import type { NextPage } from "next";
import Link from "next/link";
import { useParams } from "next/navigation";
import * as React from "react";
import { toast } from "react-toastify";

const ClassPage: NextPage = () => {
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

  return classData ? (
    <div>
      <h1 className="text-4xl font-bold">
        <span className="text-gray-500">Klasa:</span> {classData.name}
      </h1>
      <p className="mt-2 text-gray-700">{classData.description}</p>
      <div>
        <div className="flex justify-between items-center">
          <h2 className="text-2xl font-semibold mt-8">Quizy</h2>
          <Link href={pages.dashboard.addQuiz.path + params.class_id}>
            <Button className="mt-4">Dodaj Quiz</Button>
          </Link>
        </div>

        {quizes?.length > 0 ? (
          <div className="grid lg:grid-cols-3 md:grid-cols-2 grid-cols-1 mt-6 gap-4">
            {quizes?.map((quiz) => (
              <Card title={quiz.name} key={quiz.id}>
                <div className="flex gap-2">
                  <Link href={pages.dashboard.solveQuiz.path + quiz.id}>
                    <Button>Rozpocznij quiz</Button>
                  </Link>
                  <Link href={pages.dashboard.scores.path + quiz.id}>
                    <Button variant="secondary">Wyniki</Button>
                  </Link>
                  <Button variant="danger">Zamknij quiz</Button>
                </div>
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
        <div className="flex justify-between items-center">
          <h1 className="text-2xl font-bold mt-8">Uczniowie</h1>
          <Button
            className="mt-4"
            onClick={() => setAddUserToClassModalOpen(true)}
          >
            Dodaj Ucznia
          </Button>
        </div>
        <div className="mt-6">
          {students.length > 0 ? (
            students.map((student) =>
              student.id !== classData.ownerId ? (
                <div className="flex gap-4" key={student.id}>
                  <p>{student.firstName + " " + student.lastName}</p>
                </div>
              ) : null
            )
          ) : (
            <div className="flex flex-col items-center">
              <p className="text-center text-sm text-gray-700 mt-4">
                W tej klasie nie ma jeszcze uczniów
              </p>
            </div>
          )}
        </div>
      </div>
      <BaseModal
        open={addUserToClassModalOpen}
        setOpen={setAddUserToClassModalOpen}
        title="Dodaj ucznia do klasy"
        content={
          <AddUserToClassModalContent
            onSuccess={() => {
              refetch();
              setAddUserToClassModalOpen(false);
              toast.success("Dodano ucznia do klasy");
            }}
            classId={classId}
          />
        }
      />
    </div>
  ) : null;
};

export default ClassPage;
