import { startAsync, makeRedirectUri } from "expo-auth-session";

const clientId =
  "613733732607-18bpkvpnlua54p4demjluaqlv4rc1ni3.apps.googleusercontent.com";

export async function loginWithGoogle() {
  const redirectUri = "https://auth.expo.io/@tiagobelmonte/PersonalAssistant";

  const authUrl =
    "https://accounts.google.com/o/oauth2/v2/auth?" +
    `client_id=${clientId}` +
    `&redirect_uri=${encodeURIComponent(redirectUri)}` +
    `&response_type=token` +
    `&scope=${encodeURIComponent(
      "https://www.googleapis.com/auth/calendar.readonly profile email"
    )}`;

  const result = await startAsync({
    authUrl,
    returnUrl: redirectUri,
  });

  if (result.type === "success" && result.params?.access_token) {
    return result.params.access_token;
  }

  throw new Error("Login mislukt");
}
