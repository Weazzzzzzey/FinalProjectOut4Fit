-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 2020 m. Bir 21 d. 09:58
-- Server version: 10.1.36-MariaDB
-- PHP Version: 7.2.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `out4fit`
--

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `allrequestsever`
--

CREATE TABLE `allrequestsever` (
  `ID` int(11) NOT NULL,
  `userID` int(11) DEFAULT NULL,
  `city` varchar(255) DEFAULT NULL,
  `temperature` double DEFAULT NULL,
  `responsebody` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Sukurta duomenų kopija lentelei `allrequestsever`
--

INSERT INTO `allrequestsever` (`ID`, `userID`, `city`, `temperature`, `responsebody`) VALUES
(1, 1, 'vilnius', 35.5, 'Hat'),
(2, 6, 'vilnius', 23.35, ' \"Regular Fit Cotton Shirt\",\r\n       \"Regular Fit Cargo Shorts\",\r\n       \"Sneakers\",\r\n      '),
(3, 1, 'kaunas', 24.75, ' \"Regular Fit Cotton Shirt\",\r\n       \"Regular Fit Cargo Shorts\",\r\n       \"Sneakers\",\r\n      '),
(4, 7, 'trakai', 24.25, ' \"Patterned Resort Shirt\",\r\n       \"Regular Fit Cargo Shorts\",\r\n       \"Sneakers\",\r\n      '),
(5, 9, 'alytus', 25.65, ' \"Cotton Shirt\",\r\n       \"Long-sleeved Denim Dress\",\r\n       \"Platform Sneakers\",\r\n      '),
(6, 16, 'trakai', 24.25, ' \"Cotton Shirt\",\r\n       \"Long-sleeved Denim Dress\",\r\n       \"Platform Sneakers\",\r\n      '),
(7, 16, 'kaunas', 25.75, ' \"Cotton Shirt\",\r\n       \"Long-sleeved Denim Dress\",\r\n       \"Platform Sneakers\",\r\n      '),
(8, 9, 'kaunas', 25.75, ' \"Cotton Shirt\",\r\n       \"Long-sleeved Denim Dress\",\r\n       \"Platform Sneakers\",\r\n      '),
(9, 16, 'kaunas', 25.65, ' \"Cotton Shirt\",\r\n       \"Long-sleeved Denim Dress\",\r\n       \"Platform Sneakers\",\r\n      '),
(10, 8, 'kaunas', 25.65, ' \"Regular Fit Cotton Shirt\",\r\n       \"Regular Fit Cargo Shorts\",\r\n       \"Sneakers\",\r\n      '),
(11, 2, 'klaipeda', 21.55, ' \"Cotton Shirt\",\r\n       \"Long-sleeved Denim Dress\",\r\n       \"Platform Sneakers\",\r\n      '),
(12, 16, 'alytus', 22.7, ' \"Cotton Shirt\",\r\n       \"Long-sleeved Denim Dress\",\r\n       \"Platform Sneakers\",\r\n      ');

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `user`
--

CREATE TABLE `user` (
  `userID` int(11) NOT NULL,
  `userName` varchar(255) DEFAULT NULL,
  `gender` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Sukurta duomenų kopija lentelei `user`
--

INSERT INTO `user` (`userID`, `userName`, `gender`, `password`) VALUES
(1, 'NiceBoy', 'Male', 'aljfkas'),
(2, 'NiceGirl', 'Female', 'alfabet'),
(3, 'Triusis', 'Male', 'alksdjkla'),
(4, 'Traveler', 'Male', 'jkalsldjk'),
(5, 'ShopLifter', 'Female', 'laksdklj'),
(6, 'WifiUser', 'Male', 'wififorwre'),
(7, 'BananaPower', 'Male', 'wififorwrasdee'),
(8, 'Keny_Heets', 'Male', 'heeetsIsNice'),
(9, 'Leep', 'Female', 'VeryNiceLeepPass'),
(16, 'AppleGirl', 'Female', 'iphone123Q'),
(17, 'Fox', 'Female', 'FoxLiveInForest'),
(18, 'YogaLover', 'Female', 'VipasanaTech');

-- --------------------------------------------------------

--
-- Sukurta duomenų struktūra lentelei `userssaved`
--

CREATE TABLE `userssaved` (
  `requestID` int(11) NOT NULL,
  `userID` int(11) DEFAULT NULL,
  `city` varchar(255) DEFAULT NULL,
  `temperature` double DEFAULT NULL,
  `responseBody` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Sukurta duomenų kopija lentelei `userssaved`
--

INSERT INTO `userssaved` (`requestID`, `userID`, `city`, `temperature`, `responseBody`) VALUES
(1, 1, 'vilnius', 25.5, 'Example'),
(2, 1, 'kaunas', 24, ' \"Regular Fit Cotton Shirt\",\r\n       \"Regular Fit Cargo Shorts\",\r\n       \"Sneakers\",\r\n      '),
(3, 9, 'alytus', 25, ' \"Cotton Shirt\",\r\n       \"Long-sleeved Denim Dress\",\r\n       \"Platform Sneakers\",\r\n      '),
(4, 16, 'kaunas', 25, ' \"Cotton Shirt\",\r\n       \"Long-sleeved Denim Dress\",\r\n       \"Platform Sneakers\",\r\n      '),
(5, 16, 'kaunas', 25, ' \"Cotton Shirt\",\r\n       \"Long-sleeved Denim Dress\",\r\n       \"Platform Sneakers\",\r\n      '),
(6, 8, 'kaunas', 25, ' \"Regular Fit Cotton Shirt\",\r\n       \"Regular Fit Cargo Shorts\",\r\n       \"Sneakers\",\r\n      '),
(7, 2, 'klaipeda', 21, ' \"Cotton Shirt\",\r\n       \"Long-sleeved Denim Dress\",\r\n       \"Platform Sneakers\",\r\n      '),
(8, 16, 'alytus', 22, ' \"Cotton Shirt\",\r\n       \"Long-sleeved Denim Dress\",\r\n       \"Platform Sneakers\",\r\n      ');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `allrequestsever`
--
ALTER TABLE `allrequestsever`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userID`);

--
-- Indexes for table `userssaved`
--
ALTER TABLE `userssaved`
  ADD PRIMARY KEY (`requestID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `allrequestsever`
--
ALTER TABLE `allrequestsever`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `userssaved`
--
ALTER TABLE `userssaved`
  MODIFY `requestID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
