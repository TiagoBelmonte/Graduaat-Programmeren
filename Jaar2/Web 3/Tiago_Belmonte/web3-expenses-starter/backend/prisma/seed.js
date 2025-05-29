// prisma/seed.js

const bcrypt = require("bcrypt");

const { PrismaClient } = require("@prisma/client");
const prisma = new PrismaClient();

async function main() {
  // Maak een nieuwe gebruiker aan
  const user = await prisma.user.create({
    data: {
      name: "John Doe",
      email: "john.doe@hogent.be",
      password: bcrypt.hashSync("Wachtwoord123?", 12),
    },
  });

  const userTwo = await prisma.user.create({
    data: {
      name: "Jane Doe",
      email: "jane.doe@hogent.be",
      password: bcrypt.hashSync("Wachtwoord123?", 12),
    },
  });

  console.log("Gebruiker aangemaakt:", user);

  const categories = [
    { name: "Voedsel" },
    { name: "Vervoer" },
    { name: "Huur" },
    { name: "Entertainment" },
    { name: "Gezondheid" },
    { name: "Loon" },
  ];

  const secondCategories = [
    { name: "Voedsel" },
    { name: "Vervoer" },
    { name: "Aflossing lening" },
    { name: "Entertainment" },
    { name: "Gezondheid" },
    { name: "Loon" },
  ];

  const createdCategories = await Promise.all(
    categories.map((category) =>
      prisma.category.create({
        data: {
          name: category.name,
          user: { connect: { id: user.id } },
        },
      })
    )
  );

  await Promise.all(
    secondCategories.map((category) =>
      prisma.category.create({
        data: {
          name: category.name,
          user: { connect: { id: userTwo.id } },
        },
      })
    )
  );

  console.log("Categorieën aangemaakt:", createdCategories);

  const transactions = [
    {
      type: "EXPENSE",
      amount: 5000,
      description: "Boodschappen bij supermarkt",
      month: 1,
      year: 2025,
      date: new Date("2025-01-10"),
      categoryId: createdCategories.find((cat) => cat.name === "Voedsel").id,
    },
    {
      type: "EXPENSE",
      amount: 1500,
      description: "Buskaartje",
      month: 1,
      year: 2025,
      date: new Date("2025-01-12"),
      categoryId: createdCategories.find((cat) => cat.name === "Vervoer").id,
    },
    {
      type: "INCOME",
      amount: 200000,
      description: "Maandsalaris",
      month: 1,
      year: 2025,
      date: new Date("2025-01-05"),
      categoryId: createdCategories.find((cat) => cat.name === "Loon").id,
    },
    {
      type: "EXPENSE",
      amount: 7500,
      description: "Abonnement Netflix",
      month: 1,
      year: 2025,
      date: new Date("2025-01-15"),
      categoryId: createdCategories.find((cat) => cat.name === "Entertainment")
        .id,
    },
    {
      type: "EXPENSE",
      amount: 3000,
      description: "Apotheek medicijnen",
      month: 1,
      year: 2025,
      date: new Date("2025-01-20"),
      categoryId: createdCategories.find((cat) => cat.name === "Gezondheid").id,
    },
    {
      type: "EXPENSE",
      amount: 6000,
      description: "Restaurant diner",
      month: 2,
      year: 2025,
      date: new Date("2025-02-05"),
      categoryId: createdCategories.find((cat) => cat.name === "Voedsel").id,
    },
    {
      type: "EXPENSE",
      amount: 2000,
      description: "Taxi rit",
      month: 2,
      year: 2025,
      date: new Date("2025-02-10"),
      categoryId: createdCategories.find((cat) => cat.name === "Vervoer").id,
    },
    {
      type: "INCOME",
      amount: 200000,
      description: "Maandsalaris",
      month: 2,
      year: 2025,
      date: new Date("2025-02-05"),
      categoryId: createdCategories.find((cat) => cat.name === "Loon").id,
    },
    {
      type: "EXPENSE",
      amount: 8000,
      description: "Spotify abonnement",
      month: 2,
      year: 2025,
      date: new Date("2025-02-15"),
      categoryId: createdCategories.find((cat) => cat.name === "Entertainment")
        .id,
    },
    {
      type: "EXPENSE",
      amount: 2500,
      description: "Sportabonnement",
      month: 2,
      year: 2025,
      date: new Date("2025-02-20"),
      categoryId: createdCategories.find((cat) => cat.name === "Gezondheid").id,
    },
  ];

  const createdTransactions = await Promise.all(
    transactions.map((transaction) =>
      prisma.transaction.create({
        data: {
          type: transaction.type,
          amount: transaction.amount,
          description: transaction.description,
          date: transaction.date,
          month: transaction.month,
          year: transaction.year,
          category: { connect: { id: transaction.categoryId } },
          user: { connect: { id: user.id } },
        },
      })
    )
  );

  console.log("Transacties aangemaakt:", createdTransactions);
}

main()
  .catch((e) => {
    console.error("Fout bij het seeden van de database:", e);
    process.exit(1);
  })
  .finally(async () => {
    await prisma.$disconnect();
  });
