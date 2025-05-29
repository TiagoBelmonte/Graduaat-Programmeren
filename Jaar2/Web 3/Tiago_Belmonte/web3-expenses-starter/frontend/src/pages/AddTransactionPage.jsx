import Axios from "axios";
import { useFormik } from "formik";
import { React, useState, useEffect } from "react";
import TitleLabel from "../components/TitleLabel";
import StyledInput from "../components/StyledInput";
import StyledButton from "../components/StyledButton";
import * as Yup from "yup";
import { useNavigate } from "react-router-dom";
import api from "../api/categories";
import { addTransaction } from "../api/transactions";

const types = [
  { id: 1, label: "Uitgave", value: "EXPENSE" },
  { id: 2, label: "Inkomsten", value: "INCOME" },
];

const validationSchema = Yup.object().shape({
  type: Yup.string().oneOf(
    ["EXPENSE", "INCOME"],
    "Type moet ofwel EXPENSE zijn ofwel INCOME"
  ),
  description: Yup.string().required("Beschrijving is verplicht"),
  amount: Yup.number().required("Bedrag is verplicht in te vullen!"),
});

const AddTransactionPage = () => {
  // TODO: Maak een categories state aan - initieël lege array
  const [categories, setCategories] = useState([]);
  // TODO: Gebruik de gepaste hook om te navigeren
  const navigate = useNavigate();

  // TODO:  Gebruik de getAllCategories methode en steek dit in de juiste structuur zodanig dat deze code enkel uitvoert bij het mounten van de component
  //        Steek het resultaat van de getAllCategories in de categories state - TIP Axios response
  //        Vergeet geen foutenafhandeling toe te passen - dit mag in de console gelogd worden
  useEffect(() => {
    (async () => {
      try {
        const response = await Axios.get(api.getAllCategories);
        setCategories(response.data);
      } catch (error) {
        console.error(error);
      }
    })();
  }, []);

  const { values, errors, handleBlur, handleChange, handleSubmit } = useFormik({
    initialValues: {
      type: types[0].value,
      amount: "",
      description: "",
      date: "",
      categoryId: "",
    },
    onSubmit: async ({ type, amount, description, date, categoryId }) => {
      const newCategoryId = categoryId !== "" ? categoryId : categories[0].id;

      // TODO: Roep de addTransaction methode op met de correcte parameters
      //  - Doe de amount waarde maal 100 (Om in de backend enkel maar integers te kunnen gebruiken),
      // gebruik ook de newCategoryId die hierboven staat als categoryId parameter
      //  - Als de Transaction toegevoegd werd navigeer dan naar de homepagina
      //  - Vergeet de foutenafhandeling niet
      try {
        addTransaction(type, amount, description, date, newCategoryId);
        navigate("/");
      } catch (error) {
        console.log({ error });
      }
    },
    validationSchema,
  });

  return (
    <div>
      <TitleLabel>Nieuwe transactie</TitleLabel>
      <div className="relative w-full my-4">
        <input
          type="date"
          className="bg-zinc-900 rounded-lg px-4 py-2 text-xl  block w-full focus:outline-none dark:[color-scheme:dark]"
          placeholder="Datum"
          name="date"
          value={values.date}
          onChange={handleChange}
          onBlur={handleBlur}
          // TODO: Koppel de value, de onChange en de onBlur vanuit Formik met de overeenstemmende attributen
          // - TIP kijk naar het name attribuut hier
        />
      </div>
      <select
        className="bg-zinc-900 px-4 py-2 rounded-lg w-full focus:outline-none text-xl mb-4"
        name="type"
        // TODO: Koppel de value, de onChange en de onBlur vanuit Formik met de overeenstemmende attributen - TIP kijk naar het name attribuut hier
        value={values.type}
        onChange={handleChange}
        onBlur={handleBlur}
      >
        {/* TODO: Maak voor elk type object in de types array een option element terug met de value gekoppeld vanuit het object en als child toon je de label van deze type  */}
      </select>
      <select
        className="bg-zinc-900 px-4 py-2 rounded-lg w-full focus:outline-none text-xl"
        name="categoryId"
        // TODO: Koppel de value, de onChange en de onBlur vanuit Formik met de overeenstemmende attributen - TIP kijk naar het name attribuut hier
        value={values.categoryId}
        onChange={handleChange}
        onBlur={handleBlur}
      >
        {/* TODO: Maak voor elk category object in de categories array een option element terug met de id als value gekoppeld vanuit het object en als child toon je de name van deze category  */}
      </select>
      <StyledInput
        type="number"
        placeholder="Bedrag"
        name="amount"
        // TODO: Koppel de value, de onChange en de onBlur vanuit Formik met de overeenstemmende attributen - TIP kijk naar het name attribuut hier
        value={values.amount}
        onChange={handleChange}
        onBlur={handleBlur}
        error={errors.amount !== undefined}
        errorLabel={errors.amount}
      />
      <StyledInput
        type="text"
        placeholder="Beschrijving"
        name="description"
        // TODO: Koppel de value, de onChange en de onBlur vanuit Formik met de overeenstemmende attributen - TIP kijk naar het name attribuut hier
        value={values.description}
        onChange={handleChange}
        onBlur={handleBlur}
        error={errors.description !== undefined}
        errorLabel={errors.description}
      />
      <StyledButton
        type="submit"
        // TODO: Koppel de handleSubmit van Formik aan het onClick attribuut
        onClick={handleSubmit}
      >
        Maak aan
      </StyledButton>
    </div>
  );
};

export default AddTransactionPage;
