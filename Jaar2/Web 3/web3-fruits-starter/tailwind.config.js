/** @type {import('tailwindcss').Config} */
export default {
  content: ["./index.html", "./src/**/*.{js,jsx,ts,tsx}"],
  theme: {
    extend: {
      colors: {
        "food-black": "#03071e",
        "food-brown": "#370617",
        "food-dark-red": "#9d0208",
        "food-red": "#d00000",
        "food-dark-orange": "#dc2f02",
        "food-orange": "#e85d04",
        "food-amber": "#f48c06",
        "food-yellow": "#ffba08",
      },
    },
  },
  plugins: [],
};
