# Encoder

• Provide us with your example of the simple SPA with .NET 6 on the backend, and Angular/ReactJS on the front-end. 
On the front-end side user should be able to enter the text into the text field, press "Convert" button, and get this text encoded into the base64 format. 
Encoding should be performed on the backend side. 
Encoded string should be returned to the client one character at time, one by one, and for each returned character there should be random pause on the server 1-5 seconds. 
All received characters should form a string in a UI textbox, hence it will be updated in real-time by adding new incoming characters. 
User cannot start another encoding process while the current one is in progress, but user can press "cancel" button and thus cancel the currently running process.

•	Web page should look neat; use Bootstrap or its derivatives. 

•	Use default IoC, package managers and other tools to build & run the app.

•	Use the latest released .Net & C# with all possible new features they provide.

• Server-side app should be hosted in Linux Docker container.

• Host API & UI backend in different containers.

•	Support basic authentication using nginx in another container.

•	Business logic should be implemented as services, with unit tests for each respectively.



Notes: 

Frontend > https://github.com/crismavictoria/Frontend
