# **Todo Web Application with .Net and React**
## Back-end with .Net
### _I used multi-layered architectures while doing this project. The project includes Entities, Data Access, Core, Common, Business and Api layers._
### _While writing the classes and methods within the layers, care was taken to have a single task for each. In this way, the Single Responsibility Principle is also provided._
### _At the same time, dependencies that may occur in the project are prevented by applying dependency injection within the project._

---
## This is the Register page of project.
![Register Page](/images/RegisterPage.PNG)

## This is the Login page of the project.
![Login Page](/images/LoginPage.PNG)

## This is the Todo List from the project.
![Todo List](/images/TodoList.PNG)

---

## Database Connection
### A DatabaseContext class was created in the DataAccess layer to create the database. Here, we use the objects that we want to create in the database. At the same time, fake data was created for the database and the project in the MyInitializer class. For database connection, the database connection address has been added in appsettings.json. These operations have been added to Startup.cs.
### The operations were carried out as seen in the pictures below.

![Connection1](/images/1.PNG)
![Connection2](/images/2.PNG)
![Connection3](/images/3.PNG)

---
## Front-end with React
### React was used on the front end of the project. A Registration and Login screen is designed here. After successful login and registration, the TodoList page is redirected. Two folders, components and services, were created within the project. A connection with the back-end side is provided with axios within the Service. In the Components, there are Login, register and Todo pages and the operations performed there.

### Some packages have been downloaded to be used in the project. These packages and their download commands are given below.
- npm install axios
- npm install react-router-dom
- npm install react-icons
- npm install bootstrap
