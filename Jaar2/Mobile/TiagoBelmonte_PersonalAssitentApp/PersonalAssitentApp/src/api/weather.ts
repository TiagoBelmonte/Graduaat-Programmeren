const API_KEY = "13eb8e53136903ce125e85be732e7cea"; // (dia 148) Gebruik van API-sleutel om externe dienst (OpenWeather) aan te spreken

export async function fetchWeatherByCity(city: string) {
  const response = await fetch(
    `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${API_KEY}&units=metric&lang=nl`
  );
  // (dia 143–144) fetch() gebruiken om data op te halen van een externe API (GET request)
  // (dia 147–148) Parameters meegeven in de query (stad, taal, units…)

  return await response.json(); // (dia 144) JSON body omzetten naar bruikbare JavaScript objecten
}

export async function fetchWeatherByCoords(lat: number, lon: number) {
  const response = await fetch(
    `https://api.openweathermap.org/data/2.5/weather?lat=${lat}&lon=${lon}&appid=${API_KEY}&units=metric&lang=nl`
  );
  // (dia 143–144) Zelfde principe, maar met latitude/longitude via GPS
  // (dia 132) GPS-coördinaten worden verkregen via native Location API

  return await response.json(); // (dia 144)
}
