import { cn } from "@/helpers/cn";
import { useField } from "formik";

interface TextInputFieldProps
  extends React.InputHTMLAttributes<HTMLInputElement> {
  name: string;
}

const TextInputField: React.FunctionComponent<TextInputFieldProps> = ({
  name,
  className,
  ...props
}) => {
  const [field, meta] = useField(name);

  const shouldShowError = meta.touched && meta.error;

  return (
    <>
      <input
        type="text"
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

export default TextInputField;
