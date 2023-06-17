interface Props {
  title: string;
  description: string;
  children: React.ReactNode;
}

const Card: React.FunctionComponent<Props> = ({
  title,
  children,
  description,
}) => (
  <div className="rounded-lg p-4 bg-white">
    <h1 className="text-xl font-bold">{title}</h1>
    <p className="text-sm">{description}</p>
    <div className="mt-4">{children}</div>
  </div>
);

export default Card;
