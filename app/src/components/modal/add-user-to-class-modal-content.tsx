import type { AddUserToClassRequestBody } from "@/api/class-api";
import { _addUserToClass } from "@/api/class-api";
import { useAxios } from "@/hooks/use-axios";
import { useMutation } from "@tanstack/react-query";
import { Formik } from "formik";
import Button from "../button";
import { TextInputField } from "../forms";

interface Props {
  classId: number;
  onSuccess: () => void;
}

const AddUserToClassModalContent: React.FunctionComponent<Props> = ({
  classId,
  onSuccess,
}) => {
  const axios = useAxios();

  const { isLoading, mutate: addClass } = useMutation({
    mutationFn: (data: AddUserToClassRequestBody) =>
      _addUserToClass(axios, data),
    onSuccess,
  });

  return (
    <Formik
      initialValues={{
        email: "",
        classId,
      }}
      onSubmit={addClass}
    >
      {({ handleSubmit }) => (
        <form onSubmit={handleSubmit} className="flex flex-col gap-4 mt-4">
          <TextInputField name="email" type="email" placeholder="Email..." />
          <Button disabled={isLoading} type="submit">
            Dodaj ucznia do klasy
          </Button>
        </form>
      )}
    </Formik>
  );
};

export default AddUserToClassModalContent;
