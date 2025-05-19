-- SQLite compatible schema
-- Drop existing tables first
DROP TABLE IF EXISTS `Cities`;
DROP TABLE IF EXISTS `Exercises`;
DROP TABLE IF EXISTS `ExercisesTrain`;
DROP TABLE IF EXISTS `Gender`;
DROP TABLE IF EXISTS `Goal`;
DROP TABLE IF EXISTS `Levels`;
DROP TABLE IF EXISTS `LevelStart`;
DROP TABLE IF EXISTS `Messages`;
DROP TABLE IF EXISTS `Presence`;
DROP TABLE IF EXISTS `Ranks`;
DROP TABLE IF EXISTS `Trainers`;
DROP TABLE IF EXISTS `Users`;
DROP TABLE IF EXISTS `WeightHeight`;
DROP TABLE IF EXISTS `WorkOnTa`;

CREATE TABLE IF NOT EXISTS `Cities` (
    `CodeCity` INTEGER PRIMARY KEY,
    `NameCity` TEXT
);

INSERT INTO `Cities`(`CodeCity`,`NameCity`)
VALUES(1,'תל אביב'),
      (2,'רמת גן'),
      (3,'קרית אונו'),
      (4,'גבעת שמואל'),
      (5,'גני תקוה'),
      (6,'פתח תקווה'),
      (7,'ירושליים'),
      (8,'חיפה'),
      (9,'אילת'),
      (10,'רחובות'),
      (11,'טבריה'),
      (12,'שהם'),
      (13,'אשקלון'),
      (14,'אשדוד'),
      (15,'נצרת'),
      (16,'דימונה'),
      (17,'נהריה'),
      (18,'הרצליה'),
      (19,'ראשון לציון'),
      (20,'חולון');

CREATE TABLE IF NOT EXISTS `Exercises` (
    `NumberExercises` INTEGER PRIMARY KEY,
    `NameExercises` TEXT,
    `Description` TEXT,
    `WorkOn` INTEGER,
    `levelThis` INTEGER
);

CREATE TABLE IF NOT EXISTS `ExercisesTrain` (
    `CodeCoaching` INTEGER,
    `CodeExercises` INTEGER,
    `NumBack` TEXT,
    `RetaNumber` TEXT,
    `WorkOnCode` INTEGER
);

CREATE TABLE IF NOT EXISTS `Gender` (
    `CodeGender` INTEGER PRIMARY KEY,
    `NameGender` TEXT
);

INSERT INTO `Gender`(`CodeGender`,`NameGender`)
VALUES(1,'בן'),
      (2,'בת');

CREATE TABLE IF NOT EXISTS `Goal` (
    `CodeGoal` INTEGER PRIMARY KEY,
    `NameGoal` TEXT
);

INSERT INTO `Goal`(`CodeGoal`,`NameGoal`)
VALUES(1,'להוריד שומן');

CREATE TABLE IF NOT EXISTS `Levels` (
    `CodeLevel` INTEGER PRIMARY KEY,
    `NameLevel` TEXT
);

INSERT INTO `Levels`(`CodeLevel`,`NameLevel`)
VALUES(1,'מתחיל'),
      (2,'מתקדם'),
      (3,'מבין');

CREATE TABLE IF NOT EXISTS `LevelStart` (
    `CodeLevelStart` INTEGER PRIMARY KEY,
    `NameLevelStart` TEXT
);

INSERT INTO `LevelStart`(`CodeLevelStart`,`NameLevelStart`)
VALUES(1,'מתחיל'),
      (2,'מתקדם'),
      (3,'מבין');

CREATE TABLE IF NOT EXISTS `Messages` (
    `Froms` INTEGER PRIMARY KEY,
    `To` INTEGER,
    `Date` TEXT,
    `TheMessage` TEXT
);

CREATE TABLE IF NOT EXISTS `Presence` (
    `UserId` INTEGER,
    `NumberOF` INTEGER,
    `From` TEXT,
    `To` TEXT
);

CREATE TABLE IF NOT EXISTS `Ranks` (
    `CodeRank` INTEGER PRIMARY KEY,
    `RankName` TEXT
);

CREATE TABLE IF NOT EXISTS `Trainers` (
    `Code` INTEGER PRIMARY KEY,
    `Name` TEXT,
    `Description` TEXT
);

CREATE TABLE IF NOT EXISTS `Users` (
    `Id` INTEGER PRIMARY KEY,
    `Password` TEXT,
    `Height` INTEGER,
    `Weight` INTEGER,
    `Goal` INTEGER,
    `City` INTEGER,
    `Level` INTEGER,
    `Gender` INTEGER,
    `UserName` TEXT,
    `Trainer` INTEGER,
    `Rank` INTEGER,
    `Itkadmot` INTEGER
);

CREATE TABLE IF NOT EXISTS `WeightHeight` (
    `Id` INTEGER,
    `DateWeight` TEXT,
    `NumberOf` INTEGER,
    PRIMARY KEY (`Id`, `DateWeight`, `NumberOf`)
);

CREATE TABLE IF NOT EXISTS `WorkOnTa` (
    `CodeWork` INTEGER PRIMARY KEY,
    `NameWork` TEXT
);

-- Insert sample workout types
INSERT INTO `WorkOnTa`(`CodeWork`,`NameWork`) 
VALUES (1, 'רגליים'),
       (2, 'חזה'),
       (3, 'גב'),
       (4, 'כתפיים'),
       (5, 'יד אחורית'),
       (6, 'יד קדמית'),
       (7, 'בטן'); 