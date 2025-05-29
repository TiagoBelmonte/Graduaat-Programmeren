const { validationResult } = require("express-validator");
const prisma = require("../config/prisma");

const TransactionsController = {
  getAll: async (req, res) => {
    // TODO: Implementeer getAll controller
    //  - Haal de userId uit het request object (reqUserId), dit wordt in het request object gezet in de auth_middleware
    const reqUserId = req.params;
    //  - Zoek de transactions uit de databank met de volgende Prisma query:
    const transactions = await prisma.transaction.findMany({
      where: {
        userId: reqUserId,
      },
      orderBy: {
        date: "desc",
      },
      include: {
        category: true,
      },
    });
    //  - Stuur de transactions terug als response
    //  - Vergeet geen foutenafhandeling en de gepaste statuscode terug te sturen
    if (transactions) {
      return res.json(transactions);
    } else {
      return res.status(404).json({ msg: "Geen transacties gevonden" });
    }
  },
  create: async (req, res) => {
    // TODO: Implementeer create controller
    //  - Vergeet niet het validatie resultaat te checken
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
      return res.status(400).json(errors.array());
    }

    //  - Haal de "categoryId, type, amount, description, date" uit het request object (body, params, query)
    //  - Haal de userId uit het request object (reqUserId), dit wordt in het request object gezet in de auth_middleware
    const categorie = req.body;
    const reqUserId = req.params;
    //  - Zoek de category uit de databank met de volgende Prisma query:
    const category = await prisma.category.findUnique({
      where: {
        id: Number.parseInt(categorie.categoryId),
      },
    });
    //  - Als er geen category bestaat met deze id, stuur dan een response terug met de gepaste statusCode - Niet gevonden
    if (!category) {
      return res.status(404).json({ msg: "Niet gevonden" });
    }
    //  - Maak een nieuwe transaction aan met de volgende Prisma query:
    const createdTransaction = await prisma.transaction.create({
      data: {
        type,
        amount,
        month: new Date().getMonth() + 1,
        year: new Date().getFullYear(),
        description,
        date: date !== "" ? new Date(date) : undefined,
        category: {
          connect: {
            id: category.id,
          },
        },
        user: {
          connect: {
            id: reqUserId,
          },
        },
      },
    });
    //  - Stuur de pas aangemakte transaction terug als response samen met de gepaste statusCode
    //  - Vergeet geen foutenafhandeling en de gepaste statuscode terug te sturen
    if (createdTransaction) {
      return res.json(createdTransaction);
    } else {
      return res.status(401).json({ msg: "Geen transaction kunnen aanmaken" });
    }
  },
};

module.exports = TransactionsController;
