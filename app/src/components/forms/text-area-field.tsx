"use client";
import { cn } from "@/helpers/cn";
import { useField } from "formik";

interface TextAreaFieldProps
  extends React.InputHTMLAttributes<HTMLTextAreaElement> {
  name: string;
}

const TextAreaField: React.FunctionComponent<TextAreaFieldProps> = ({
  name,
  className,
  ...props
}) => {
  const [field, meta] = useField(name);

  const shouldShowError = meta.touched && meta.error;

  return (
    <>
      <textarea
        {...field}
        {...props}
        name={name}
        className={cn(
          "outline-none p-2 border-2 border-gray-200",
          shouldShowError && "border-red-500",
          className
        )}
      />
      {shouldShowError ? (
        <p className="text-sm text-red-500">{meta.error}</p>
      ) : null}
    </>
  );
};

export default TextAreaField;
