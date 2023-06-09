import { cn } from "@/helpers/cn";
import * as React from "react";

type Props = React.ButtonHTMLAttributes<HTMLButtonElement>;

const Button = React.forwardRef<HTMLButtonElement, Props>(
  ({ className, children, ...rest }, ref) => (
    <button
      className={cn(
        "p-2 rounded-md text-white",
        "bg-blue-700 hover:bg-blue-800",
        "disabled:bg-blue-200",
        className
      )}
      ref={ref}
      {...rest}
    >
      {children}
    </button>
  )
);

export default Button;
