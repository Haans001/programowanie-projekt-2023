"use client";
import Button from "@/components/button";
import { TextInputField } from "@/components/forms";
import { Field, FieldArray, Formik } from "formik";
import * as Yup from "yup";

const emptyQuestion = {
  question: "",
  answers: ["", "", "", ""],
  correctAnswer: 0,
};

type Question = {
  question: string;
  answers: string[];
  correctAnswer: number;
};

type Values = {
  name: string;
  questions: Question[];
};

const QuizForm = () => {
  const initialValues = {
    name: "",
    questions: [emptyQuestion],
  };

  const handleSubmit = (values: Values) => {
    // Handle form submission
    console.log(values);
  };

  const validationSchema = Yup.object().shape({
    name: Yup.string().required("Nazwa quizu jest wymagana"),
    questions: Yup.array().of(
      Yup.object().shape({
        question: Yup.string().required("Treść pytania jest wymagana"),
        answers: Yup.array()
          .of(Yup.string().required("Odpowiedź jest wymagana"))
          .min(4, "At least two answers are required")
          .required("Answers are required"),
      })
    ),
  });

  return (
    <div>
      <h1 className="text-3xl font-bold mb-10">Dodaj quiz</h1>
      <Formik
        initialValues={initialValues}
        onSubmit={handleSubmit}
        validationSchema={validationSchema}
      >
        {({ values, setFieldValue, handleSubmit }) => (
          <form onSubmit={handleSubmit}>
            <TextInputField
              name="name"
              placeholder="Nazwa quizu..."
              className="w-full"
            />

            <FieldArray name="questions">
              {({ push, remove }) => (
                <>
                  <div className="flex justify-between mt-4 items-center">
                    <p className="my-4 text-gray-700 text-sm">Lista pytań:</p>
                    <Button
                      onClick={() => push(emptyQuestion)}
                      className="self-start"
                      variant="secondary"
                      type="button"
                    >
                      Dodaj Pytanie +
                    </Button>
                  </div>
                  <div className="flex flex-col gap-6">
                    {values.questions.map((question, questionIndex) => (
                      <div
                        key={questionIndex}
                        className="p-4 bg-white rounded-md border border-solid border-gray-300"
                      >
                        <TextInputField
                          placeholder="Treść pytania..."
                          id={`questions.${questionIndex}.question`}
                          name={`questions.${questionIndex}.question`}
                          className="w-full"
                        />
                        <div className="mt-4">
                          <label>Odpowiedzi:</label>
                          <div className="flex flex-col gap-4 mt-2">
                            {question.answers.map((answer, answerIndex) => (
                              <div key={answerIndex} className="flex gap-4">
                                <Field
                                  type="radio"
                                  id={`questions.${questionIndex}.answers.${answerIndex}`}
                                  name={`questions.${questionIndex}.correctAnswer`}
                                  checked={
                                    values.questions[questionIndex]
                                      .correctAnswer === answerIndex
                                  }
                                  onChange={() =>
                                    setFieldValue(
                                      `questions.${questionIndex}.correctAnswer`,
                                      answerIndex
                                    )
                                  }
                                />
                                <div className="w-full">
                                  <TextInputField
                                    className="w-full"
                                    placeholder={`Odpowiedź ${
                                      answerIndex + 1
                                    }...`}
                                    id={`questions.${questionIndex}.answers.${answerIndex}`}
                                    name={`questions.${questionIndex}.answers.${answerIndex}`}
                                  />
                                </div>
                              </div>
                            ))}
                          </div>
                        </div>
                        <div>
                          <button
                            className="mt-4 text-red-500 cursor-pointer"
                            type="button"
                            onClick={() =>
                              values.questions.length > 1 &&
                              remove(questionIndex)
                            }
                          >
                            Usuń pytanie
                          </button>
                        </div>
                      </div>
                    ))}
                  </div>
                </>
              )}
            </FieldArray>
            <Button type="submit" className="mt-10">
              Zatwierdź i dodaj quiz
            </Button>
          </form>
        )}
      </Formik>
    </div>
  );
};

export default QuizForm;
