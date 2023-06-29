"use client";
import { _getUserClasses } from "@/api/class-api";
import Button from "@/components/button";
import Card from "@/components/card";
import AddClassModalContent from "@/components/modal/add-class-modal-content";
import BaseModal from "@/components/modal/base-modal";
import { pages } from "@/helpers/pages";
import { useAxios } from "@/hooks/use-axios";
import { useQuery } from "@tanstack/react-query";
import type { NextPage } from "next";
import Link from "next/link";
import * as React from "react";
import { useAuth } from "@/providers/auth-provider";
import { BsSearch } from "react-icons/bs";

const ClassesPage: NextPage = () => {
  const [addClassModalOpen, setAddClassModalOpen] = React.useState(false);

  const { user } = useAuth();
  const axios = useAxios();

  const { data, refetch } = useQuery({
    queryKey: ["classes"],
    queryFn: () => _getUserClasses(axios),
  });

  const [filteredData, setFilteredData] = React.useState(data);
  const [searchInput, setSearchInput] = React.useState("");

  const handleSearchInput = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchInput(e.target.value);
  };

  React.useEffect(() => {
    const filterData = () => {
      const filtered = searchInput
        ? data?.filter((item) =>
            item.name.toLowerCase().includes(searchInput.toLowerCase())
          )
        : data;
      setFilteredData(filtered);
    };

    filterData();
  }, [data, searchInput]);

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
          {user?.roleId == 1 && <Button>Dodaj klase</Button>}
        </BaseModal>
      </div>

      <div className=" w-1/4 pt-2 flex items-center">
        <label htmlFor="searchClass" className="sr-only">
          Search
        </label>
        <div className="relative w-full">
          <div className="absolute inset-y-0 left-0 flex items-center pl-3">
            <BsSearch className="w-4 h-4 text-gray-500 dark:text-gray-400" />
          </div>
          <input
            type="text"
            id="searchClass"
            value={searchInput}
            className="bg-gray-50 outline-none border border-gray-300 text-gray-900 text-sm rounded-lg w-full pl-10 p-2 "
            placeholder="Wyszukaj klase"
            onChange={handleSearchInput}
          />
        </div>
      </div>

      <div className="grid lg:grid-cols-3 md:grid-cols-2 grid-cols-1 mt-6 gap-4">
        {filteredData?.map((c) => (
          <Card title={c.name} description={c.description} key={c.id}>
            <Link href={pages.dashboard.class.path + c.id}>
              <Button>{user?.roleId == 2 ? "Wejdz" : "Edytuj"}</Button>
            </Link>
          </Card>
        ))}
      </div>
    </div>
  );
};
export default ClassesPage;
