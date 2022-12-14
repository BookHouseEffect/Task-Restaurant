import { env } from './Environment'

export const msalConfig = {
  auth: {
    clientId: env.CLIENT_ID,
    authority: `https://login.microsoftonline.com/${env.TENANT_ID}`,
    // This is a URL (e.g. https://login.microsoftonline.com/{your tenant ID})
    redirectUri: env.REDIRECT_URL,
  },
  cache: {
    cacheLocation: "sessionStorage", // This configures where your cache will be stored
    storeAuthStateInCookie: false, // Set this to "true" if you are having issues on IE11 or Edge
  }
};

// Add scopes here for ID token to be used at Microsoft identity platform endpoints.
export const loginRequest = {
  scopes: [
    env.READWRITE_SCOPE
  ]
};

// Add the endpoints here for Microsoft Graph API services you'd like to use.
export const graphConfig = {
  graphMeEndpoint: "https://graph.microsoft.com/v1.0"
};