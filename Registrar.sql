-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Jul 22, 2024 at 12:17 AM
-- Server version: 8.3.0
-- PHP Version: 8.3.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `Registrar`
--
CREATE DATABASE IF NOT EXISTS `Registrar` DEFAULT CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci;
USE `Registrar`;

-- --------------------------------------------------------

--
-- Table structure for table `Course`
--

DROP TABLE IF EXISTS `Course`;
CREATE TABLE `Course` (
  `Id` int NOT NULL,
  `Code` varchar(7) NOT NULL,
  `Title` varchar(100) NOT NULL,
  `WeeklyHours` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Dumping data for table `Course`
--

INSERT INTO `Course` (`Id`, `Code`, `Title`, `WeeklyHours`) VALUES
(111878, 'CST8256', 'Web Programming Language I', 5),
(312256, 'CST2200', 'Data Warehouse Design', 3),
(417144, 'CST8254', 'Network Operating System', 1),
(596652, 'CST8253', 'Web Programming II', 2),
(809644, 'CST8282', 'Introduction to Database Systems', 4),
(814786, 'CST2240', 'Advance Database Topics', 1),
(966930, 'CST8255', 'Web Imaging and Animations', 2);

-- --------------------------------------------------------

--
-- Table structure for table `Registration`
--

DROP TABLE IF EXISTS `Registration`;
CREATE TABLE `Registration` (
  `StudentId` int NOT NULL,
  `CourseId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Dumping data for table `Registration`
--

INSERT INTO `Registration` (`StudentId`, `CourseId`) VALUES
(314486, 111878),
(314486, 417144),
(314486, 596652);

-- --------------------------------------------------------

--
-- Table structure for table `Student`
--

DROP TABLE IF EXISTS `Student`;
CREATE TABLE `Student` (
  `Id` int NOT NULL,
  `FirstName` varchar(50) NOT NULL,
  `LastName` varchar(100) NOT NULL,
  `Type` enum('Full Time','Part Time','Coop') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

--
-- Dumping data for table `Student`
--

INSERT INTO `Student` (`Id`, `FirstName`, `LastName`, `Type`) VALUES
(268072, 'Martha', 'Jones', 'Part Time'),
(314486, 'John', 'Smith', 'Full Time'),
(791864, 'Rose', 'Tyler', 'Coop');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Course`
--
ALTER TABLE `Course`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `Registration`
--
ALTER TABLE `Registration`
  ADD PRIMARY KEY (`StudentId`,`CourseId`);

--
-- Indexes for table `Student`
--
ALTER TABLE `Student`
  ADD PRIMARY KEY (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
