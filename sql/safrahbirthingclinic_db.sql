-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 05, 2022 at 12:21 AM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 7.4.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `safrahbirthingclinic_db`
--
CREATE DATABASE IF NOT EXISTS `safrahbirthingclinic_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `safrahbirthingclinic_db`;

-- --------------------------------------------------------

--
-- Table structure for table `admittedpateinttbl`
--

CREATE TABLE `admittedpateinttbl` (
  `caseNumber` varchar(20) NOT NULL,
  `pateintId` varchar(20) NOT NULL,
  `age` text NOT NULL,
  `bp` varchar(10) NOT NULL,
  `weight` decimal(10,0) NOT NULL,
  `temp` int(11) NOT NULL,
  `roomNumber` varchar(12) NOT NULL,
  `bedNumber` int(1) NOT NULL,
  `attendantId` varchar(50) NOT NULL,
  `admittingDiagnosis` varchar(150) NOT NULL,
  `time` time NOT NULL,
  `date` date NOT NULL,
  `status` int(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `amstlandeinc`
--

CREATE TABLE `amstlandeinc` (
  `newbornid` varchar(20) NOT NULL,
  `amstlState` int(1) NOT NULL,
  `amstl1` int(1) NOT NULL,
  `amstl2` int(1) NOT NULL,
  `amstl3` int(1) NOT NULL,
  `eincState` int(1) NOT NULL,
  `einc1` int(1) NOT NULL,
  `einc2` int(1) NOT NULL,
  `einc3` int(1) NOT NULL,
  `einc4` int(1) NOT NULL,
  `amstlEINC` varchar(9) NOT NULL DEFAULT '000000000'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `bills`
--

CREATE TABLE `bills` (
  `invoiceNumber` varchar(20) NOT NULL,
  `pateintId` varchar(20) NOT NULL,
  `status` int(1) NOT NULL DEFAULT 1,
  `discountType` varchar(20) NOT NULL,
  `grand_total` decimal(10,0) NOT NULL,
  `caseNumber` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `brand_tbl`
--

CREATE TABLE `brand_tbl` (
  `id` varchar(20) NOT NULL,
  `type` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `distributor` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `consultationtbl`
--

CREATE TABLE `consultationtbl` (
  `caseNumber` varchar(20) NOT NULL,
  `pateintId` varchar(20) NOT NULL,
  `date` date NOT NULL,
  `time` time NOT NULL,
  `attendant` varchar(30) NOT NULL,
  `bp` varchar(10) NOT NULL,
  `weight` decimal(10,0) NOT NULL,
  `temp` decimal(5,0) NOT NULL,
  `symptoms` text NOT NULL,
  `urinary_test` varchar(13) NOT NULL,
  `diagnosis` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `delivery_tbl`
--

CREATE TABLE `delivery_tbl` (
  `caseNumber` varchar(20) NOT NULL,
  `patientId` varchar(20) NOT NULL,
  `gravida` text NOT NULL,
  `para` text NOT NULL,
  `dateDeliver` text NOT NULL,
  `timeDeliver` text NOT NULL,
  `ampm` varchar(10) NOT NULL,
  `status` varchar(20) NOT NULL,
  `sex` varchar(10) NOT NULL,
  `weight` varchar(5) NOT NULL,
  `height` varchar(5) NOT NULL,
  `hc` varchar(5) NOT NULL,
  `cc` varchar(5) NOT NULL,
  `ac` varchar(5) NOT NULL,
  `hepab` varchar(10) NOT NULL,
  `attendant` text NOT NULL,
  `assisted` text NOT NULL,
  `management` text NOT NULL,
  `age` int(3) NOT NULL,
  `fullName` varchar(50) NOT NULL,
  `address` varchar(100) NOT NULL,
  `nbs` varchar(10) NOT NULL DEFAULT 'Reffered',
  `g/p` varchar(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `discharge_tbl`
--

CREATE TABLE `discharge_tbl` (
  `caseNumber` varchar(20) NOT NULL,
  `pateintId` varchar(20) NOT NULL,
  `age` int(11) NOT NULL,
  `date` text NOT NULL,
  `time` text NOT NULL,
  `attendant` varchar(50) NOT NULL,
  `bp` text NOT NULL,
  `weight` text NOT NULL,
  `temp` text NOT NULL,
  `finaldiag` text NOT NULL,
  `medathome` text NOT NULL,
  `disposition` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `discount_tbl`
--

CREATE TABLE `discount_tbl` (
  `discountId` int(11) NOT NULL,
  `discountType` varchar(50) NOT NULL,
  `discountrate` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `discount_tbl`
--

INSERT INTO `discount_tbl` (`discountId`, `discountType`, `discountrate`) VALUES
(1, 'PhilHealth', 80),
(2, 'Suki', 10),
(3, 'PWD', 20),
(4, 'Voucher1', 12);

-- --------------------------------------------------------

--
-- Table structure for table `employeetbl`
--

CREATE TABLE `employeetbl` (
  `id` int(20) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `dateofbirth` date NOT NULL,
  `age` int(11) NOT NULL,
  `title` varchar(50) NOT NULL,
  `license` varchar(7) NOT NULL,
  `religion` varchar(50) NOT NULL,
  `contactnumber` varchar(14) NOT NULL,
  `province` varchar(50) NOT NULL,
  `city/mun` varchar(50) NOT NULL,
  `barangay` varchar(50) NOT NULL,
  `houseno` int(11) NOT NULL,
  `street` varchar(50) NOT NULL,
  `addressId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `employeetitletbl`
