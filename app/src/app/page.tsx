"use client";
import { Field, Form, Formik } from "formik";
import * as React from "react";

interface WeatherForecastItem {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

export default function Home() {
  const [data, setData] = React.useState<WeatherForecastItem[]>([]);

  React.useEffect(() => {
    fetch(process.env.NEXT_PUBLIC_API_URL + "/WeatherForecast")
      .then((response) => response.json())
      .then((data) => setData(data));
  }, []);

  return (
    <div className="m-6">
      <Formik
        initialValues={{
          firstName: "",
          lastName: "",
          email: "",
        }}
        onSubmit={async (values) => {
          await new Promise((r) => setTimeout(r, 500));
          alert(JSON.stringify(values, null, 2));
        }}
      >
        <Form>
          <label htmlFor="firstName">First Name</label>
          <Field id="firstName" name="firstName" placeholder="Jane" />

          <label htmlFor="lastName">Last Name</label>
          <Field id="lastName" name="lastName" placeholder="Doe" />

          <label htmlFor="email">Email</label>
          <Field
            id="email"
            name="email"
            placeholder="jane@acme.com"
            type="email"
          />
          <button type="submit">Submit</button>
        </Form>
      </Formik>

      <div className="mt-8 flex flex-col gap-6">
        {data?.map((item) => (
          <div
            key={item.date}
            className="border border-solid border-blue-600 rounded-md p-4 flex flex-col gap-2"
          >
            <p className="text-2xl font-bold">{item.summary}</p>
            <span>Farenheit: {item.temperatureF}</span>
            <span>Celcius: {item.temperatureC}</span>
          </div>
        ))}
      </div>
    </div>
  );
}
