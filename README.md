# VB.Net_AngryBirds_MazeRunner
An awesome project using VB.Net to build a full screen capable detailed online multiplayer video game, with a Angry Birds theme throughout subtitled Maze Runner! Using a MySQL database to achieve Multiplayer interaction, account login &amp; creation, custom maze map creation &amp; sharing, administration, host active game sessions, high scores &amp; more!

## YouTube example of running MMO gameplay, Login, Maze Creation, etc
Youtube example of "Online MMO gameplay between 3 computers" demo link:
https://www.youtube.com/watch?v=4Tx_YuFoccY

## Other Files:
Maze01.txt, Maze02.txt, Maze03.txt demonstrate how the text for a designed Maze Map layout looks! They are already included as part of the database, and when players create their own custom maps, they also get stored in the database, becoming accessible to play for all other players.

Angry Birds ERD & Crud images are provided  to better see the Database design!

A full detailed Report for this project is also included to see how the whole journey of development was done, with an executive summary, design storyboards & narratives, Design documentation and more.

## Important Database Notes:
This games Database file, and VB.net code was setup to run on MySQL database, so in order to work correctly it will need to be pointed to your own local or hosted Database instance. The application uses DBO.net (DataBase Object) to handle DTO's and the Database stored procedures from inside the application directly. DBO.net is sensitive be very careful if your not experienced using this and attempt to change anything.

My sql file has a few things commented out from when I was connecting locally and also has the Error Diagnostics commented out due to this having an error when deployed to the hosted database I used, But can be uncommented and works locally.

In the source code, all interactions with the database are found in 4 areas, these are, frmMain, clsSQLDataGridBind, clsMySQLCalls, mdProcessDB.

## Hot To Use:
Download all the full project, create the MySQL database setup locally or hosted online, open the project, install the Entity Framework Visual Studio Package, update the SQL related files and connection settings, then it should all work!
