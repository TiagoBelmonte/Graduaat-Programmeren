const express = require("express");
const authMiddleware = require("../middlewares/auth_middleware");
const CategoriesController = require("../controllers/categories_controller");
const CategoryValidators = require("../validators/category_validator");
const router = express.Router();

// TODO: Beveilig deze routes
//  - Gebruik de authMiddleware op router level
router.use(authMiddleware);
// TODO: Implementeer / route (GET)
//  - Gebruik de getAll methode vanuit de CategoriesController
router.get("/", CategoriesController.getAll);
// TODO: Implementeer /:id route (DELETE)
//  - Gebruik de delete validator vanuit de CategoryValidators en de delete methode vanuit de CategoriesController
router.delete("/:id", CategoryValidators.delete, CategoriesController.delete);
module.exports = router;
