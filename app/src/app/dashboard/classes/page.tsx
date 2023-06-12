"use client";
import { _getAllClasses } from "@/api/class-api";
import Button from "@/components/button";
import AddClassModalContent from "@/components/modal/add-class-modal-content";
import BaseModal from "@/components/modal/base-modal";
import { pages } from "@/helpers/pages";
import { useAxios } from "@/hooks/use-axios";
import { useQuery } from "@tanstack/react-query";
import type { NextPage } from "next";
import Link from "next/link";
import * as React from "react";

const ClassesPage: NextPage = () => {
  const [addClassModalOpen, setAddClassModalOpen] = React.useState(false);

  const axios = useAxios();

  const { data, refetch } = useQuery({
    queryKey: ["classes"],
    queryFn: () => _getAllClasses(axios),
  });

  return (
    <div>
      <div className="flex justify-between">
        <h1 className="text-3xl font-bold">Moje Klasy</h1>
        <BaseModal
          title="Dodaj klase"
          description="Wprowadź nazwe klasy"
          content={
            <AddClassModalContent
              onSuccess={() => {
                refetch();
                setAddClassModalOpen(false);
              }}
            />
          }
          open={addClassModalOpen}
          setOpen={setAddClassModalOpen}
        >
          <Button>Dodaj klase</Button>
        </BaseModal>
      </div>
      <div className="grid lg:grid-cols-3 md:grid-cols-2 grid-cols-1 mt-6 gap-4">
        {data?.map((c) => (
          <div className="rounded-lg p-4 bg-white">
            <h1 className="text-xl font-bold">{c.name}</h1>
            <p className="text-sm">{c.description}</p>
            <div className="mt-4">
              <Link href={pages.dashboard.class.path + c.id}>
                <Button>Edytuj</Button>
              </Link>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};
export default ClassesPage;
