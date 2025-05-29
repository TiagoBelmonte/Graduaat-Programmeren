const express = require("express");
const authMiddleware = require("../middlewares/auth_middleware");
const TransactionsController = require("../controllers/transactions_controller");
const TransactionValidators = require("../validators/transaction_validator");
const router = express.Router();

// TODO: Beveilig deze routes
//  - Gebruik de authMiddleware op router level
router.use(authMiddleware);
// TODO: Implementeer / route (GET)
//  - Gebruik de getAll methode vanuit de TransactionsController
router.get("/", TransactionsController.getAll);
// TODO: Implementeer / route (POST)
//  - Gebruik de create validator vanuit de TransactionValidators en de create methode vanuit de TransactionsController
router.post("/", TransactionValidators.create, TransactionsController.create);
module.exports = router;
