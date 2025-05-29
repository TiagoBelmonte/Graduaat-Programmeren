const jwt = require("jsonwebtoken");

const authMiddleware = async (req, res, next) => {
  // TODO: Implementeer authMiddleware
  //  - Haal de cookies uit het request object
  //  - Haal de token uit de cookie - dezelfde naam van de cookie die je aangemaakt hebt bij login
  //  - Check of deze token bestaat en anders stuur de gepaste statusCode terug
  //  - Verifieer de token en steek dit in een payload variabele.
  //  - Steek een userId property in het request object en wijs hier de payload.sub waarde aan toe OPGELET MOET VAN HET TYPE NUMBER ZIJN (TIP parseInt)
  //  - Zorg ervoor dat de middleware verder gaat met een methode die je moet oproepen
  //  - Vergeet geen foutenafhandeling en de gepaste statuscode(s) terug te sturen
  const cookies = req.cookies;

  if (cookies) {
    const token = cookies.acces_token;

    if (token) {
      try {
        const payload = jwt.verify(token, process.env.JWT_SECRET);
        req.userId.ParseInt = payload.sub;
        next();
      } catch (error) {
        return res.sendStatus(401);
      }
    }
  }
  res.sendStatus(401);
};

module.exports = authMiddleware;