--

CREATE TABLE `employeetitletbl` (
  `id` int(11) NOT NULL,
  `employeetitle` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `employeetitletbl`
--

INSERT INTO `employeetitletbl` (`id`, `employeetitle`) VALUES
(4, 'Midwife'),
(5, 'Nurse'),
(6, 'Intern'),
(7, 'Sample'),
(8, 'ss'),
(9, 'aaaaaaaa'),
(10, 'Pediatric'),
(11, 'New Title');

-- --------------------------------------------------------

--
-- Table structure for table `invoicetbl`
--

CREATE TABLE `invoicetbl` (
  `invoiceNo` varchar(20) NOT NULL,
  `pateintId` int(11) NOT NULL,
  `itemId` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `date` varchar(50) NOT NULL,
  `total` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `medicine_tbl`
--

CREATE TABLE `medicine_tbl` (
  `id` varchar(11) NOT NULL,
  `brand` varchar(50) NOT NULL,
  `name` text NOT NULL,
  `dosage` text NOT NULL,
  `price` text NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `medicine_tbl`
--

INSERT INTO `medicine_tbl` (`id`, `brand`, `name`, `dosage`, `price`, `description`) VALUES
('14340', 'brand X', 'Paracetamol', '500mg', '₱1,000.00', 'This is RX'),
('18787', 'brandX', 'HEPAB Vaccine', '10ml', '₱120.00', 'Skin to skin contact.'),
('95191', 'Brand X', 'Solmux', '100mg', '₱12.50', 'rx');

-- --------------------------------------------------------

--
-- Table structure for table `municipalitytbl`
--

CREATE TABLE `municipalitytbl` (
  `id` int(11) NOT NULL,
  `province` varchar(50) NOT NULL,
  `municipality` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `municipalitytbl`
--

INSERT INTO `municipalitytbl` (`id`, `province`, `municipality`) VALUES
(1, 'Maguindanao', 'Ampatuan'),
(2, 'Maguindanao', 'Barira'),
(3, 'Maguindanao', 'Buluan'),
(4, 'Maguindanao', 'Cotabato City'),
(5, 'Maguindanao', 'Datu Abdullah Sangki'),
(6, 'Maguindanao', 'Datu Anggal Midtimbang'),
(7, 'Maguindanao', 'Datu Blah T. Sinsuat'),
(8, 'Maguindanao', 'Datu Hoffer Ampatuan'),
(9, 'Maguindanao', 'Datu Odin Sinsuat'),
(10, 'Maguindanao', 'Datu Paglas'),
(11, 'Maguindanao', 'Datu Piang'),
(12, 'Maguindanao', 'Datu Salibo'),
(13, 'Maguindanao', 'Datu Saudi-Ampatuan'),
(14, 'Maguindanao', 'Datu Unsay'),
(15, 'Maguindanao', 'Gen. S.K. Datun'),
(16, 'Maguindanao', 'Guindulungan'),
(17, 'Maguindanao', 'Kabuntalan'),
(18, 'Maguindanao', 'Maganoy'),
(19, 'Maguindanao', 'Mamasapano'),
(20, 'Maguindanao', 'Mangudadatu'),
(21, 'Maguindanao', 'Matanog'),
(22, 'Maguindanao', 'Northern Kabuntalan'),
(23, 'Maguindanao', 'Pagalungan'),
(24, 'Maguindanao', 'Paglat'),
(25, 'Maguindanao', 'Pandag'),
(26, 'Maguindanao', 'Parang'),
(27, 'Maguindanao', 'Rajah Buayan'),
(28, 'Maguindanao', 'Sharif Aguak'),
(29, 'Maguindanao', 'Shariff Saydona Mustapha'),
(30, 'Maguindanao', 'South Upi'),
(31, 'Maguindanao', 'Sultan Kudarat'),
(32, 'Maguindanao', 'Sultan Mastura'),
(33, 'Maguindanao', 'Sultan Sa Barongis'),
(34, 'Maguindanao', 'Sultan Sumagka'),
(35, 'Maguindanao', 'Talayan'),
(36, 'Maguindanao', 'Upi'),
(39, 'New Province', 'New City');

-- --------------------------------------------------------

--
-- Table structure for table `newbornapgarscore_tbl`
--

CREATE TABLE `newbornapgarscore_tbl` (
  `apgarscoreId` int(11) NOT NULL,
  `newbornid` varchar(20) NOT NULL,
  `appearance` int(11) NOT NULL,
  `pulse` int(11) NOT NULL,
  `grimace` int(11) NOT NULL,
  `activity` int(11) NOT NULL,
  `respiration` int(11) NOT NULL,
  `apgartotalscore` varchar(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `newbornpatient_tbl`
--

CREATE TABLE `newbornpatient_tbl` (
  `newbornid` varchar(20) NOT NULL,
  `motherId` varchar(20) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `suffix` varchar(20) NOT NULL,
  `sex` varchar(20) NOT NULL,
  `dob` date NOT NULL,
  `religion` varchar(50) NOT NULL,
  `weight` text NOT NULL,
  `height` text NOT NULL,
  `headc` text NOT NULL,
  `chestc` text NOT NULL,
  `abdomenc` text NOT NULL,
  `attendantId` varchar(50) NOT NULL,
  `date` date NOT NULL,
  `time` time NOT NULL,
  `status` int(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `nondrugs_tbl`
--

CREATE TABLE `nondrugs_tbl` (
  `id` varchar(11) NOT NULL,
  `brand` varchar(20) NOT NULL,
  `name` varchar(20) NOT NULL,
  `price` text NOT NULL,
  `description` text NOT NULL,
  `usages` varchar(30) NOT NULL DEFAULT '10mg'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `nondrugs_tbl`
--

INSERT INTO `nondrugs_tbl` (`id`, `brand`, `name`, `price`, `description`, `usages`) VALUES
('114608', 'Uniliver', 'Cotton', '₱15.00', 'Cleaning', '10mg'),
('164342', 'Uniliver', 'Cotton', '₱10.00', 'Cotton', '10mg'),
('166484', 'Vics', 'Vaporub', '₱24.00', 'Pain Killer', '10mg'),
('173747', 'Uniliver', 'Cottons Buds', '₱10.00', 'Cotton', '10mg'),
('188299', 'Uniliver', 'Cotton', '₱10.00', 'Cotton', '100 grams'),
('197755', 'Vics', 'Vaporub', '₱23.00', 'Painkiller', '10mg'),
('685226', 'Uniliver', 'Cotton Buds', '₱10.00', 'cotton', '10mg');

-- --------------------------------------------------------

--
-- Table structure for table `patienttbl`
--

CREATE TABLE `patienttbl` (
  `id` varchar(20) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `dateofbirth` date NOT NULL,
  `religion` varchar(50) NOT NULL,
  `contactnum` bigint(20) NOT NULL,
  `addressId` int(11) NOT NULL,
  `street` varchar(50) NOT NULL,
  `house_no` int(11) NOT NULL,
  `married` varchar(50) NOT NULL,
  `husbandfirst` varchar(50) NOT NULL,
  `husbandmiddle` varchar(50) NOT NULL,
  `husbandlast` varchar(50) NOT NULL,
  `husbanddob` date NOT NULL,
  `husbandreligion` varchar(50) NOT NULL,
  `status` int(1) NOT NULL DEFAULT 0,
  `nbs` varchar(10) NOT NULL DEFAULT 'Reffered'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `philippinelocaltbl`
--

CREATE TABLE `philippinelocaltbl` (
  `addressId` int(11) NOT NULL,
  `province` varchar(50) NOT NULL,
  `citymunicipality` varchar(50) NOT NULL,
  `barangay` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `philippinelocaltbl`
--

INSERT INTO `philippinelocaltbl` (`addressId`, `province`, `citymunicipality`, `barangay`) VALUES
(1, 'Maguindanao', 'Parang', 'Bongo Island'),
(2, 'Maguindanao', 'Parang', 'Campo Islam'),
(3, 'Maguindanao', 'Parang', 'Cotongan'),
(4, 'Maguindanao', 'Parang', 'Datu Macarimbang Biruar'),
(5, 'Maguindanao', 'Parang', 'Gadungan'),
(6, 'Maguindanao', 'Parang', 'Gandungan Pedpandaran'),
(7, 'Maguindanao', 'Parang', 'Guiday T. Biruar'),
(8, 'Maguindanao', 'Parang', 'Gumagadong Calawag'),
(9, 'Maguindanao', 'Parang', 'Kabuan'),
(10, 'Maguindanao', 'Parang', 'Landasan'),
(11, 'Maguindanao', 'Parang', 'Limbayan'),
(12, 'Maguindanao', 'Parang', 'Macasandag'),
(13, 'Maguindanao', 'Parang', 'Magsaysay'),
(14, 'Maguindanao', 'Parang', 'Making'),
(15, 'Maguindanao', 'Parang', 'Manion'),
(16, 'Maguindanao', 'Parang', 'Moro Point'),
(17, 'Maguindanao', 'Parang', 'Nituan'),
(18, 'Maguindanao', 'Parang', 'Orandang'),
(19, 'Maguindanao', 'Parang', 'Pinantao'),
(20, 'Maguindanao', 'Parang', 'Poblacion'),
(21, 'Maguindanao', 'Parang', 'Poblacion II'),
(22, 'Maguindanao', 'Parang', 'Polloc'),
(23, 'Maguindanao', 'Parang', 'Samberen'),
(24, 'Maguindanao', 'Parang', 'Tagudtongan'),
(25, 'Maguindanao', 'Parang', 'Tuca-Maror'),
(26, 'Maguindanao', 'Ampatuan', 'Dicalongan'),
(27, 'Maguindanao', 'Ampatuan ', 'Kakal'),
(28, 'Maguindanao', 'Ampatuan', 'Kamasi'),
(29, 'Maguindanao', 'Ampatuan', 'Kapilpilaan'),
(30, 'Maguindanao', 'Ampatuan', 'Kauran'),
(31, 'Maguindanao', 'Ampatuan', 'Malatimon'),
(32, 'Maguindanao', 'Ampatuan', 'Matagabong'),
(33, 'Maguindanao', 'Ampatuan', 'Saniag'),
(34, 'Maguindanao', 'Ampatuan', 'Tomicor'),
(35, 'Maguindanao', 'Ampatuan', 'Tubak'),
(36, 'Maguindanao', 'Ampatuan', 'Salman'),
(37, 'Maguindanao', 'Barira', 'Poblacion'),
(38, 'Maguindanao', 'Barira', 'Bualan'),
(39, 'Maguindanao', 'Barira', 'Gadung'),
(40, 'Maguindanao', 'Barira', 'Korosoyan'),
(41, 'Maguindanao', 'Barira', 'Lamin'),
(42, 'Maguindanao', 'Barira', 'Liong'),
(43, 'Maguindanao', 'Barira', 'Lipa'),
(44, 'Maguindanao', 'Barira', 'Lipawan'),
(45, 'Maguindanao', 'Barira', 'Lipawan'),
(46, 'Maguindanao', 'Barira', 'Marang'),
(47, 'Maguindanao', 'Barira', 'Nabalawag'),
(48, 'Maguindanao', 'Barira', 'Panggao'),
(49, 'Maguindanao', 'Barira', 'Rominimbang'),
(50, 'Maguindanao', 'Barira', 'Togaig'),
(51, 'Maguindanao', 'Barira', 'Minabay'),
(52, 'New Province', 'New City', 'New Brgy');

-- --------------------------------------------------------

--
-- Table structure for table `prenatal`
--

CREATE TABLE `prenatal` (
  `caseNumber` varchar(20) NOT NULL,
  `date` date NOT NULL,
  `lmp` date NOT NULL,
  `time` time NOT NULL,
  `pateintId` varchar(20) NOT NULL,
  `bp` varchar(10) NOT NULL,
  `weight` decimal(5,0) NOT NULL,
  `diagnosis` varchar(100) NOT NULL,
  `attendant` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `prenatal_firsttbl`
--

CREATE TABLE `prenatal_firsttbl` (
  `caseID` int(11) NOT NULL,
  `bp` varchar(10) NOT NULL,
  `wt` varchar(10) NOT NULL,
  `temp` varchar(10) NOT NULL,
  `lmp` date NOT NULL,
  `pal` int(11) NOT NULL,
  `edc` date NOT NULL,
  `followup` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `prenatal_secondtbl`
--

CREATE TABLE `prenatal_secondtbl` (
  `caseID` int(11) NOT NULL,
  `bp` varchar(10) NOT NULL,
  `wt` varchar(10) NOT NULL,
  `temp` varchar(10) NOT NULL,
  `lmp` date NOT NULL,
  `pal` int(11) NOT NULL,
  `edc` date NOT NULL,
  `followup` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `prenatal_thirdtbl`
--

CREATE TABLE `prenatal_thirdtbl` (
  `caseID` int(11) NOT NULL,
  `bp` varchar(10) NOT NULL,
  `wt` varchar(10) NOT NULL,
  `temp` varchar(10) NOT NULL,
  `lmp` date NOT NULL,
  `pal` int(11) NOT NULL,
  `edc` date NOT NULL,
  `followup` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `pricetbl`
--

CREATE TABLE `pricetbl` (
  `itemId` int(11) NOT NULL,
  `itemName` varchar(50) NOT NULL,
  `itemPrice` text NOT NULL,
  `itemType` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `pricetbl`
--

INSERT INTO `pricetbl` (`itemId`, `itemName`, `itemPrice`, `itemType`) VALUES
(1, 'Medicol', '8', 'Medicine'),
(2, 'Paracetamol', '2', 'Medicine'),
(3, 'Consultation', '800', 'Service'),
(4, 'Prenatal', '2', 'Service'),
(5, 'Labor', '250', 'Service'),
(6, 'Checkup', '200', 'Medicine'),
(7, 'Alaxan', '12', 'Service'),
(8, 'Amoxicilin', '6', 'Medicine'),
(9, 'Benadryl 50mg', '37', 'Medicine'),
(10, 'Claritin 10mg', '34', 'Medicine'),
(11, 'Tylenol 650mg', '9', 'Medicine'),
(12, 'Colace 50mg', '551', 'Medicine'),
(13, 'Cetirizine 10mg', '14', 'Medicine'),
(14, 'Robitussine 120ml', '190', 'Medicine'),
(15, 'Imodium 2mg', '18', 'Medicine'),
(16, 'Robitussin 200mg', '12', 'Medicine'),
(17, 'Bacitracin 5mg', '210.25', 'Medicine'),
(18, 'Vitamin B6 1000mg', '38', 'Medicine'),
(20, 'New Service', '3.3', 'Service'),
(21, 'New Meds', '1.1', 'Medicine'),
(22, 'New ', '1.04', 'Medicine'),
(23, 'Check Up', '100', 'Service');

-- --------------------------------------------------------

--
-- Table structure for table `provincetbl`
--

CREATE TABLE `provincetbl` (
  `id` int(11) NOT NULL,
  `province` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `provincetbl`
--

INSERT INTO `provincetbl` (`id`, `province`) VALUES
(1, 'Maguindanao'),
(2, 'Sulu'),
(3, 'Lanao del Sur'),
(4, 'Tawi-Tawi'),
(5, 'Basilan'),
(12, 'New Province');

-- --------------------------------------------------------

--
-- Table structure for table `religiontbl`
--

CREATE TABLE `religiontbl` (
  `id` int(10) NOT NULL,
  `religion` varchar(60) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `religiontbl`
--

INSERT INTO `religiontbl` (`id`, `religion`) VALUES
(1, 'Islam'),
(2, 'Roman Catholic'),
(3, 'Iglesia ni Cristo'),
(4, 'Seventh-day Adventist Church'),
(5, 'Jehovah\'s Witnesses '),
(6, 'United Church of Christ in the Philippines'),
(7, 'United Pentecostal Church'),
(8, 'Church of God'),
(9, 'Church of Christ'),
(10, 'Born Again'),
(11, 'Southern Baptist'),
(12, 'Aglipay'),
(13, 'Jesus is Lord'),
(14, 'Alliance'),
(15, 'Bible Baptist');

-- --------------------------------------------------------

--
-- Table structure for table `reportinfotbl`
--

CREATE TABLE `reportinfotbl` (
  `report` varchar(20) NOT NULL,
  `from` date NOT NULL,
  `to` date NOT NULL,
  `total` int(11) NOT NULL,
  `preparedBy` varchar(100) NOT NULL,
  `attendant` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `reportinfotbl`
--

INSERT INTO `reportinfotbl` (`report`, `from`, `to`, `total`, `preparedBy`, `attendant`) VALUES
('1', '2022-01-19', '2022-01-05', 0, 'Admin', 'Admin');

-- --------------------------------------------------------

--
-- Table structure for table `roombed_tbl`
--

CREATE TABLE `roombed_tbl` (
  `roomBed_Id` varchar(11) NOT NULL,
  `roomName` varchar(50) NOT NULL,
  `bedNo` varchar(50) DEFAULT NULL,
  `type` varchar(20) NOT NULL,
  `price` text NOT NULL,
  `status` int(11) NOT NULL DEFAULT 0,
  `roomType` varchar(20) NOT NULL,
  `capacity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `roombed_tbl`
--

INSERT INTO `roombed_tbl` (`roomBed_Id`, `roomName`, `bedNo`, `type`, `price`, `status`, `roomType`, `capacity`) VALUES
('1111111', 'Room C', '', 'Room', '', 0, 'Ward', 5),
('2111111', 'Room A', '', 'Room', '', 0, 'Ward', 2),
('3107628', 'Private 1', '', 'Room', '', 0, 'Private', 1),
('3111111', 'Room B', '', 'Room', '', 0, 'Ward', 5),
('3239674', 'Private 3', '', 'Room', '', 0, 'Private', 1),
('3458869', 'Private 1', '1', 'Bed', '₱1,000.00', 1, '', 0),
('3597328', 'Private 2', '1', 'Bed', '₱15,000.00', 0, '', 0),
('3923557', 'Private 2', '', 'Room', '', 0, 'Private', 1),
('5111111', 'Room D', '', 'Room', '', 0, 'Ward', 5),
('7111111', 'Room A', '12', 'Bed', '₱300.00', 0, '', 0),
('8111111', 'Room A', '1111', 'Bed', '₱1,100.00', 0, '', 0);

-- --------------------------------------------------------

--
-- Table structure for table `servicetbl`
--

CREATE TABLE `servicetbl` (
  `serviceID` int(11) NOT NULL,
  `service_Type` varchar(50) NOT NULL,
  `servicefee` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `servicetbl`
--

INSERT INTO `servicetbl` (`serviceID`, `service_Type`, `servicefee`) VALUES
(1, 'Consultation', '500.00'),
(2, 'Prenatal', '250.00'),
(3, 'Labor', '500.00');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `userlevel` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `userlevel`, `name`) VALUES
(1, 'admin', 'admin123', 1, 'Safrah Pandarat');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admittedpateinttbl`
--
ALTER TABLE `admittedpateinttbl`
  ADD PRIMARY KEY (`caseNumber`);

--
-- Indexes for table `amstlandeinc`
--
ALTER TABLE `amstlandeinc`
  ADD PRIMARY KEY (`newbornid`);

--
-- Indexes for table `bills`
--
ALTER TABLE `bills`
  ADD PRIMARY KEY (`invoiceNumber`);

--
-- Indexes for table `brand_tbl`
--
ALTER TABLE `brand_tbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `discharge_tbl`
--
ALTER TABLE `discharge_tbl`
  ADD PRIMARY KEY (`caseNumber`);

--
-- Indexes for table `discount_tbl`
--
ALTER TABLE `discount_tbl`
  ADD PRIMARY KEY (`discountId`);

--
-- Indexes for table `employeetbl`
--
ALTER TABLE `employeetbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `employeetitletbl`
--
ALTER TABLE `employeetitletbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `medicine_tbl`
--
ALTER TABLE `medicine_tbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `municipalitytbl`
--
ALTER TABLE `municipalitytbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `newbornpatient_tbl`
--
ALTER TABLE `newbornpatient_tbl`
  ADD PRIMARY KEY (`newbornid`);

--
-- Indexes for table `nondrugs_tbl`
--
ALTER TABLE `nondrugs_tbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `patienttbl`
--
ALTER TABLE `patienttbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `philippinelocaltbl`
--
ALTER TABLE `philippinelocaltbl`
  ADD PRIMARY KEY (`addressId`);

--
-- Indexes for table `prenatal_firsttbl`
--
ALTER TABLE `prenatal_firsttbl`
  ADD PRIMARY KEY (`caseID`);

--
-- Indexes for table `prenatal_secondtbl`
--
ALTER TABLE `prenatal_secondtbl`
  ADD PRIMARY KEY (`caseID`);

--
-- Indexes for table `prenatal_thirdtbl`
--
ALTER TABLE `prenatal_thirdtbl`
  ADD PRIMARY KEY (`caseID`);

--
-- Indexes for table `pricetbl`
--
ALTER TABLE `pricetbl`
  ADD PRIMARY KEY (`itemId`);

--
-- Indexes for table `provincetbl`
--
ALTER TABLE `provincetbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `religiontbl`
--
ALTER TABLE `religiontbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `reportinfotbl`
--
ALTER TABLE `reportinfotbl`
  ADD PRIMARY KEY (`report`);

--
-- Indexes for table `roombed_tbl`
--
ALTER TABLE `roombed_tbl`
  ADD PRIMARY KEY (`roomBed_Id`);

--
-- Indexes for table `servicetbl`
--
ALTER TABLE `servicetbl`
  ADD PRIMARY KEY (`serviceID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `discount_tbl`
--
ALTER TABLE `discount_tbl`
  MODIFY `discountId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `employeetbl`
--
ALTER TABLE `employeetbl`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employeetitletbl`
--
ALTER TABLE `employeetitletbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `municipalitytbl`
--
ALTER TABLE `municipalitytbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT for table `philippinelocaltbl`
--
ALTER TABLE `philippinelocaltbl`
  MODIFY `addressId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=53;

--
-- AUTO_INCREMENT for table `prenatal_firsttbl`
--
ALTER TABLE `prenatal_firsttbl`
  MODIFY `caseID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `prenatal_secondtbl`
--
ALTER TABLE `prenatal_secondtbl`
  MODIFY `caseID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `prenatal_thirdtbl`
--
ALTER TABLE `prenatal_thirdtbl`
  MODIFY `caseID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `pricetbl`
--
ALTER TABLE `pricetbl`
  MODIFY `itemId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT for table `provincetbl`
--
ALTER TABLE `provincetbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `religiontbl`
--
ALTER TABLE `religiontbl`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `servicetbl`
--
ALTER TABLE `servicetbl`
  MODIFY `serviceID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
