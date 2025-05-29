const { body, param } = require("express-validator");

const TransactionValidators = {
  create: [
    body("type")
      .exists()
      .withMessage("Type is verplicht")
      .isString()
      .notEmpty()
      .withMessage("Type kan niet leeg zijn")
      .isIn(["EXPENSE", "INCOME"])
      .withMessage("Dit moet ofwel EXPENSE of INCOME zijn"),
    body("amount")
      .exists()
      .withMessage("Amount is verplicht")
      .isInt({
        gt: 0,
      })
      .withMessage("Moet een getal zijn groter dan 0"),
    body("description")
      .isString()
      .exists()
      .withMessage("Beschrijving is verplicht!")
      .notEmpty()
      .withMessage("Beschrijving kan niet leeg zijn"),
    body("categoryId")
      .exists()
      .withMessage("Categorie moet geselecteerd worden")
      .isInt({
        gt: 0,
      })
      .withMessage("Moet een id groter dan 0 zijn."),
  ],
};

module.exports = TransactionValidators;
