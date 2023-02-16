-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 12, 2021 at 08:45 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.4

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
-- Table structure for table `add_to_list`
--

CREATE TABLE `add_to_list` (
  `item_id` int(11) NOT NULL,
  `patient_id` int(11) NOT NULL,
  `description` varchar(50) NOT NULL,
  `qty` int(50) NOT NULL,
  `unit_price` int(50) NOT NULL,
  `total` int(50) NOT NULL,
  `invoice_no` varchar(50) NOT NULL,
  `invoice_date` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `add_to_list`
--

INSERT INTO `add_to_list` (`item_id`, `patient_id`, `description`, `qty`, `unit_price`, `total`, `invoice_no`, `invoice_date`) VALUES
(1, 0, 'Consultation', 0, 500, 500, '202112120005316', '2021-12-12'),
(2, 0, 'Kisspirin', 2, 100, 200, '202112120002582', '2021-12-12'),
(3, 0, 'Kisspirin', 1, 100, 100, '202112120031524', '2021-12-12');

-- --------------------------------------------------------

--
-- Table structure for table `admissiontbl`
--

CREATE TABLE `admissiontbl` (
  `case_id` int(11) NOT NULL,
  `p_id` int(11) NOT NULL,
  `p_name` varchar(250) NOT NULL,
  `p_age` int(2) NOT NULL,
  `p_DOB` date NOT NULL,
  `p_DT` date NOT NULL,
  `p_Time` time NOT NULL,
  `p_attendant` varchar(250) NOT NULL,
  `p_bp` varchar(11) NOT NULL,
  `p_wt` varchar(10) NOT NULL,
  `p_temp` varchar(10) NOT NULL,
  `p_diagnosis` varchar(250) NOT NULL,
  `p_finaldiagnosis` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admissiontbl`
--

INSERT INTO `admissiontbl` (`case_id`, `p_id`, `p_name`, `p_age`, `p_DOB`, `p_DT`, `p_Time`, `p_attendant`, `p_bp`, `p_wt`, `p_temp`, `p_diagnosis`, `p_finaldiagnosis`) VALUES
(1, 6, 'Jose P Rizal', 21, '2000-12-29', '2021-12-11', '10:14:07', '0 0 Crossing Barira Barira Maguindanao', '100', '56', '66', 'covid', 'covid\n'),
(2, 7, 'Andres P Bonifacio', 0, '2009-11-12', '2021-12-11', '10:40:00', ' 0 Crossing Barira Barira Maguindanao', '', '', '', 'asasd', 'asdasdasdas');

-- --------------------------------------------------------

--
-- Table structure for table `childrentbl`
--

CREATE TABLE `childrentbl` (
  `id` int(11) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `middle_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `p_DOB` date NOT NULL,
  `age` int(2) NOT NULL,
  `sex` varchar(50) NOT NULL,
  `religion` varchar(50) NOT NULL,
  `mother` varchar(150) NOT NULL,
  `father` varchar(150) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `childrentbl`
--

INSERT INTO `childrentbl` (`id`, `first_name`, `middle_name`, `last_name`, `p_DOB`, `age`, `sex`, `religion`, `mother`, `father`) VALUES
(3, 'Jerry Mae', 'asda', 'asdasda', '2021-12-02', 0, '', '', 'ssss', ''),
(4, 'Jaun', 'dela', 'Cruz', '2019-12-03', 2, 'Male', 'Christian', 'Maria', 'Mario'),
(5, 'Maria', '', 'Clara', '2019-11-28', 2, 'Female', 'Christian', 'Sisa', 'Damasu'),
(6, 'Basilio', '', 'Sisa', '2009-12-03', 12, 'Male', 'Catholic', 'Sisa', 'Alipin'),
(7, 'Jose ', '', 'Rizal', '2021-12-09', 0, 'Male', 'Catholic', 'Maria', 'Jose'),
(8, 'Marry', '', 'christmas', '2021-12-09', 0, 'Female', 'Born Again', 'Mama', 'Papa');

-- --------------------------------------------------------

--
-- Table structure for table `consultationtbl`
--

CREATE TABLE `consultationtbl` (
  `case_id` int(11) NOT NULL,
  `p_id` int(11) NOT NULL,
  `p_name` varchar(250) NOT NULL,
  `p_age` varchar(10) NOT NULL,
  `p_DOB` date NOT NULL,
  `p_DT` date NOT NULL,
  `p_attendant` varchar(150) NOT NULL,
  `p_Time` time NOT NULL,
  `p_bp` varchar(7) NOT NULL,
  `p_wt` varchar(20) NOT NULL,
  `p_temp` varchar(20) NOT NULL,
  `p_symptoms` varchar(250) NOT NULL,
  `p_medication` varchar(250) NOT NULL,
  `p_diagnosis` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `consultationtbl`
--

INSERT INTO `consultationtbl` (`case_id`, `p_id`, `p_name`, `p_age`, `p_DOB`, `p_DT`, `p_attendant`, `p_Time`, `p_bp`, `p_wt`, `p_temp`, `p_symptoms`, `p_medication`, `p_diagnosis`) VALUES
(1, 4, 'Sadafa  qasawa', '32 years o', '1989-08-13', '0000-00-00', '', '00:00:00', '60-20', '63', '36.6', 'Fever', 'Paracetamol', 'Fever'),
(2, 4, 'Sadafa  qasawa', '32 years o', '1989-08-13', '2021-10-29', '', '09:06:54', '60-120', '45', '36.7', 'fever', 'paracetamol', 'fever'),
(3, 6, 'Jose P Rizal', '0 years ol', '2021-11-12', '2021-11-12', '', '10:08:06', '80-120', '50', '38.7', 'Fever', 'water', '');

-- --------------------------------------------------------

--
-- Table structure for table `dischargetbl`
--

CREATE TABLE `dischargetbl` (
  `case_id` int(11) NOT NULL,
  `p_id` int(11) NOT NULL,
  `p_name` varchar(250) NOT NULL,
  `p_age` int(2) NOT NULL,
  `p_DOB` date NOT NULL,
  `p_DT` datetime NOT NULL,
  `p_address` varchar(250) NOT NULL,
  `p_bp` varchar(10) NOT NULL,
  `p_wt` varchar(10) NOT NULL,
  `p_temp` varchar(10) NOT NULL,
  `p_medathome` varchar(250) NOT NULL,
  `p_dateofdelivery` datetime NOT NULL,
  `p_followup` date NOT NULL,
  `p_remarks` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

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
  `street` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `employeetbl`
--

INSERT INTO `employeetbl` (`id`, `firstname`, `middlename`, `lastname`, `dateofbirth`, `age`, `title`, `license`, `religion`, `contactnumber`, `province`, `city/mun`, `barangay`, `houseno`, `street`) VALUES
(5, 'Noralyn', 'Mendoza', 'Abdulwahab', '1999-05-08', 23, 'Midwife', '', '', '(953) 402-6459', '', '', '', 0, ''),
(7, 'Gabriela', 'short', 'Silang', '2000-11-12', 21, 'Midwife', '', '', '(000) 000-0000', '', '', '', 0, ''),
(8, 'Bea', 'long', 'Alonzo', '2000-11-12', 21, 'Nurse', '', '', '(000) 000-0000', '', '', '', 0, ''),
(9, 'Boi', '', 'Luna', '2003-12-11', 18, 'Intern', '', 'Islam', '(727) 277-2772', 'Maguindanao', 'Ampatuan', 'none', 0, ''),
(10, 'Hamdi', '', 'Abdulsamad', '2003-12-11', 18, 'Intern', '', 'Islam', '(923) 231-2312', 'Maguindanao', 'Ampatuan', 'none', 0, ''),
(11, 'Hezron', '', 'Hermosa', '2003-12-11', 18, 'Intern', '', 'Born Again', '(112) 121-2121', 'Maguindanao', 'Ampatuan', 'none', 0, '');

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
(6, 'Intern');

-- --------------------------------------------------------

--
-- Table structure for table `medicinetbl`
--

CREATE TABLE `medicinetbl` (
  `medicineID` int(11) NOT NULL,
  `medicine_name` text NOT NULL,
  `medicine_price` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `medicinetbl`
--

INSERT INTO `medicinetbl` (`medicineID`, `medicine_name`, `medicine_price`) VALUES
(1, 'Kisspirin', '100'),
(2, 'Yakapsule', '50');

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
(3, 'Maguindanao', 'Buldon');

-- --------------------------------------------------------

--
-- Table structure for table `patienttbl`
--

CREATE TABLE `patienttbl` (
  `id` int(11) NOT NULL,
  `firstname` varchar(50) NOT NULL,
  `middlename` varchar(50) NOT NULL,
  `lastname` varchar(50) NOT NULL,
  `dateofbirth` date NOT NULL,
  `age` int(11) NOT NULL,
  `religion` varchar(50) NOT NULL,
  `contactnum` varchar(14) NOT NULL,
  `province` varchar(50) NOT NULL,
  `municipality` varchar(50) NOT NULL,
  `barangay` varchar(50) NOT NULL,
  `street` varchar(50) NOT NULL,
  `house_no` int(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `patienttbl`
--

INSERT INTO `patienttbl` (`id`, `firstname`, `middlename`, `lastname`, `dateofbirth`, `age`, `religion`, `contactnum`, `province`, `municipality`, `barangay`, `street`, `house_no`) VALUES
(6, 'Jose', 'P', 'Rizal', '2000-12-29', 21, 'Born Again', '(000) 000-0000', 'Maguindanao', 'Barira', 'Crossing Barira', '0', 0),
(7, 'Andres', 'P', 'Bonifacio', '2009-11-12', 0, 'aasa', '(000) 000-0000', 'Maguindanao', 'Barira', 'Crossing Barira', '', 0);

-- --------------------------------------------------------

--
-- Table structure for table `patienttypetbl`
--

CREATE TABLE `patienttypetbl` (
  `id` int(11) NOT NULL,
  `patienttype` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `philippinelocaltbl`
--

CREATE TABLE `philippinelocaltbl` (
  `id` int(11) NOT NULL,
  `province` varchar(50) NOT NULL,
  `citymunicipality` varchar(50) NOT NULL,
  `barangay` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `philippinelocaltbl`
--

INSERT INTO `philippinelocaltbl` (`id`, `province`, `citymunicipality`, `barangay`) VALUES
(6, 'Maguindanao', 'Ampatuan', 'none');

-- --------------------------------------------------------

--
-- Table structure for table `prenataltbl`
--

CREATE TABLE `prenataltbl` (
  `case_id` int(11) NOT NULL,
  `p_id` int(11) NOT NULL,
  `p_name` varchar(250) NOT NULL,
  `p_age` int(2) NOT NULL,
  `p_DOB` date NOT NULL,
  `p_DT` date NOT NULL,
  `p_Time` time NOT NULL,
  `p_address` varchar(250) NOT NULL,
  `p_trimester` text NOT NULL,
  `p_bp` varchar(10) NOT NULL,
  `p_wt` varchar(10) NOT NULL,
  `p_temp` varchar(10) NOT NULL,
  `p_pal` varchar(50) NOT NULL,
  `p_lmp` date NOT NULL,
  `p_edc` date NOT NULL,
  `p_followup` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `prenataltbl`
--

INSERT INTO `prenataltbl` (`case_id`, `p_id`, `p_name`, `p_age`, `p_DOB`, `p_DT`, `p_Time`, `p_address`, `p_trimester`, `p_bp`, `p_wt`, `p_temp`, `p_pal`, `p_lmp`, `p_edc`, `p_followup`) VALUES
(3, 6, 'Jose P Rizal', 0, '2021-11-12', '2021-11-12', '10:15:03', '0  Crossing Barira Barira Maguindanao', 'Trimester', '90-120', '50', '36.7', '2 weeks ', '2021-11-12', '2020-11-13', '2021-08-13'),
(4, 6, 'Jose P Rizal', 21, '2000-12-29', '2021-12-11', '23:59:47', '', 'Trimester', '', '', '', '', '2021-08-13', '2021-08-13', '2021-08-13');

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
(5, 'Basilan');

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
(45, 'Islam'),
(46, 'Catholic'),
(47, 'Iglesia Ni Cristo'),
(48, 'Baptist'),
(49, 'Born Again');

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
(1, 'admin', 'admin123', 1, 'Safrah G. Pandarat'),
(3, 'adil', '1234', 1, 'Hamdi Abdulsamad');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `add_to_list`
--
ALTER TABLE `add_to_list`
  ADD PRIMARY KEY (`item_id`),
  ADD KEY `patient_id` (`patient_id`);

--
-- Indexes for table `admissiontbl`
--
ALTER TABLE `admissiontbl`
  ADD PRIMARY KEY (`case_id`);

--
-- Indexes for table `childrentbl`
--
ALTER TABLE `childrentbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `consultationtbl`
--
ALTER TABLE `consultationtbl`
  ADD PRIMARY KEY (`case_id`);

--
-- Indexes for table `dischargetbl`
--
ALTER TABLE `dischargetbl`
  ADD PRIMARY KEY (`case_id`);

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
-- Indexes for table `medicinetbl`
--
ALTER TABLE `medicinetbl`
  ADD PRIMARY KEY (`medicineID`);

--
-- Indexes for table `municipalitytbl`
--
ALTER TABLE `municipalitytbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `patienttbl`
--
ALTER TABLE `patienttbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `patienttypetbl`
--
ALTER TABLE `patienttypetbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `philippinelocaltbl`
--
ALTER TABLE `philippinelocaltbl`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `prenataltbl`
--
ALTER TABLE `prenataltbl`
  ADD PRIMARY KEY (`case_id`);

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
-- AUTO_INCREMENT for table `add_to_list`
--
ALTER TABLE `add_to_list`
  MODIFY `item_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `admissiontbl`
--
ALTER TABLE `admissiontbl`
  MODIFY `case_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `childrentbl`
--
ALTER TABLE `childrentbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `consultationtbl`
--
ALTER TABLE `consultationtbl`
  MODIFY `case_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `dischargetbl`
--
ALTER TABLE `dischargetbl`
  MODIFY `case_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `employeetbl`
--
ALTER TABLE `employeetbl`
  MODIFY `id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `employeetitletbl`
--
ALTER TABLE `employeetitletbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `medicinetbl`
--
ALTER TABLE `medicinetbl`
  MODIFY `medicineID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `municipalitytbl`
--
ALTER TABLE `municipalitytbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `patienttbl`
--
ALTER TABLE `patienttbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `patienttypetbl`
--
ALTER TABLE `patienttypetbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `philippinelocaltbl`
--
ALTER TABLE `philippinelocaltbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `prenataltbl`
--
ALTER TABLE `prenataltbl`
  MODIFY `case_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

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
-- AUTO_INCREMENT for table `provincetbl`
--
ALTER TABLE `provincetbl`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `religiontbl`
--
ALTER TABLE `religiontbl`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=50;

--
-- AUTO_INCREMENT for table `servicetbl`
--
ALTER TABLE `servicetbl`
  MODIFY `serviceID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
