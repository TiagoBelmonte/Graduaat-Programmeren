const express = require("express");
const AuthValidators = require("../validators/auth_validator");
const AuthController = require("../controllers/auth_controller");
const authMiddleware = require("../middlewares/auth_middleware");
const router = express.Router();

// TODO: Implementeer /login route (POST)
//  - Gebruik de login validator vanuit de AuthValidators en de login methode vanuit de AuthController
router.post("/login", AuthValidators.login, AuthController.login);
// TODO: Implementeer /verify route (GET)
//  - Gebruik de authMiddleware en de verify methode vanuit de AuthController
router.get("/verify", authMiddleware, AuthController.verify);

// TODO: Implementeer /password route (PUT)
//  - Gebruik de authMiddleware en de resetPassword validator vanuit de AuthValidators en de resetPassword methode vanuit de AuthController
router.put(
  "/password",
  authMiddleware,
  AuthValidators.resetPassword,
  AuthController.resetPassword
);
// TODO: Implementeer /logout route (GET)
//  - Gebruik de logout methode vanuit de AuthController
router.get("/logout", AuthController.logout);

module.exports = router;
