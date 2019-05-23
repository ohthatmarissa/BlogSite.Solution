<<<<<<< HEAD
# _**Blog Site**_

## _An application which allows users to register, add blog, add posts to the blog, add communities to their blog._

#### _**By Zach Weintraub, Marissa Perry, Zema Kebede, Svitlana Filatova**_

## Description

_This application allows users to register with username and password, add blog, add posts to the blog, add communities to their blog, tomake a search in posts._

## Blog Site Specifications

#### _User Stories_

* _As an unregistered user, I need to be able to register with my username and password. Username and password must be unique._
* _As an unregistered user I need to be able to see blogs and posts. I'm not allowed to edit or delete someones blogs or posts._
* _As an unregistered user I need to be able to see communities._
* _As an unregistered user I need to be able to search for a particular words in posts._
* _As a registered user I need to be able to add a blog._
* _As a registered user I need to be able to edit blog title and description._
* _As a registered user I need to be able to add posts to my blog._
* _As a registered user I need to be able to add an image to my posts._
* _As a registered user I need to be able to edit posts of my blog (title, content)._
* _As a registered user I need to be able to add my blog to any community._
* _As a registered user I need to be able to remove communities form my blog._
* _As a registered user I need to be able to add a new community._







## Setup/Installation Requirements

* _To use this application you need to have .NET (ver. 2.2) Framework and Mono tool installed on your computer (https://dotnet.microsoft.com/download/dotnet-core/2.2)._
* _Clone this repository on your desktop._
* _This application database based. To be able to add information and manage the database you need to install and configure MAMP (see instructions here: https://www.learnhowtoprogram.com/c/database-basics-ee7c9fd3-fcd9-4fff-8b1d-5ff7bfcbf8f0/introducing-and-installing-mamp). After starting Servers you need to connect to the server by using the following command - /Applications/MAMP/Library/bin/mysql --host=localhost -uroot -proot. If all steps were correct you should see this prompt - 'mysql>'._
* _Setup instructions to re-create the database(semicolons are important!):_
  _1. CREATE DATABASE blog_site;_
  _2. USE blog_site;_
  _3. CREATE TABLE blogs (id serial PRIMARY KEY NOT NULL, title VARCHAR(255), about TEXT, username VARCHAR(255), password VARCHAR(255));_
  _4. CREATE TABLE blogs_communities (id serial PRIMARY KEY NOT NULL, blog_id INT, community_id INT);_
  _5. CREATE TABLE communities (id serial PRIMARY KEY NOT NULL, name VARCHAR(255), description TEXT);_
  _6. CREATE TABLE posts (id serial PRIMARY KEY NOT NULL, blog_ig INT, title VARCHAR(255), content TEXT, date DATE, file VARCHAR(255) NULL);_
  _7. CREATE TABLE session_blogs (id serial PRIMARY KEY NOT NULL, blog_ig INT);_
  
  _8. SHOW TABLES;_
* _Open Terminal (for Mac users) or PowerShell (for Windows users), navigate to BlogSite folder(cd .../Desktop/BlogSite.Solution/BlogSite) and run the following command: dotnet add package MySqlConnector && dotnet restore && dotnet build && dotnet run._
* _Copy http://localhost:5000 link and paste in the browser of your choise_.


## Known Bugs
_No bugs were found during testing._


## Support and contact details

_If you find any issue regarding this application please contact Zach Weintraub at zachweintraub@gmail.com, Marissa Perry at ohthatmarissa@gmail.com, Zema Kebede at zebede15@gmail.com, Svitlana Filatova at svitlana.filatova@gmail.com._


## Technologies Used

_C#/.NET/ASP.NET Core MVC/phpMyAdmin/MySQL_


### License

*This software is licensed under the MIT license*

Copyright (c) 2019 **Zach Weintraub, Marissa Perry, Zema Kebede, Svitlana Filatova**
=======
-Known bugs : post formatting
>>>>>>> master
