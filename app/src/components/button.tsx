import { cn } from "@/helpers/cn";
import * as React from "react";

type Props = React.ButtonHTMLAttributes<HTMLButtonElement> & {
  variant?: "primary" | "secondary" | "danger";
};

const Button = React.forwardRef<HTMLButtonElement, Props>(
  ({ className, children, variant = "primary", ...rest }, ref) => {
    const buttonClassName = cn(
      "p-2 rounded-md text-white",
      variant === "primary"
        ? "bg-blue-700 hover:bg-blue-800"
        : variant === "secondary"
        ? "bg-gray-500 hover:bg-gray-600"
        : "bg-red-500 hover:bg-red-600",
      "disabled:bg-blue-200",
      className
    );

    return (
      <button className={buttonClassName} ref={ref} {...rest}>
        {children}
      </button>
    );
  }
);

export default Button;
