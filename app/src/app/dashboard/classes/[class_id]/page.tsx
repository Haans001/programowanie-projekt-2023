"use client";
import { _getClass } from "@/api/class-api";
import { _getClassQuizzes } from "@/api/quiz-api";
import Button from "@/components/button";
import Card from "@/components/card";
import AddUserToClassModalContent from "@/components/modal/add-user-to-class-modal-content";
import BaseModal from "@/components/modal/base-modal";
import { pages } from "@/helpers/pages";
import { useAxios } from "@/hooks/use-axios";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import type { NextPage } from "next";
import Link from "next/link";
import { useParams } from "next/navigation";
import * as React from "react";
import { toast } from "react-toastify";
import { _closeQuiz, _removeQuiz } from "@/api/quiz-api";
import { useAuth } from "@/providers/auth-provider";
import { BsSearch } from "react-icons/bs";

const ClassPage: NextPage = () => {
  const params = useParams();
  const { user } = useAuth();
  const axios = useAxios();

  const classId = Number(params.class_id);

  const [addUserToClassModalOpen, setAddUserToClassModalOpen] =
    React.useState(false);

  const { data: classData, refetch: refetchClass } = useQuery({
    queryKey: ["class"],
    queryFn: () => _getClass(axios, classId),
  });

  const { data: quizData, refetch: refetchQuizzes } = useQuery({
    queryKey: ["classQuizes"],
    queryFn: () => _getClassQuizzes(axios, classId),
  });

  const { mutate: closeQuiz } = useMutation({
    mutationFn: (id: number) => _closeQuiz(axios, id),
    onSuccess: (id) => {
      console.log(id);
      refetchQuizzes();
    },
    onError: (error) => {
      console.log(error);
    },
  });

  const { mutateAsync: removeQuiz } = useMutation({
    mutationFn: (id: number) => _removeQuiz(axios, id),
    onSuccess: (id) => {
      console.log(id);
      refetchQuizzes();
    },
    onError: (error) => {
      console.log(error);
    },
  });

  const students = classData?.usersDtos ?? [];

  const quizes = quizData ?? [];

  const [searchQuizInput, setSearchQuizInput] = React.useState("");
  const [filteredQuizData, setFilteredQuizData] = React.useState(quizes);

  const [searchStudentInput, setSearchStudentInput] = React.useState("");
  const [filteredStudentData, setFilteredStudentData] =
    React.useState(students);

  const handleSearchQuizInput = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchQuizInput(e.target.value);
  };
  const handleSearchStudentInput = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchStudentInput(e.target.value);
  };

  React.useEffect(() => {
    const filteredQuizData = () => {
      const filtered = searchQuizInput
        ? quizes?.filter((item) =>
            item.name.toLowerCase().includes(searchQuizInput.toLowerCase())
          )
        : quizes;
      setFilteredQuizData(filtered);
    };

    filteredQuizData();
  }, [quizes, searchQuizInput]);

  console.log(students);

  React.useEffect(() => {
    const filteredStudentData = () => {
      const filtered = searchStudentInput
        ? students?.filter(
            (item) =>
              item.firstName
                .toLowerCase()
                .includes(searchStudentInput.toLowerCase()) ||
              item.lastName
                .toLowerCase()
                .includes(searchStudentInput.toLowerCase())
          )
        : students;
      setFilteredStudentData(filtered);
    };

    filteredStudentData();
  }, [students, searchStudentInput]);

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
            {user?.roleId == 1 && <Button className="mt-4">Dodaj Quiz</Button>}
          </Link>
        </div>

        <div className=" w-1/4 pt-2 flex items-center">
          <label htmlFor="searchClass" className="sr-only">
            Search
          </label>
          <div className="relative w-full">
            <div className="absolute inset-y-0 left-0 flex items-center pl-3">
              <BsSearch className="w-4 h-4 text-gray-500 dark:text-gray-400" />
            </div>
            <input
              type="text"
              id="searchClass"
              value={searchQuizInput}
              className="bg-gray-50 outline-none border border-gray-300 text-gray-900 text-sm rounded-lg w-full pl-10 p-2 "
              placeholder="Wyszukaj quiz"
              onChange={handleSearchQuizInput}
            />
          </div>
        </div>

        {quizes?.length > 0 ? (
          <div className="grid lg:grid-cols-3 md:grid-cols-2 grid-cols-1 mt-6 gap-4">
            {filteredQuizData?.map((quiz) => (
              <Card title={quiz.name} key={quiz.id}>
                {!quiz.isOpen && (
                  <p className="font-medium text-red-500">
                    Quiz jest zamknięty
                  </p>
                )}
                <div className="flex gap-2">
                  {quiz.isOpen && (
                    <Link href={pages.dashboard.solveQuiz.path + quiz.id}>
                      <Button>Rozpocznij quiz</Button>
                    </Link>
                  )}
                  <Link href={pages.dashboard.scores.path + quiz.id}>
                    <Button variant="secondary">Wyniki</Button>
                  </Link>
                  {quiz.isOpen && (
                    <Button
                      onClick={() => closeQuiz(Number(quiz.id))}
                      variant="danger"
                    >
                      Zamknij quiz
                    </Button>
                  )}
                  {!quiz.isOpen && (
                    <Button
                      onClick={() => removeQuiz(Number(quiz.id))}
                      variant="danger"
                    >
                      Usun quiz
                    </Button>
                  )}
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
          {user?.roleId == 1 && (
            <Button
              className="mt-4"
              onClick={() => setAddUserToClassModalOpen(true)}
            >
              Dodaj Ucznia
            </Button>
          )}
        </div>

        <div className=" w-1/4 pt-2 flex items-center">
          <label htmlFor="searchClass" className="sr-only">
            Search
          </label>
          <div className="relative w-full">
            <div className="absolute inset-y-0 left-0 flex items-center pl-3">
              <BsSearch className="w-4 h-4 text-gray-500 dark:text-gray-400" />
            </div>
            <input
              type="text"
              id="searchClass"
              value={searchStudentInput}
              className="bg-gray-50 outline-none border border-gray-300 text-gray-900 text-sm rounded-lg w-full pl-10 p-2 "
              placeholder="Wyszukaj uczniów"
              onChange={handleSearchStudentInput}
            />
          </div>
        </div>

        <div className="mt-6">
          {students.filter((student) => student.roleId == 2).length > 0 ? (
            filteredStudentData.map((student) =>
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
              refetchClass();
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
