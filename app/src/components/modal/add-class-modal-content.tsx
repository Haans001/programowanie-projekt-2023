"use client";

import type { AddClassRequestBody } from "@/api/class-api";
import { _addClass } from "@/api/class-api";
import { useAxios } from "@/hooks/use-axios";
import { useMutation } from "@tanstack/react-query";
import { Formik } from "formik";
import Button from "../button";
import { TextInputField } from "../forms";
import TextAreaField from "../forms/text-area-field";

interface Props {
  onSuccess: () => void;
}

const AddClassModalContent: React.FunctionComponent<Props> = ({
  onSuccess,
}) => {
  const axios = useAxios();

  const { isLoading, mutate: addClass } = useMutation({
    mutationFn: (data: AddClassRequestBody) => _addClass(axios, data),
    onSuccess,
  });

  return (
    <Formik
      initialValues={{
        name: "",
        description: "",
      }}
      onSubmit={addClass}
    >
      {({ handleSubmit }) => (
        <form onSubmit={handleSubmit} className="flex flex-col gap-4 mt-4">
          <TextInputField name="name" placeholder="Nazwa" />
          <TextAreaField name="description" placeholder="Opis" />
          <Button disabled={isLoading} type="submit">
            Dodaj
          </Button>
        </form>
      )}
    </Formik>
  );
};

export default AddClassModalContent;
