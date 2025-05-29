import React from "react";
import StyledInput from "../components/StyledInput";
import StyledButton from "../components/StyledButton";
import { useFormik } from "formik";
import { useNavigate } from "react-router-dom";
import useAuth from "../contexts/AuthContextProvider";

const LoginPage = () => {
  // TODO: Gebruik de correcte hook om te kunnen navigeren
  const navigate = useNavigate();
  // TODO: Haal de login methode uit de useAuth hook
  const { login } = useAuth();
  const { values, errors, handleSubmit, handleBlur, handleChange } = useFormik({
    initialValues: {
      email: "",
      password: "",
    },
    onSubmit: ({ email, password }) => {
      // TODO: Roep hier de login methode op met email, password en de navigate methode als parameters
      login(email, password);
    },
  });

  return (
    <div className="min-h-screen flex flex-col bg-zinc-900 p-8 justify-center items-center">
      <div className=" bg-zinc-950 rounded-3xl p-8 text-white w-3/4">
        <h1 className="font-black text-3xl text-center mb-8">Inloggen</h1>
        <StyledInput
          type="text"
          placeholder="Email"
          name="email"
          // TODO: Koppel de value, de onChange en de onBlur vanuit Formik met de overeenstemmende attributen
          // - TIP kijk naar het name attribuut hier
          value={values.email}
          onChange={handleChange}
          onBlur={handleBlur}
          error={errors.email !== undefined}
          errorLabel={errors.email}
        />
        <StyledInput
          type="password"
          placeholder="Wachtwoord"
          name="password"
          // TODO: Koppel de value, de onChange en de onBlur vanuit Formik met de overeenstemmende attributen
          // - TIP kijk naar het name attribuut hier
          value={values.password}
          onChange={handleChange}
          onBlur={handleBlur}
          error={errors.password !== undefined}
          errorLabel={errors.password}
        />
        <StyledButton
          type="submit"
          // TODO: Koppel de handleSubmit van Formik aan het onClick attribuut
          onClick={handleSubmit}
        >
          Inloggen
        </StyledButton>
      </div>
    </div>
  );
};

export default LoginPage;
