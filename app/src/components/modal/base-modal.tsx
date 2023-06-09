"use client";

import * as Dialog from "@radix-ui/react-dialog";

interface BaseModalProps {
  title: string;
  description: string;
  children: React.ReactNode;
  content: React.ReactNode;
  open?: boolean;
  setOpen?: React.Dispatch<React.SetStateAction<boolean>>;
}

const BaseModal: React.FunctionComponent<BaseModalProps> = ({
  children,
  title,
  description,
  content,
  open,
  setOpen,
}) => (
  <Dialog.Root open={open} onOpenChange={setOpen}>
    <Dialog.Trigger asChild>{children}</Dialog.Trigger>
    <Dialog.Portal>
      <Dialog.Overlay className="bg-black bg-opacity-70 fixed inset-0" />
      <Dialog.Content className="bg-white rounded-lg p-4 focus:outline-none fixed top-[50%] left-[50%] max-h-[85vh] w-[90vw] max-w-[450px] translate-x-[-50%] translate-y-[-50%]">
        <Dialog.Title className="text-black text-xl font-semibold">
          {title}
        </Dialog.Title>
        <Dialog.Description className="text-gray-700 text-lg">
          {description}
        </Dialog.Description>
        {content}
      </Dialog.Content>
    </Dialog.Portal>
  </Dialog.Root>
);

export default BaseModal;
