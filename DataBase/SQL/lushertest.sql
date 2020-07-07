-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: psymend
-- ------------------------------------------------------
-- Server version	5.7.29-log

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
-- Dumping data for table `psychobio_answer_definition`
--

LOCK TABLES `lusher_interpretation` WRITE;
/*!40000 ALTER TABLE `lusher_interpretation` DISABLE KEYS */;
INSERT INTO `psymend`.`lusher_interpretation`
(`Key`,`Text`)
VALUES
('a-1-1', 'У вас имеется нетерпимость, беспокойство, угнетенность. Неудовлетворена потребность в эмоциональной близости; стремление избежать отношений, обязывающих к ответственности. Неустойчивость состояния, беспокойные попытки изменить ситуацию, что может отразиться на концентрации внимания, работоспособности.'),
('a-2-2', 'У вас неудовлетворена потребность в отстаивании своей позиции и права на уважение. Противодействие средовому давлению вызвало напряжение.'),
('a-3-3', 'У вас неудовлетворена потребность в самореализации и достижении желаемых целей, что является почвой для гневных вспышек, невротизации, психосоматических расстройств (кардиология). Ощущение бессилия перед существующими препятствиями. Чувство страха, нервное истощение, беспокойная раздражительность.'),
('a-4-4', 'У вас сохраняется состояние стресса в связи с блокированной спонтанностью поведения, невозможностью реализовать потребность в радостном общении, беззаботном существовании. Неуверенность, тревожная настороженность. Болезненно переживается неудовлетворенное тщеславие, потребность нравиться окружающим. Отказ от компромиссов, упорство в ирреальных притязаниях.'),
('a-5-5', 'Вы испытываете стресс, контролируемый тонкостью суждений и рассудком над эмоциями. Тенденция к излишней доверчивости в качестве защитного механизма вызывает повышенную требовательность к искренности окружающих, особенно в контактах узкого круга. Контролируемая чувствительность.'),
('a-8-8', 'Вы вынуждены испытывать отказ от расслабления и уступок, стремление сохранить активность, овладеть эмоциями. Неудовлетворена потребность в близости; беспокойная неудовлетворенность, связанная с осознанием своей зависимости от объекта привязанности. Раздражительность и трудности концентрации внимания.')
/*!40000 ALTER TABLE `lusher_interpretation` ENABLE KEYS */;
UNLOCK TABLES;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-29 10:28:37
