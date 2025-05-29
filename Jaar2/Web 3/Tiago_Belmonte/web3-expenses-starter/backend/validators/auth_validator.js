const { body } = require("express-validator");

const AuthValidators = {
  login: [
    body("email")
      .isEmail()
      .withMessage("Geen geldig email adres")
      .normalizeEmail(),
    body("password").isString().notEmpty(),
  ],
  register: [
    body("name")
      .isString()
      .notEmpty()
      .withMessage("Naam moet ingevuld zijn")
      .trim(),
    body("email")
      .isEmail()
      .withMessage("Geen geldig email adres")
      .normalizeEmail(),
    body("password")
      .isStrongPassword({
        minLength: 8,
        minNumbers: 1,
        minSymbols: 1,
        minUppercase: 1,
      })
      .withMessage(
        "Wachtwoord moet minstens uit 8 karakters bestaan waarvan minstens 1 hoofdletter, 1 speciaal symbool en 1 cijfer."
      ),
  ],
  resetPassword: [
    body("password")
      .isStrongPassword({
        minLength: 8,
        minNumbers: 1,
        minSymbols: 1,
        minUppercase: 1,
      })
      .withMessage(
        "Wachtwoord moet minstens uit 8 karakters bestaan waarvan minstens 1 hoofdletter, 1 speciaal symbool en 1 cijfer."
      ),
  ],
};

module.exports = AuthValidators;
