import { useFormik } from "formik";
import React from "react";
import * as YUP from "yup";

const vakken = [
  { id: 1, vak: "Web1" },
  { id: 2, vak: "Web2" },
  { id: 3, vak: "Web3" },
];

//Validatie schema aanmaken

const validationSchema = YUP.object().shape({
  name: YUP.string().required(),
  age: YUP.number().positive().integer().required().min(18).max(99),
  course: YUP.string().oneOf(vakken.map((c) => c.values)),
  gender: YUP.string().oneOf(["male", "female"]),
});

const AddParkingFormikPage = () => {
  const { values, handleChange, handleSubmit, setFieldValue, errors } =
    useFormik({
      initialValues: {
        name: "",
        age: 0,
        course: "",
        gender: "",
      },
      onSubmit: (values) => {
        console.log(values);

        //POST request
      },
      validationSchema: validationSchema,
    });

  return (
    <div>
      <form onSubmit={handleSubmit} method="GET">
        <label htmlFor="firstName">Naam:</label>
        <input
          id="firstName"
          className="px-4 py-2 border rounded-md block"
          type="text"
          placeholder="Naam"
          required
          name="name"
          value={values.name}
          onChange={handleChange}
        />
        <p>{errors.name}</p>
        <input
          name="age"
          className="px-4 py-2 border rounded-md block"
          type="number"
          placeholder="Leeftijd"
          value={values.age}
          onChange={handleChange}
        />
        <p>{errors.age}</p>
        <select
          name="course"
          value={values.course}
          onChange={handleChange}
          className="block px-4 py-2 border rounded-md"
        >
          {vakken.map((p) => (
            <option key={p.id}>{p.vak}</option>
          ))}
        </select>
        <p>{errors.course}</p>

        <div>
          <input
            type="radio"
            name="gender"
            id="genderMale"
            className="block w-4 h-4"
            checked={values.gender === "male"}
            //value="male"
            onChange={() => {
              setFieldValue("gender", "male");
            }}
          />
          <label htmlFor="genderMale">Male</label>
          <input
            type="radio"
            name="gender"
            id="genderFemale"
            className="block w-4 h-4"
            checked={values.gender === "female"}
            //value="female"
            onChange={() => {
              setFieldValue("gender", "female");
            }}
          />
          <label htmlFor="genderFemale">Female</label>
        </div>
        <p>{errors.gender}</p>
        <button type="submit" className="block px-4 py-2 border rounded-md">
          Verstuur
        </button>
      </form>
    </div>
  );
};

export default AddParkingFormikPage;
