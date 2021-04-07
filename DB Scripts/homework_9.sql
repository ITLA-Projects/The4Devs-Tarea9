CREATE DATABASE IF NOT EXISTS `homework_9`;
USE `homework_9`;

CREATE TABLE IF NOT EXISTS `Applicants` (
  `cedula` varchar(15) NOT NULL,
  `name` varchar(25) NOT NULL,
  `email` varchar(50) UNIQUE NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `birth_date` date NOT NULL,
  `blood_id` int(11) DEFAULT NULL,
  `request_flag` tinyint(1) DEFAULT 1,
  `covid19_flag` tinyint(1) NOT NULL,
  PRIMARY KEY (`cedula`)
);

CREATE TABLE IF NOT EXISTS `Bloods` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(5) NOT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE IF NOT EXISTS `Provinces` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE IF NOT EXISTS `Requests` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `written_request` varchar(3000) NOT NULL,
  `province_id` int(11) NOT NULL,
  `address` varchar(500) NOT NULL,
  `latitude` decimal(15,12) NOT NULL,
  `longitude` decimal(15,12) NOT NULL,
  `applicant_id` varchar(15) NOT NULL,
  PRIMARY KEY (`id`),
  FOREIGN KEY (province_id) REFERENCES Provinces(id),
  FOREIGN KEY (applicant_id) REFERENCES Applicants(cedula)
);

ALTER TABLE Applicants
ADD FOREIGN KEY (blood_id) REFERENCES Bloods(id);