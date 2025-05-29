const { body, param } = require("express-validator");

const CategoryValidators = {
  delete: [param("id").isInt().withMessage("Id moet een getal zijn")],
};

module.exports = CategoryValidators;
