import { BsSearch } from "react-icons/bs";
import QuizList from "./QuizList";
import { IQuizzies } from "@/types";
import { ChangeEvent, useState } from "react";

const MainHome = () => {
  //PRZYKLADOWE DANE
  const quizzies: IQuizzies[] = [
    { id: 0, name: "Algorytmy i struktury danych", subject: "Informatyka" },
    { id: 1, name: "Pan Tadeusz", subject: "Język polski" },
    { id: 2, name: "Funkcja kwadratowa", subject: "Matematyka" },
    { id: 3, name: "Równania różniczkowe", subject: "Matematyka" },
    { id: 4, name: "DNA", subject: "Biologia" },
    { id: 5, name: "Programowanie C++", subject: "Informatyka" },
    { id: 6, name: "Lalka", subject: "Język polski" },
    { id: 7, name: "Funkcja liniowa", subject: "Matematyka" },
    { id: 8, name: "Układy równań", subject: "Matematyka" },
    { id: 9, name: "RNA", subject: "Biologia" },
  ];

  const [searchInput, setSearchInput] = useState("");

  const handleSearchInputChange = (e: ChangeEvent<HTMLInputElement>) => {
    setSearchInput(e.target.value);
  };

  return (
    <div className="w-full h-[90%] bg-gray-200">
      <div className="w-[90%] mx-auto p-4">
        <div className=" w-1/3 flex items-center">
          <label htmlFor="searchQuiz" className="sr-only">
            Search
          </label>
          <div className="relative w-full">
            <div className="absolute inset-y-0 left-0 flex items-center pl-3">
              <BsSearch className="w-4 h-4 text-gray-500 dark:text-gray-400" />
            </div>
            <input
              type="text"
              id="searchQuiz"
              value={searchInput}
              className="bg-gray-50 outline-none border border-gray-300 text-gray-900 text-sm rounded-lg w-full pl-10 p-2 "
              placeholder="Wyszukaj quiz"
              onChange={handleSearchInputChange}
              required
            />
          </div>
        </div>
        <QuizList
          quizzies={quizzies.filter(
            (quiz) =>
              quiz.name
                .toLocaleLowerCase()
                .includes(searchInput.toLocaleLowerCase()) ||
              quiz.subject
                .toLocaleLowerCase()
                .includes(searchInput.toLocaleLowerCase())
          )}
        />
      </div>
    </div>
  );
};

export default MainHome;
