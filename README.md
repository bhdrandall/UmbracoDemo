# Ben Randall - UmbracoDemo

## Setup Process

### Database
The appsettings.json points at an mssql localdb named "UmbracoDemo"    
`"umbracoDbDSN": "Server=(localdb)\\MSSQLLocalDB;Database=UmbracoDemo;Integrated Security=true",`   
This will need to be created/updated before starting the project

### Starting Umbraco
This project can be started using either the terminal or from Visual Studio.
1. Open a terminal and navigate to the project directory.
2. Run the following command to restore the NuGet packages:
 - dotnet restore
3. Start the application using:
 - dotnet run
4. Open your browser and navigate to `http://localhost:44371`.
5. Complete the umbraco installation process with the database of choice.

### Importing uSync Files
1. Navigate to the backoffice and log in with the created user
2. Navigate to Settings -> uSync
3. Select Import Everything

### (Dev) Starting Webpack
This is not necessary to run webpack as the built styles are source controlled
1. Open a new terminal window and navigate to the project directory.
2. Install the necessary npm packages if you haven't done so:
 - npm install
3. Start Webpack to build the styles:
 - npm run build
(optional) Start Webpack watch:
 - npm run start

---
---

## Project Overview
I have created an Umbraco 13 demo project with 4 types of pages (Home, Contact, Generic Text, Search) and integration with the Spaceflight News Api (https://api.spaceflightnewsapi.net/v4/docs/) on the Home page.

---

### Considerations on the API integration - Questions

Question: The client has come back and said the images are slow to load, what can you do to improve the implementation and improve page load?    

Answer: I have installed an imagesharp remote provider that allows for all of the built in imagesharp functions of Umbraco 13 to work with remote images: (https://github.com/skttl/ImageSharpCommunity.Providers.Remote/blob/main/umbraco-marketplace-readme.md).  
The "_SpaceflightCards.cshtml" partial is using this to resolve the Spaceflight API's images and adjust the quality of the images to allow for faster rendering speeds. This can be adjusted to reduce the quality of the images and also resize the image resolution if needed.   
(I am using the imagesharp tag helper)     
```<img src="@remoteUri" alt="@article.Title" imagesharp-quality="50" imagesharp-height="300" imagesharp-width="400"/>```

---

Question: The API is now rate limited to 1 call per second, what modifications can be made to make sure that this doesn’t impact the front end?     

Answer: The "SpaceflightApiService.cs" service is loading the API response into the runtime cache with a 5 minute expiration timeout. This means that even if the API was limited to 1 call per second, the service will only request data every 5 minutes at minimum, so this would not be a problem. This cache timeout duration can be modified to whatever is deemed necessary.

---

Question: The client has come back with an urgent change to the API, how would you approach that?    

Answer: The first step would be to identify what has changed, compared to how the API was when it was functioning.
In this example I would navigate to the swagger docs for the API (else hit the API with something like Postman) and have a look at the data to make sure it matches the model that I have for the API response in "SpaceflightAPIResponse.cs". If there are changes, it would be simple to update the model with the new shape.   
If the changes to the API are more extensive, then further modifications may be necessary, such as implementing an Auth token or similar.