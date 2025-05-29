const { validationResult } = require("express-validator");
const prisma = require("../config/prisma");

const CategoriesController = {
  getAll: async (req, res) => {
    // TODO: Implementeer getAll controller
    //  - Haal de userId uit het request object (reqUserId), dit wordt in het request object gezet in de auth_middleware
    const reqUserId = req.params;
    //  - Zoek de category uit de databank met de volgende Prisma query:
    const categories = await prisma.category.findMany({
      where: {
        userId: reqUserId,
      },
    });
    //  - Stuur de categories terug als response
    //  - Vergeet geen foutenafhandeling en de gepaste statuscode terug te sturen
    if (categories) {
      return res.json(categories);
    } else {
      return res.status(404).json({ msg: "Categorien bestaan niet" });
    }
  },
  delete: async (req, res) => {
    // TODO: Implementeer delete controller
    //  - Vergeet niet het validatie resultaat te checken
    //  - Haal de id uit het request object (body, params, query)
    const errors = validationResult(req);

    if (!errors.isEmpty()) {
      return res.status(400).json(errors.array());
    }
    const id = req.params;
    //  - Verwijder de category uit de databank met de volgende Prisma query:
    await prisma.category.delete({
      where: {
        id: Number.parseInt(id),
      },
    });
    //  - Stuur de gepaste statusCode terug
    //  - Vergeet geen foutenafhandeling en de gepaste statuscode terug te sturen
    if (id) {
      return res.status(200);
    } else {
      return res
        .status(404)
        .json({ msg: "Geen categorie gevonden met meegegeven id" });
    }
  },
};

module.exports = CategoriesController;
