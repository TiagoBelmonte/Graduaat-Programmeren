const API_KEY = "pub_27e7ee3d2aa3460cb1ace15e2d849f51"; // (dia 148) API key gebruiken voor toegang tot externe data

export async function fetchTopNews() {
  const response = await fetch(
    `https://newsdata.io/api/1/news?apikey=${API_KEY}&language=nl&country=be`
  );
  // (dia 143–144) Gebruik van fetch() API om gegevens op te halen van een externe server

  const json = await response.json(); // (dia 144) Promise response omzetten naar JSON
  return json.results; // (dia 144) Data ophalen uit de response en retourneren
}
