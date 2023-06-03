import { IQuizzies } from "@/types";

const Quiz = ({ id, name, subject }: IQuizzies) => {
  return (
    <div className="flex flex-col justify-between  bg-white p-4">
      <div>
        <h2 className="text-xl">{name}</h2>
        <p>{subject}</p>
      </div>
      <button className="w-2/3 px-4 py-1 outline-none bg-[#618cfb] hover:bg-[#426bd3] cursor-pointer font-medium text-white text-md">
        Rozpocznij quiz
      </button>
    </div>
  );
};

export default Quiz;
