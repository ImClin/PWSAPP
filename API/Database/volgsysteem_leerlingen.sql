-- MySQL dump 10.13  Distrib 8.0.31, for Win64 (x86_64)
--
-- Host: testserver-clin.mysql.database.azure.com    Database: volgsysteem
-- ------------------------------------------------------
-- Server version	5.7.39-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `leerlingen`
--

DROP TABLE IF EXISTS `leerlingen`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `leerlingen` (
  `LeerlingId` varchar(4) NOT NULL,
  `Wachtwoord` varchar(45) NOT NULL,
  `Naam` varchar(45) NOT NULL,
  `Klas` varchar(45) NOT NULL,
  `MentorId` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`LeerlingId`),
  UNIQUE KEY `LeerlingId_UNIQUE` (`LeerlingId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leerlingen`
--

LOCK TABLES `leerlingen` WRITE;
/*!40000 ALTER TABLE `leerlingen` DISABLE KEYS */;
INSERT INTO `leerlingen` VALUES ('0001','0001','Louk Dammers','4HA','DBE'),('0002','0002','Nadieh Jakobs','4HA','DBE'),('0003','0003','Ilone Vermulst','4HA','DBE'),('0004','0004','Wyke Blankestijn','4HA','DBE'),('0005','0005','Ad Leeuwestein','4HA','HCS'),('0006','0006','Sofyan van Meggelen','4HA','HCS'),('0007','0007','Arnoldina Dannenberg','4HA','HCS'),('0008','0008','Jethro Doorten','4HA','JVE'),('0009','0009','Martijn Waardenburg','4HA','JVE'),('0010','0010','Shai Ophorst','4HA','JVE'),('0011','0011','Mark-Jan Rasenberg','4HA','LST'),('0012','0012','Diyar Aantjes','4HA','LST'),('0013','0013','Elmira Hol','4HA','LST'),('0014','0014','Demi Schreur','4HA','DBE'),('0015','0015','Colin Canters','4HA','DBE');
/*!40000 ALTER TABLE `leerlingen` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-15 17:19:17
