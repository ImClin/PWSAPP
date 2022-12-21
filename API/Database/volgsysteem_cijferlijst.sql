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
-- Table structure for table `cijferlijst`
--

DROP TABLE IF EXISTS `cijferlijst`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cijferlijst` (
  `LeerlingId` varchar(4) DEFAULT NULL,
  `VakId` int(11) DEFAULT NULL,
  `Cijfer` int(11) DEFAULT NULL,
  `CijferId` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`CijferId`),
  UNIQUE KEY `CijferId_UNIQUE` (`CijferId`)
) ENGINE=InnoDB AUTO_INCREMENT=1029 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cijferlijst`
--

LOCK TABLES `cijferlijst` WRITE;
/*!40000 ALTER TABLE `cijferlijst` DISABLE KEYS */;
INSERT INTO `cijferlijst` VALUES ('0001',1,55,776),('0001',1,74,777),('0001',1,30,778),('0015',1,65,779),('0015',1,81,780),('0015',1,51,781),('0015',2,70,782),('0015',2,60,783),('0015',2,40,784),('0015',4,60,785),('0015',4,60,786),('0015',4,88,787),('0001',8,70,788),('0001',8,60,789),('0001',8,65,790),('0015',8,56,791),('0015',8,73,792),('0015',8,71,793),('0015',5,57,794),('0015',5,72,795),('0015',5,65,796),('0001',6,44,797),('0001',6,72,798),('0001',6,57,799),('0015',6,72,800),('0015',6,54,801),('0015',6,82,802),('0003',7,65,1012),('0003',7,82,1013),('0003',7,70,1014),('0003',7,40,1015),('0015',7,70,1016),('0015',7,80,1017),('0015',7,83,1018),('0015',7,90,1019),('0005',7,67,1020),('0005',7,81,1021),('0005',7,67,1022),('0001',7,60,1023),('0001',7,50,1024),('0001',7,51,1025),('0006',7,70,1026),('0006',7,80,1027),('0009',7,60,1028);
/*!40000 ALTER TABLE `cijferlijst` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-15 17:19:16