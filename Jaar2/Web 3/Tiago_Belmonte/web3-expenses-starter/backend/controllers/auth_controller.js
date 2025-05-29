const { validationResult } = require("express-validator");
const prisma = require("../config/prisma");
const bcrypt = require("bcrypt");

const FIVE_DAYS = 5 * 24 * 60 * 60 * 1000;

const AuthController = {
  login: async (req, res) => {
    // TODO: Implementeer login controller
    //  - Vergeet niet het validatie resultaat te checken
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
      return res.status(400).json(errors.array());
    }
    //  - Haal het email adres en het password uit het request object (body, params, query)
    const reqEmail = req.body.email;
    const reqPaswword = req.body.password;
    //  - Zoek de user uit de databank met de volgende Prisma query:
    if (data) {
      const user = await prisma.user.findUnique({
        where: {
          email: reqEmail,
          password: reqPaswword,
        },
      });
    }
    //  - Vergelijk het password dat binnenkomt uit de request met het gehashte wachtwoord van de gebruiker uit de databank
    //  - Als het niet valid is stuur dan de gepaste statusCode terug
    if (user) {
      return res.status(401).json({ msg: "Inloggegevens niet geldig" });
    }
    //  - Maak een nieuwe JWT token aan met een payload object, de token moet vijf dagen geldig blijven ZIE HIERBOVEN FIVE_DAYS constante:
    const payload = {
      sub: user.id,
      iat: Date.now(),
    };

    // Stel de opties samen
    const options = {
      expiresIn: "5d", // Token vervalt na 5 daggen
    };

    // Genereer de token
    const secretKey = process.env.JWT_SECRET;
    const token = jwt.sign(payload, secretKey, options);
    //  - Stuur de JWT token terug als een server cookie en deze cookie is alsook vijf dagen geldig FIVE_DAYS constante,
    // stuur ook een object terug met de user erin zonder password property.
    return res
      .cookie("acces_token", token, {
        httpOnly: true,
        maxAge: FIVE_DAYS,
      })
      .json({ message: -"Logged in succesfully " });
    //  - Vergeet geen foutenafhandeling en de gepaste statuscode terug te sturen
  },
  verify: async (req, res) => {
    // TODO: Implementeer verify controller
    //  - Haal de userId uit het request object (reqUserId), dit wordt in het request object gezet in de auth_middleware
    const reqUserId = req.acces.reqUserId;
    //  - Zoek de user uit de databank met de volgende Prisma query:
    const user = await prisma.user.findUnique({
      where: {
        id: reqUserId,
      },
    });
    //  - Stuur een object terug met de user erin zonder password property.
    //  - Vergeet geen foutenafhandeling en de gepaste statuscode terug te sturen
    if (user) {
      return res.json(user);
    } else {
      return res.status(401).json({ msg: "validatie niet geldig" });
    }
  },
  resetPassword: async (req, res) => {
    // TODO: Implementeer resetPassword controller
    //  - Vergeet niet het validatie resultaat te checken
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
      return res.status(400).json(errors.array());
    }
    //  - Haal het password uit het request object (body, params, query)
    //  - Haal de userId uit het request object (reqUserId), dit wordt in het request object gezet in de auth_middleware
    const password = req.body;
    const reqUserId = req.acces.id;
    //  - Hash het password (hashedPassword) dat is binnengekomen met de request
    const hashedPassword = await bcrypt.hash(password, 12);
    //  - Update de user uit de databank met de volgende Prisma query:
    await prisma.user.update({
      where: {
        id: reqUserId,
      },
      data: {
        password: hashedPassword,
      },
    });
    //  - Verwijder de cookie uit de response
    // -naam van de cookie moet dezelfde zijn die je genomen hebt bij het inloggen natuurlijk
    // en stuur de volgende tekst terug "Wachtwoord succesvol gewijzigd."
    //  - Vergeet geen foutenafhandeling en de gepaste statuscode terug te sturen
    return res
      .clearCookie("acces_token")
      .status(200)
      .json({ msg: "Wachtwoord succesvol gewijzigd." });
  },
  logout: async (req, res) => {
    // TODO: Implementeer resetPassword controller
    //  - Verwijder de cookie uit de response - naam van de cookie moet dezelfde zijn die je genomen hebt bij het inloggen natuurlijk en stuur enkel de statusCode terug die OK teruggeeft.
    return res.clearCookie("acces_token");
  },
};

module.exports = AuthController;
