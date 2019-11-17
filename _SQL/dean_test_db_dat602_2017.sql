#SQL CREATE DB/CREATE TABLES PROCEDURE/INSERT TEST DATA PROCEDURE:
#NOTE some error handling has been commented out due to not being
#Supported by Todds Online server we tunnel in, had to modify it be
#just a rollback and select query message returned saying unknown error
#===================================
#DROP DATABASE IF EXISTS angrybirds3;
DROP DATABASE IF EXISTS Dea25504db;
#CREATE DATABASE angrybirds3;
CREATE DATABASE Dea25504db;
#USE angrybirds3;
USE Dea25504db;
#SET GLOBAL optimizer_switch='derived_merge=OFF';

DROP PROCEDURE IF EXISTS makeAB3_DB;
DROP PROCEDURE IF EXISTS insertTestData;

DROP TABLE IF EXISTS gameplayer;
DROP TABLE IF EXISTS gameobject;
DROP TABLE IF EXISTS game;
DROP TABLE IF EXISTS map;
DROP TABLE IF EXISTS player;
DROP TABLE IF EXISTS object;
DROP TABLE IF EXISTS `character`;


DELIMITER $$

CREATE PROCEDURE makeAB3_DB()
BEGIN

CREATE TABLE player (
  userid INTEGER NOT NULL AUTO_INCREMENT UNIQUE PRIMARY KEY, 
  username VARCHAR(20) NOT NULL UNIQUE, 
  passwrd VARCHAR(20) NOT NULL, 
  admin VARCHAR(1) DEFAULT 'N', 
  attempts INTEGER DEFAULT 0,
  locked VARCHAR(1) DEFAULT 'N', 
  highscore INTEGER DEFAULT 0, 
  isonline VARCHAR(1) DEFAULT 'N',
  lastlogin TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB;

CREATE TABLE object (
  obj_id INTEGER NOT NULL AUTO_INCREMENT UNIQUE PRIMARY KEY, 
  obj_type VARCHAR(10) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE `character` (
  char_id INTEGER NOT NULL AUTO_INCREMENT UNIQUE PRIMARY KEY, 
  char_name VARCHAR(10) NOT NULL UNIQUE
) ENGINE=InnoDB;

CREATE TABLE map (
  userid INTEGER NOT NULL UNIQUE PRIMARY KEY,
  mapname VARCHAR(20) NOT NULL UNIQUE, 
  layout VARCHAR(840) NOT NULL,
  FOREIGN KEY (userid) REFERENCES player (userid) ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE game (
  gameid INTEGER NOT NULL UNIQUE PRIMARY KEY,
  mapname VARCHAR(20) NOT NULL,
  layout VARCHAR(840) NOT NULL,
  FOREIGN KEY (gameid) REFERENCES player (userid) ON DELETE CASCADE
) ENGINE=InnoDB;

CREATE TABLE gameplayer (
  gameid INTEGER NOT NULL,
  userid INTEGER NOT NULL UNIQUE,
  char_id INTEGER NOT NULL, 
  xypoint VARCHAR(10) DEFAULT '0,0',
  score INTEGER DEFAULT 0,
  PRIMARY KEY(gameid,userid),
  FOREIGN KEY (gameid) REFERENCES game (gameid) ON DELETE CASCADE,
  FOREIGN KEY (userid) REFERENCES player (userid) ON DELETE CASCADE,
  FOREIGN KEY (char_id) REFERENCES `character` (char_id)
) ENGINE=InnoDB; 

CREATE TABLE gameobject (
  gameid INTEGER NOT NULL,
  obj_id INTEGER NOT NULL,
  obj_xy VARCHAR(10) DEFAULT '0,0',
  PRIMARY KEY(gameid,obj_id),
  FOREIGN KEY (gameid) REFERENCES game (gameid) ON DELETE CASCADE,
  FOREIGN KEY (obj_id) REFERENCES object (obj_id)
) ENGINE=InnoDB;

DROP VIEW IF EXISTS GamePlayerStats;
CREATE VIEW `GamePlayerStats` As SELECT T1.gameid,T3.username, T2.char_name, T1.xypoint, T1.score
		FROM gameplayer AS T1
        INNER JOIN `character` As T2
        ON T1.char_id = T2.char_id
        INNER JOIN player As T3
        ON T1.userid = T3.userid
        GROUP BY T3.username ASC;
			
DROP VIEW IF EXISTS `ActiveGames`;
CREATE VIEW `ActiveGames` AS SELECT T2.username 'HOST', T1.mapname 'MAZE', 
		(SELECT COUNT(T3.gameid) 
		FROM gameplayer AS T3 
		WHERE T3.gameid = T1.gameid) 'PLAYERS'
		FROM game AS T1 
		INNER JOIN player AS T2 
		ON T1.gameid = T2.userid 
		GROUP BY T2.username ASC;

DROP VIEW IF EXISTS `OnlinePlayers`;
CREATE VIEW `OnlinePlayers` AS SELECT username,highscore 
		FROM player WHERE isonline="Y" ORDER BY highscore DESC;

DROP VIEW IF EXISTS `Top10`;
CREATE VIEW `Top10` AS SELECT username,highscore 
		FROM player WHERE highscore > 0 ORDER BY highscore DESC LIMIT 10;

DROP VIEW IF EXISTS `MapNames`;
CREATE VIEW `MapNames` AS SELECT mapname 'MAZE' 
		FROM map GROUP BY userid ASC;

END$$

DELIMITER ;

CALL makeAB3_DB();

DELIMITER $$

CREATE PROCEDURE insertTestData()
BEGIN

INSERT INTO player (username,passwrd,admin,highscore,isonline)
 VALUES
 ("Arno","12345","N",85,"Y"),
 ("Dean","123456","Y",95,"Y"),
 ("Dylan","12345","N",54,"Y"),
 ("Admin","123456","Y",23,"N"),
 ("Administrator","123456","Y",32,"Y"),
 ("Moderator","12345","Y",55,"N"),
 ("Hayden","12345","N",67,"Y"),
 ("Easy","123456","N",0,"N"),
 ("Medium","123456","N",0,"N"),
 ("Hard","123456","N",0,"N"),
 ("Heidi","12345","N",44,"Y"),
 ("Rosie","12345","N",61,"Y"),
 ("Corben","12345","N",68,"Y"),
 ("Ben","12345","N",37,"N"),
 ("Tim","12345","N",75,"N"),
 ("Daniel","12345","N",73,"Y"),
 ("Sam","12345","N",24,"Y"),
 ("Deja","12345","N",59,"Y"),
 ("Rachel","12345","N",41,"N"),
 ("Patrick","12345","N",66,"Y");

INSERT INTO object (obj_type)
 VALUES ("egg1"),("egg2"),("tnt1"),("tnt2");

INSERT INTO `character` (char_name)
 VALUES ("red"),("yellow"),("pink"),("bomb"),("blue"),("pig");

#----------------
# NOTE: The Games Maze Levels are stored as 1’s and spaces,
# When drawing the maze on screen to start a game,
# these are processed and every number 1 represents walls for the maze,
# blank spaces represent moveable space.
#----------------

INSERT INTO map
 VALUES
 (8,"Easy Maze","1111111111111111111111111111111111111111                                     11    111111  11  1111 111111  111111  11            11           11          11 1111111111111     11  1 11    1111  11   1               11  1       111   11 1 1   11    1111  11  1   111 1111  11 1                           1 1     11 111  111111111       111  1       1111   1          1            111 1     11   1  1111    1111  1111111111 1111  11   1                        11       11 1111111    1111 111111  11111  11   11                 11             11   11 1  11111111  11 11        11        11 1            11     11    11     11 11 111  1111111111 11  11  111111 1111 11                 11  11              11   11111  11111  11  1111  11 11111  11                           11        1111111111111111111111111111111111111111"),
 (9,"Medium Maze","1111111111111111111111111111111111111111                                     11   11111111111111111 1111111111111   11 1                                   11 1 11111111111     1111111111  1 11  11 1 1               1   1       1 1   11 1 1   11    1111  1   1   111 1 1  111 1            1    1         1 1     11 1 1 1111111  1    1  111  1 1 1  11111   1          1            1 1 1     11 1 1   111 1111111 111111111 1 11111 11 1 1   1                             11 1 1 111    1111 11111111111111111 1111 1                   1           1   11 1 111111111   111   1             1 11               1           1       1 11 111  1111111111 11111   111111 1111 11   1                 1     1         11   11111  11111  1   1111  11 11111  11                 1                   1111111111111111111111111111111111111111"),
 (10,"Hard Maze","1111111111111111111111111111111111111111                                     11   11111111111111111 1111111111111   11 1                 1                 11 1 11111111111  1  111 111111  1 111 11 1 1            1      1       1 1   11 1 1   1111111111  111 1 11111 1 1 1111 1            1    1         1 1     11 111 1111111  1 1111 1111111 1 1 111111   1          1            1 1 1     1111 111 111 1111111 111111111 1 11111 11 1 1   1                             11 1 1 1111 1 111111 111111111111111 1111 1        1          1       1   1   11 1 1111 11111  111   1  1111 1 1 1 1 11   1           1           1   1   1 11 111  1111111111 11111  111111 11111 11 1 1          1  1   1     1         11 1 11111  11111  1  11111  11111111  11   1             1                   1111111111111111111111111111111111111111");

#----------------
# NOTE: Game sessions need to store a copy of the Maze being played
# for others who join the game to get the maze when joining,
# I am not simply storing a reference to the maze from the maps table
# where they are held because if the creator for a maze,
# makes changes to it while its being played on, then games would glitch,
# new joiners would load a different looking maze, etc.
# Not desirable, hence I must store a copy of how the maze was at the
# time a new game is hosted!
#----------------

INSERT INTO game
 VALUES
 (20,"Easy Maze","1111111111111111111111111111111111111111                                     11    111111  11  1111 111111  111111  11            11           11          11 1111111111111     11  1 11    1111  11   1               11  1       111   11 1 1   11    1111  11  1   111 1111  11 1                           1 1     11 111  111111111       111  1       1111   1          1            111 1     11   1  1111    1111  1111111111 1111  11   1                        11       11 1111111    1111 111111  11111  11   11                 11             11   11 1  11111111  11 11        11        11 1            11     11    11     11 11 111  1111111111 11  11  111111 1111 11                 11  11              11   11111  11111  11  1111  11 11111  11                           11        1111111111111111111111111111111111111111"),
 (7,"Medium Maze","1111111111111111111111111111111111111111                                     11   11111111111111111 1111111111111   11 1                                   11 1 11111111111     1111111111  1 11  11 1 1               1   1       1 1   11 1 1   11    1111  1   1   111 1 1  111 1            1    1         1 1     11 1 1 1111111  1    1  111  1 1 1  11111   1          1            1 1 1     11 1 1   111 1111111 111111111 1 11111 11 1 1   1                             11 1 1 111    1111 11111111111111111 1111 1                   1           1   11 1 111111111   111   1             1 11               1           1       1 11 111  1111111111 11111   111111 1111 11   1                 1     1         11   11111  11111  1   1111  11 11111  11                 1                   1111111111111111111111111111111111111111"),
 (13,"Hard Maze","1111111111111111111111111111111111111111                                     11   11111111111111111 1111111111111   11 1                 1                 11 1 11111111111  1  111 111111  1 111 11 1 1            1      1       1 1   11 1 1   1111111111  111 1 11111 1 1 1111 1            1    1         1 1     11 111 1111111  1 1111 1111111 1 1 111111   1          1            1 1 1     1111 111 111 1111111 111111111 1 11111 11 1 1   1                             11 1 1 1111 1 111111 111111111111111 1111 1        1          1       1   1   11 1 1111 11111  111   1  1111 1 1 1 1 11   1           1           1   1   1 11 111  1111111111 11111  111111 11111 11 1 1          1  1   1     1         11 1 11111  11111  1  11111  11111111  11   1             1                   1111111111111111111111111111111111111111"),
 (12,"Easy Maze","1111111111111111111111111111111111111111                                     11    111111  11  1111 111111  111111  11            11           11          11 1111111111111     11  1 11    1111  11   1               11  1       111   11 1 1   11    1111  11  1   111 1111  11 1                           1 1     11 111  111111111       111  1       1111   1          1            111 1     11   1  1111    1111  1111111111 1111  11   1                        11       11 1111111    1111 111111  11111  11   11                 11             11   11 1  11111111  11 11        11        11 1            11     11    11     11 11 111  1111111111 11  11  111111 1111 11                 11  11              11   11111  11111  11  1111  11 11111  11                           11        1111111111111111111111111111111111111111");
 
INSERT INTO gameplayer
 VALUES
 (20,20,"1","2,15",3),
 (20,18,"3","12,11",6),
 (20,17,"4","16,12",9),
 (7,7,"2","12,15",12),
 (7,16,"6","3,2",3),
 (13,13,"5","6,13",9),
 (13,11,"3","11,4",6),
 (12,1,"6","9,17",15),
 (12,2,"1","15,14",9),
 (12,3,"2","6,11",12);

INSERT INTO gameobject
 VALUES
 (20,1,"1,2"),
 (20,2,"3,4"),
 (20,3,"5,6"),
 (20,4,"7,8"),
 (7,1,"1,2"),
 (7,2,"3,4"),
 (7,3,"5,6"),
 (7,4,"7,8"),
 (13,1,"1,2"),
 (13,2,"3,4"),
 (13,3,"5,6"),
 (13,4,"7,8"),
 (12,1,"1,2"),
 (12,2,"3,4"),
 (12,3,"5,6"),
 (12,4,"7,8");

END$$

DELIMITER ;

CALL insertTestData();
#Stored Procedures : Now the database is made and test data inserted
#I will create all my games stored procedures or functions, and views.

DROP PROCEDURE IF EXISTS AddUser;
DROP FUNCTION IF EXISTS CheckPassword;
DROP FUNCTION IF EXISTS UpdateAttempts;
DROP FUNCTION IF EXISTS CheckLocked;
DROP PROCEDURE IF EXISTS LoginUser;
DROP PROCEDURE IF EXISTS SetLockedStatus;
DROP PROCEDURE IF EXISTS RemoveGame;
DROP PROCEDURE IF EXISTS CheckGameHasPlayers;
DROP PROCEDURE IF EXISTS RemoveGamePlayer;
DROP PROCEDURE IF EXISTS LogoutUser;
DROP PROCEDURE IF EXISTS CheckOnlineStatus;
DROP PROCEDURE IF EXISTS GetObjectList;
DROP PROCEDURE IF EXISTS GetCharacterList;
DROP PROCEDURE IF EXISTS GetTop10HighScores;
DROP PROCEDURE IF EXISTS GetOnlinePlayers;
DROP PROCEDURE IF EXISTS GetActiveGames;
DROP PROCEDURE IF EXISTS GetPlayerMapInfo;
DROP PROCEDURE IF EXISTS CheckMapNameExists;
DROP PROCEDURE IF EXISTS AddUpdateMap;
DROP PROCEDURE IF EXISTS AddGameObject;
DROP PROCEDURE IF EXISTS AddGamePlayer;
DROP PROCEDURE IF EXISTS AddGameSession;
DROP PROCEDURE IF EXISTS GetGamePlayerStats;
DROP PROCEDURE IF EXISTS GetGameObjectStats;
DROP PROCEDURE IF EXISTS SetGameObjPosition;
DROP PROCEDURE IF EXISTS SetGamePlayerPosition;
DROP PROCEDURE IF EXISTS SetGamePlayerScore;
DROP PROCEDURE IF EXISTS IncreasePlayerScore;
DROP PROCEDURE IF EXISTS UpdateHighScore;
DROP PROCEDURE IF EXISTS CheckHighScore;
DROP PROCEDURE IF EXISTS SetAdminStatus;
DROP PROCEDURE IF EXISTS DeletePlayer;
DROP PROCEDURE IF EXISTS ChangePassword;
DROP PROCEDURE IF EXISTS GetPlayerTable;
DROP PROCEDURE IF EXISTS GetGameTable;
DROP PROCEDURE IF EXISTS GetGamePlayerTable;

SET AUTOCOMMIT = 0;

DELIMITER $$

CREATE PROCEDURE `AddUser`(IN pUserName VARCHAR(20), IN pUserPass VARCHAR(20))
	DETERMINISTIC
	COMMENT 'A procedure to add user'
BEGIN
	DECLARE aplayerID INT;
    DECLARE aplayerADMIN VARCHAR(1);
    DECLARE aplayerSCORE INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT userid FROM player
	WHERE username = pUserName
	INTO aplayerID;
    
	IF aplayerID IS NULL THEN
		INSERT INTO player(username,passwrd,isonline)
		VALUES (pUserName,pUserPass,"Y");
        
        SELECT userid,admin,highscore FROM player
		WHERE username = pUserName
		INTO aplayerID,aplayerADMIN,aplayerSCORE;
        
		SELECT CONCAT('ADDED: Congrats, You have created a new account..and are now Logged in as ',pUserName,' (',aplayerID,',',aplayerADMIN,',',aplayerSCORE,')') as Success;
	ELSE
		SELECT 'NOADD: Sorry that account cannot be created because it already exist!' as Failed;
	END IF;
    COMMIT;
END$$

CREATE FUNCTION `CheckLocked`(pUserName VARCHAR(20),pUserPass VARCHAR(20)) RETURNS TEXT
	DETERMINISTIC
	COMMENT 'A function that checks user account password, user locked, attempts'
BEGIN
	DECLARE aplayerLCK VARCHAR(1);
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		#ROLLBACK;
        RETURN('ERROR: The query preformed has failed with an unknown error!');
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
	SELECT locked FROM player
	WHERE username = pUserName
	INTO aplayerLCK;

	IF aplayerLCK = "Y" THEN
		RETURN('LOCKD: Sorry this account is locked, please email administration for help! (dean.stanleyhunt@live.nmit.ac.nz)');
	ELSE
		SET msg = CheckPassword(pUserName,pUserPass);
        RETURN(msg);
	END IF;
END$$

CREATE FUNCTION `CheckPassword`(pUserName VARCHAR(20),pUserPass VARCHAR(20)) RETURNS TEXT
	DETERMINISTIC
	COMMENT 'A function that checks user account password, user locked, attempts'
BEGIN
	DECLARE aplayerID INT;
    DECLARE aplayerADMIN VARCHAR(1);
    DECLARE aplayerSCORE INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		#ROLLBACK;
        RETURN('ERROR: The query preformed has failed with an unknown error!');
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
	SELECT userid,admin,highscore FROM player
	WHERE passwrd = pUserPass AND username = pUserName
	INTO aplayerID,aplayerADMIN,aplayerSCORE;

	IF aplayerID IS NULL THEN
		SET msg = UpdateAttempts(pUserName);
        RETURN(msg);
	ELSE
		UPDATE player SET attempts=0 AND isonline="Y"
		WHERE username=pUserName;
		RETURN(CONCAT('LOGIN: Success you Logged in as ',pUserName,' (',aplayerID,',',aplayerADMIN,',',aplayerSCORE,')'));
	END IF;
END$$

CREATE FUNCTION `UpdateAttempts`(pUserName VARCHAR(20)) RETURNS TEXT
	DETERMINISTIC
	COMMENT 'A function that checks user account password, user locked, attempts'
BEGIN
	DECLARE aplayerATMP INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		#ROLLBACK;
        RETURN('ERROR: The query preformed has failed with an unknown error!');
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
	UPDATE player SET attempts=attempts+1 WHERE username=pUserName;
    
	SELECT attempts FROM player
	WHERE username = pUserName
	INTO aplayerATMP;
               
	IF aplayerATMP > 4 THEN
		UPDATE player SET locked = "Y" WHERE username=pUserName;
		RETURN('LOCKD: Failed to login, wrong password! (Account Now Locked)');
	ELSE
		RETURN('FAILD: Failed to login, wrong password!');
	END IF;
END$$

CREATE PROCEDURE `LoginUser`(IN pUserName VARCHAR(20),IN pUserPass VARCHAR(20))
	DETERMINISTIC
	COMMENT 'A procedure that uses the first procedure to add user then checks if successful or not'
BEGIN
	DECLARE aplayerID INT;
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
		DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT userid FROM player
	WHERE username = pUserName
	INTO aplayerID;
    
	IF aplayerID IS NULL THEN
		CALL AddUser(pUserName,pUserPass);
	ELSE
		SET msg = CheckLocked(pUserName,pUserPass);
        SELECT msg AS Result;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `SetLockedStatus`(IN pUserID INT,IN pUserName VARCHAR(20),IN pLocked VARCHAR(1))
	DETERMINISTIC
	COMMENT 'A procedure that locks or unlocks a player account'
BEGIN
	DECLARE aplayerID INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
		DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT userid FROM player
	WHERE userid = pUserID OR username = pUserName
	INTO aplayerID;

	IF aplayerID IS NULL THEN
		SELECT 'ADMIN: Failed to set Locked Status, Player not Found in DB!' as Failed;
	ELSE
		UPDATE player SET locked=pLocked
		WHERE username=pUserName OR userid=pUserID;
		SELECT CONCAT('ADMIN: Successfully Set Locked Status of Player to ',pLocked,'!') as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `RemoveGame`(IN pGameID INT)
	DETERMINISTIC
	COMMENT 'A procedure that removes a game from the game table where live games are respresented'
BEGIN
	DECLARE agameID INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
		DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT gameid FROM game
	WHERE gameid = pGameID
	INTO agameID;

	IF agameID IS NULL THEN
		SELECT 'NGAME: Failed to Remove Game, Game not Found!' as Failed;
	ELSE    
		DELETE FROM game WHERE gameid=pGameID;
		SELECT CONCAT('DGAME: Successfully removed Game! (',pGameID,')') as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `CheckGameHasPlayers`(IN pGameID INT)
	DETERMINISTIC
	COMMENT 'A procedure that checks a game has players or not, if not calls to remove game'
BEGIN
	DECLARE agameID INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT gameid FROM gameplayer
	WHERE gameid = pGameID LIMIT 1 
	INTO agameID;

	IF agameID IS NULL THEN
		CALL RemoveGame(pGameID);
	ELSE    
		SELECT CONCAT('AGAME: Game still has players and was not removed! (',pGameID,')') as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `RemoveGamePlayer`(IN pUserID INT)
	DETERMINISTIC
	COMMENT 'A procedure that removes a player from a game, for if user leaves game'
BEGIN
	DECLARE aGameID INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT gameid FROM gameplayer
	WHERE userid = pUserID
	INTO aGameID;

	IF aGameID IS NULL THEN
		SELECT 'NGAME: Player not found in any active games' as Failed;
	ELSE    
		DELETE FROM gameplayer WHERE userid=pUserID;
		SELECT CONCAT('LGAME: Player with ID ',pUserID,' found and removed from active game! (',aGameID,')') as Success;
		CALL CheckGameHasPlayers(aGameID);
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `LogoutUser`(IN pUserID INT,IN pUserName VARCHAR(20))
	DETERMINISTIC
	COMMENT 'A procedure that sets an account to offline and calls a chain of events to remove the player from any game, etc'
BEGIN
	DECLARE aplayerID INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT userid FROM player
	WHERE userid = pUserID OR username = pUserName
	INTO aplayerID;

	IF aplayerID IS NULL THEN
		SELECT 'ADMIN: Could not set player to offline, player not found!' as Failed;
	ELSE
		UPDATE player SET isonline="N" WHERE userid=aplayerID;
		SELECT 'LGOUT: Player was set to offline!' as Success;
		CALL RemoveGamePlayer(aplayerID);
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `CheckOnlineStatus`(IN pUserID INT,IN pUserName VARCHAR(20))
	DETERMINISTIC
	COMMENT 'A procedure that checks an accounts online status'
BEGIN
	DECLARE aplayerID INT;
	DECLARE aplayerOnline VARCHAR(1);
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT userid,isonline FROM player
	WHERE userid = pUserID OR username = pUserName
	INTO aplayerID,aplayerOnline;

	IF aplayerID IS NULL THEN
		SELECT 'NOACC: Sorry account does not exist' as Failed;
	ELSE
		SELECT CONCAT('ISONL: Players online status is currently (',aplayerID,',',aplayerOnline,')') as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `GetObjectList`()
	DETERMINISTIC
	COMMENT 'A procedure that returns the table of objects used for starting to host new games'
BEGIN
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT * FROM object ORDER BY obj_id DESC;
    
    COMMIT;
END$$

CREATE PROCEDURE `GetCharacterList`()
	DETERMINISTIC
	COMMENT 'A procedure that returns the table of characters for my game for use potentially with character selection menu'
BEGIN
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT * FROM `character` ORDER BY char_id DESC;
    
    COMMIT;
END$$

CREATE PROCEDURE `GetTop10HighScores`()
	DETERMINISTIC
	COMMENT 'A procedure that returns a table of the Top 10 Highscores for all players in database'
BEGIN
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT * FROM Top10;
    
    COMMIT;
END$$

CREATE PROCEDURE `GetOnlinePlayers`()
	DETERMINISTIC
	COMMENT 'A procedure that returns a table of all currently online players and their highscores'
BEGIN
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT * FROM OnlinePlayers;
    
    COMMIT;
END$$

CREATE PROCEDURE `GetActiveGames`()
	DETERMINISTIC
	COMMENT 'A procedure that returns a table VIEW of all currently Active Games'
BEGIN
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT * FROM ActiveGames;
    
    COMMIT;
END$$

CREATE PROCEDURE `GetMapNames`()
	DETERMINISTIC
	COMMENT 'A procedure that returns a table of all maps descending in order by userid'
BEGIN
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT * FROM MapNames;
    
    COMMIT;
END$$

CREATE PROCEDURE `GetPlayerMapInfo`(IN pUserID INT,IN pMapName VARCHAR(20))
	DETERMINISTIC
	COMMENT 'A procedure that checks if a player has a map, via user ID or mapname search, and if they do also returns all map details'
BEGIN
	DECLARE aplayerID INT;
 	DECLARE aplayerMapName VARCHAR(20);
	DECLARE aplayerLayout VARCHAR(840);
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT userid,mapname,layout FROM map
	WHERE userid = pUserID OR mapname = pMapName
	INTO aplayerID,aplayerMapName,aplayerLayout;

	IF aplayerID IS NULL THEN
		SELECT 'NOMAP: Player does not have any Maze Map!' as Failed;
	ELSE
		SELECT CONCAT('MYMAP: Player Map Name is (',aplayerMapName,') for User ID (',aplayerID,') and Map Layout is (',aplayerLayout,')') as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `CheckMapNameExists`(IN pMapName VARCHAR(20))
	DETERMINISTIC
	COMMENT 'A procedure that checks if a Map Name already exists/used, for purpose of checking before adding new user map, or updating current users map name'
BEGIN
	DECLARE aplayerID INT;
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT userid FROM map
	WHERE mapname = pMapName
	INTO aplayerID;

	IF aplayerID IS NULL THEN
		SELECT 'MAPNM: False, Map Name was not Taken and can be used!' as Result;
	ELSE
		SELECT 'MAPNM: True, Map Name is Taken, Please choose another!' as Result;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `AddUpdateMap`(IN pUserID INT,IN pMapName VARCHAR(20),IN pMapLayout VARCHAR(840))
	DETERMINISTIC
	COMMENT 'A procedure that Adds or Updates a Map to the database that has been user created (Limited to 1 per Player)'
BEGIN
	DECLARE aplayerID INT;
    DECLARE aplayerMapname INT;
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT userid FROM map
	WHERE userid = pUserID
	INTO aplayerID;
    
    SELECT userid FROM map
	WHERE mapname = pMapName
	INTO aplayerMapname;

    IF aplayerMapname IS NULL THEN

		IF aplayerID IS NULL THEN
			INSERT INTO map VALUES (pUserID,pMapName,pMapLayout);
			SELECT 'MAPNW: New Map Successfully Added to Database!' as Success;
		ELSE
			UPDATE map SET mapname=pMapName,layout=pMapLayout WHERE userid=pUserID;
			SELECT 'MAPUP: Updated current Map Successfully in Database!' as Success;
		END IF;
    
    ELSE
      
		IF aplayerMapname = pUserID THEN

			IF aplayerID IS NULL THEN
				INSERT INTO map VALUES (pUserID,pMapName,pMapLayout);
				SELECT 'MAPNW: New Map Successfully Added to Database!' as Success;
			ELSE
				UPDATE map SET mapname=pMapName,layout=pMapLayout WHERE userid=pUserID;
				SELECT 'MAPUP: Updated current Map Successfully in Database!' as Success;
			END IF;
		
        ELSE
        
			SELECT 'MAPNM: Map Name is Taken, Please choose another!' as Result;
        
		END IF;
      
    END IF;

    
    COMMIT;
END$$

CREATE PROCEDURE `AddGameObject`(IN pGameID INT,IN pObjID INT,IN pObjPos VARCHAR(10))
	DETERMINISTIC
	COMMENT 'A procedure that Adds a single Game Object into the database for a single Game'
BEGIN
	DECLARE aGameID INT;
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT gameid FROM game
	WHERE gameid = pGameID
	INTO aGameID;

	IF aGameID IS NULL THEN
		SELECT 'ERROB: Cannot Add Game Object, Game ID Specified does not exist!' as Failed;
	ELSE
		INSERT INTO gameobject VALUES (pGameID,pObjID,pObjPos);
		SELECT 'OBJGM: Game Object was added for Game!' as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `AddGamePlayer`(IN pGameID INT,IN pUserID INT,IN pCharID INT,IN pUserPos VARCHAR(10),IN pStartScore INT)
	DETERMINISTIC
	COMMENT 'A procedure that Adds New Game Players into the database to exist for an Active Game'
BEGIN
	DECLARE aGameID INT;
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
    SELECT userid FROM gameplayer
	WHERE userid = pUserID
	INTO aGameID;
    
    IF aGameID IS NOT NULL THEN
		DELETE FROM gameplayer WHERE gameid = pGameID AND userid = pUserID;
    End IF;
    
	SELECT gameid FROM game
	WHERE gameid = pGameID
	INTO aGameID;
    
	IF aGameID IS NULL THEN
		SELECT 'NJOIN: Cannot Add Game Player, Game ID Specified does not exist!' as Failed;
	ELSE
		INSERT INTO gameplayer VALUES (pGameID,pUserID,pCharID,pUserPos,pStartScore);
		SELECT 'YJOIN: Game Player was added for Game!' as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `AddGameSession`(IN pUserID INT,IN pMapName VARCHAR(20),IN pMapLayout VARCHAR(840))
	DETERMINISTIC
	COMMENT 'A procedure that Adds a New Game Session being hosted into the database'
BEGIN
	DECLARE aGameID INT;
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT gameid FROM game
	WHERE gameid = pUserID
	INTO aGameID;

	IF aGameID IS NULL THEN
		INSERT INTO game VALUES (pUserID,pMapName,pMapLayout);
		SELECT 'UHOST: New Game Now Being Hosted!' as Success;
	ELSE
        SELECT 'UHOST: New Game Now Being Hosted!' as Success;
        CALL RemoveGame(pUserID);
	    CALL RemoveGamePlayer(pUserID);
		INSERT INTO game VALUES (pUserID,pMapName,pMapLayout);
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `GetGamePlayerStats`(IN pGameID INT)
	DETERMINISTIC
	COMMENT 'A procedure that returns the username, character, xy position and score for every player in a specific game'
BEGIN
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT * 
	FROM GamePlayerStats
	WHERE gameid = pGameID;
    
    COMMIT;
END$$

CREATE PROCEDURE `GetGameObjectStats`(IN pGameID INT)
	DETERMINISTIC
	COMMENT 'A procedure that returns the table of characters for my game for use potentially with character selection menu'
BEGIN
	DECLARE aGameID INT;
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT gameid FROM game
	WHERE gameid = pGameID
	INTO aGameID;

	IF aGameID IS NULL THEN
		SELECT 'LGAME: Game not found, Cannot get Game Objects!' as Failed;
	ELSE
		SELECT * FROM gameobject WHERE gameid=pGameID;
	End IF;
    COMMIT;
END$$

CREATE PROCEDURE `SetGameObjPosition`(IN pGameID INT,IN pObjID INT,IN pObjXY VARCHAR(10))
	DETERMINISTIC
	COMMENT 'A procedure that updates the position of an object in the game'
BEGIN
	DECLARE aGameID INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT gameid FROM gameobject
	WHERE gameid = pGameID AND obj_id = pObjID
	INTO aGameID;

	IF aGameID IS NULL THEN
		SELECT 'LGAME: Failed to Set Game Object Position, Game Not Found!' as Failed;
	ELSE
		UPDATE gameobject SET obj_xy=pObjXY 
		WHERE gameid=pGameID AND obj_id=pObjID;
		SELECT CONCAT('OBJXY: Updated Position of Object ',pObjID,' for Game ID ',pGameID,' to the XY: ',pObjXY) as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `SetGamePlayerPosition`(IN pGameID INT,IN pUserID INT,IN pUserXY VARCHAR(10))
	DETERMINISTIC
	COMMENT 'A procedure that updates a player position in the game'
BEGIN
	DECLARE aGameID INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        #SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	#SELECT gameid FROM gameplayer
	#WHERE gameid = pGameID AND userid = pUserID
	#INTO aGameID;

	#IF aGameID IS NULL THEN
		#SELECT 'LGAME: Failed to Set Game Player Position, Game or Player Not Found!' as Failed;
	#ELSE
		UPDATE gameplayer SET xypoint=pUserXY 
		WHERE gameid=pGameID AND userid=pUserID;
		SELECT * 
		FROM GamePlayerStats
		WHERE gameid = pGameID;
        #SELECT CONCAT('YOUXY: Updated Position of Player ',pUserID,' for Game ID ',pGameID,' to the XY: ',pUserXY) as Success;
	#END IF;
    COMMIT;
END$$

CREATE PROCEDURE `SetGamePlayerScore`(IN pGameID INT,IN pUserID INT,IN pScore INT)
	DETERMINISTIC
	COMMENT 'Admin procedure that updates the score for a player in a game'
BEGIN
	DECLARE aGameID INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT gameid FROM gameplayer
	WHERE gameid = pGameID AND userid = pUserID
	INTO aGameID;

	IF aGameID IS NULL THEN
		SELECT 'IGNOR: Failed to Set Player Score, Game or Player Not Found!' as Failed;
	ELSE
		UPDATE gameplayer SET score=pScore 
		WHERE gameid=pGameID AND userid=pUserID;
		SELECT CONCAT('SCRST: Updated Player ',pUserID,' for Game ID ',pGameID,' to score: ',pScore) as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `IncreasePlayerScore`(IN pGameID INT,IN pUserID INT)
	DETERMINISTIC
	COMMENT 'A procedure that updates the score for a player in a game'
BEGIN
	DECLARE aGameScore INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT score FROM gameplayer
	WHERE gameid = pGameID AND userid = pUserID
	INTO aGameScore;

	IF aGameScore IS NULL THEN
		SELECT 'LGAME: Failed to Increase Player Score, Game or Player Not Found!' as Failed;
	ELSE
		UPDATE gameplayer SET score=score+3 
		WHERE gameid=pGameID AND userid=pUserID;
		SELECT CONCAT('SCORE: Updated Player ',pUserID,' for Game ID ',pGameID,' to new score: ',aGameScore+3) as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `UpdateHighScore`(IN pUserID INT,IN pUserName VARCHAR(20),IN pScore INT)
	DETERMINISTIC
	COMMENT 'A procedure that updates the highscore for a player'
BEGIN
	DECLARE aplayerID INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT userid FROM player
	WHERE userid = pUserID OR username = pUserName
	INTO aplayerID;

	IF aplayerID IS NULL THEN
		SELECT 'ADMIN: Failed to update High Score, Player Not Found!' as Failed;
	ELSE
		UPDATE player SET highscore=pScore 
		WHERE userid=aplayerID;
		SELECT CONCAT('ADMIN: Updated Player ',aplayerID,' highscore to ',pScore) as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `CheckHighScore`(IN pUserID INT,IN pUserName VARCHAR(20),IN pScore INT)
	DETERMINISTIC
	COMMENT 'A procedure that checks if players score is greater than high score, and if so updates highscore'
BEGIN
	DECLARE aHighScore INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT highscore FROM player
	WHERE userid = pUserID OR username = pUserName
	INTO aHighScore;

	IF aHighScore IS NULL THEN
		SELECT 'LGOUT: Failed to Check Score against High Score, Player Not Found!' as Failed;
	ELSEIF pScore > aHighScore Then
		UPDATE player SET highscore=pScore 
		WHERE userid = pUserID OR username = pUserName;
        SELECT CONCAT('HIGHS: Updated Player highscore to ',pScore) as Success;
	ELSE
		SELECT 'SAMES: That Score was not greater than the current High Score!' as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `SetAdminStatus`(IN pUserID INT,IN pUserName VARCHAR(20),IN pAdmin VARCHAR(1))
	DETERMINISTIC
	COMMENT 'A procedure that sets the admin status for a player account'
BEGIN
	DECLARE aplayerID INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT userid FROM player
	WHERE userid = pUserID OR username = pUserName
	INTO aplayerID;

	IF aplayerID IS NULL THEN
		SELECT 'ADMIN: Failed to set Admin Status, Player not Found in DB!' as Failed;
	ELSE
		UPDATE player SET admin=pAdmin
		WHERE username=pUserName OR userid=pUserID;
		SELECT CONCAT('ADMIN: Successfully Set Admin Status of Player to ',pAdmin,'!') as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `DeletePlayer`(IN pUserID INT,IN pUserName VARCHAR(20))
	DETERMINISTIC
	COMMENT 'A procedure for Admins Only that deletes a player account'
BEGIN
	DECLARE aplayerID INT;
	DECLARE aplayerName VARCHAR(20);
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
	
    SELECT userid,username FROM player
	WHERE userid = pUserID OR username = pUserName
	INTO aplayerID,aplayerName;

	IF aplayerID IS NULL THEN
		SELECT 'ADMIN: Failed to Delete Account, Player not Found in DB!' as Failed;
	ELSE
		DELETE FROM player 
		WHERE userid=aplayerID;
		SELECT CONCAT('ADMIN: Successfully Deleted ',aplayerName,'!') as Success;
    END IF;
    COMMIT;
END$$

CREATE PROCEDURE `ChangePassword`(IN pUserID INT,IN pUserName VARCHAR(20),IN pNewPass VARCHAR(20))
	DETERMINISTIC
	COMMENT 'A procedure for Admins Only that changes the Password for a player account'
BEGIN
	DECLARE aplayerID INT;
    DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT userid FROM player
	WHERE userid = pUserID OR username = pUserName
	INTO aplayerID;

	IF aplayerID IS NULL THEN
		SELECT 'ADMIN: Failed to Change Password, Player not Found in DB!' as Failed;
	ELSE
		UPDATE player SET passwrd=pNewPass
		WHERE userid=aplayerID;
		SELECT CONCAT('ADMIN: Successfully changed player password to ',pNewPass) as Success;
	END IF;
    COMMIT;
END$$

CREATE PROCEDURE `GetPlayerTable`()
	DETERMINISTIC
	COMMENT 'A procedure that returns the Player table'
BEGIN
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT * FROM player ORDER BY userid DESC;
    
    COMMIT;
END$$

CREATE PROCEDURE `GetGameTable`()
	DETERMINISTIC
	COMMENT 'A procedure that returns the Game table'
BEGIN
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT * FROM game ORDER BY gameid DESC;
    
    COMMIT;
END$$

CREATE PROCEDURE `GetGamePlayerTable`()
	DETERMINISTIC
	COMMENT 'A procedure that returns the GamePlayer table'
BEGIN
	DECLARE errcode CHAR(5) DEFAULT '00000';
	DECLARE msg TEXT;
  
	DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
		ROLLBACK;
        SELECT 'ERROR: The query preformed has failed with an unknown error!' as ErrorInfo;
		#GET DIAGNOSTICS CONDITION 1 
        #errcode = RETURNED_SQLSTATE, msg = MESSAGE_TEXT;
        #RETURN(CONCAT('ERROR: A Query failed, error = ',errcode,', message = ',msg));
    END;
    
    START TRANSACTION;
    
	SELECT * FROM gameplayer ORDER BY gameid DESC;
    
    COMMIT;
END$$

DELIMITER ;

