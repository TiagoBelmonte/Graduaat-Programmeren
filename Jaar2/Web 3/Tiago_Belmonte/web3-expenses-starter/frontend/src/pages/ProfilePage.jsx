import React from "react";
import StyledButton from "../components/StyledButton";
import StyledInput from "../components/StyledInput";
import TitleLabel from "../components/TitleLabel";
import { useFormik } from "formik";
import * as Yup from "yup";
import useAuth from "../contexts/AuthContextProvider";
import { useNavigate } from "react-router-dom";
import { param } from "../../../backend/routes/auth";

const validationSchema = Yup.object().shape({
  password: Yup.string().required("Wachtwoord is verplicht!").min(8),
});

const ProfilePage = () => {
  // TODO: Haal de logout methode, de changePassword methode en het user object uit de useAuth hook
  const { logout, changePassword, user } = useAuth();
  // TODO: Gebruik de correcte hook om te kunnen navigeren in deze component
  const navigate = useNavigate();

  const { values, errors, handleSubmit, handleBlur, handleChange } = useFormik({
    initialValues: {
      password: "",
    },
    onSubmit: async (values) => {
      // TODO: Gebruik de changePassword methode met het password als parameter
      changePassword(values.password);
      //  - Gebruik de navigate methode vanuit de hook die deze pagina herlaadt - TIP 0 meegeven
      navigate("/profile", 0);
      //  - Vergeet niet de foutenafhandeling
    },
    validationSchema: validationSchema,
  });

  return (
    <div className="text-white flex flex-col justify-between h-full">
      <div>
        <h1 className="font-black text-2xl">{user.name}</h1>
        <TitleLabel>Wachtwoord</TitleLabel>
        <StyledInput
          type="password"
          placeholder="Nieuw wachtwoord"
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
          Verander wachtwoord
        </StyledButton>
      </div>
      <StyledButton
        onClick={
          // TODO: Roep hier de logout methode op of geef deze mee
          logout(param)
        }
      >
        Uitloggen
      </StyledButton>
    </div>
  );
};

export default ProfilePage;
