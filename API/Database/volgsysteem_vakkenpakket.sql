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
-- Table structure for table `vakkenpakket`
--

DROP TABLE IF EXISTS `vakkenpakket`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vakkenpakket` (
  `VakId` int(11) DEFAULT NULL,
  `LeerlingId` varchar(4) DEFAULT NULL,
  `PakketId` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`PakketId`),
  UNIQUE KEY `PakketId_UNIQUE` (`PakketId`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vakkenpakket`
--

LOCK TABLES `vakkenpakket` WRITE;
/*!40000 ALTER TABLE `vakkenpakket` DISABLE KEYS */;
INSERT INTO `vakkenpakket` VALUES (1,'0001',1),(3,'0001',2),(6,'0001',3),(8,'0001',4),(1,'0003',5),(1,'0005',6),(1,'0009',7),(1,'0010',8),(1,'0011',9),(1,'0012',10),(1,'0006',11),(2,'0003',12),(3,'0003',13),(11,'0003',14),(6,'0003',15),(7,'0003',16),(1,'0015',17),(2,'0015',18),(6,'0015',19),(7,'0015',20),(4,'0015',21),(8,'0015',22),(11,'0012',23),(5,'0015',24),(6,'0005',25),(7,'0005',26),(7,'0001',27),(7,'0006',28),(7,'0008',29),(7,'0009',30);
/*!40000 ALTER TABLE `vakkenpakket` ENABLE KEYS */;
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
