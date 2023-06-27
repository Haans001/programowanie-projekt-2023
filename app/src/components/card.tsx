import { cn } from "@/helpers/cn";

interface Props {
  title?: string;
  description?: string;
  children?: React.ReactNode;
  className?: string;
}

const Card: React.FunctionComponent<Props> = ({
  title,
  children,
  description,
  className,
}) => (
  <div className={cn("rounded-lg p-4 bg-white", className)}>
    {title ? <h1 className="text-xl font-bold">{title}</h1> : null}
    <p className="text-sm">{description}</p>
    <div className="mt-4">{children}</div>
  </div>
);

export default Card;
