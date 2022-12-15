# Restaurant

- Steps to perform for Configuring Identity Provider
  1. Register two application in Azure, one for the Web API, and one for the React APP
  1. Configure the redirect URL for both apps (Example: https://localhost:7138/swagger/oauth2-redirect.html - for API, and http://localhost:3000/ for React)
  1. Add two scope to the Web API application: "Swagger", "readwrite"	
  1. Give "Swagger" permission and "User.Read" (Microsoft.Graph) to the Web API, and grant admin consent
  1. Give "readwrite" permission and "User.Read" (Microsoft.Graph) to the React APP, and grant admin consent
  1. Expose the API to the react APP (Add client APP) in Azure.
  1. Configure environment variable in ""application.json" (Restaurant.API project) - instance, domain, tenantId, clientId properties, regarding to the register Web API in Azure
  1. Add the "Swagger" scope in Program.cs inside the configuration for "OpenApiOAuthFlow".
  1. Configure environment variable in "Environment.ts" (Restaurant.React/src project) - CLIENT_ID, TENANT_ID, READWRITE_SCOPE, regarding to the registered React APP in Azure.

- Step for configuring the database
  1. Create new (local or on a server) a SQL Server database
  1. Use the database project to do a schema compare and populate the database with the required tables
  1. Setup the database connection string in "applicaiton.json" (Restaurant.API project) - ConnectionStrings:DefaultConnection property.

- If needed perform "npm install" for the React APP.
- Both application can be started directly from Visual Studio.
- To add menu products, you can use the Swagger endpoint, or directly add them to the table in the database.
- Once logged in, and once the permissions are accepted, you can use the APP and the API.

Check the screenshot for details, and do not forget to create user in the Azure AD.
