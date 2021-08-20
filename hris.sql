-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 13, 2021 at 05:15 AM
-- Server version: 10.4.13-MariaDB
-- PHP Version: 7.4.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hris`
--
CREATE DATABASE IF NOT EXISTS `hris` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `hris`;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_employee`
--

DROP TABLE IF EXISTS `tbl_employee`;
CREATE TABLE IF NOT EXISTS `tbl_employee` (
  `emp_id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_code` text NOT NULL,
  `emp_first` text NOT NULL,
  `emp_last` text NOT NULL,
  `emp_mid` text NOT NULL,
  `emp_address` text NOT NULL,
  `emp_city` text NOT NULL,
  `emp_state` text NOT NULL,
  `emp_zipcode` text NOT NULL,
  `emp_contact` text NOT NULL,
  `emp_gender` text NOT NULL,
  `emp_birth` text NOT NULL,
  `emp_age` text NOT NULL,
  `emp_hired_date` text NOT NULL,
  `status` text NOT NULL,
  PRIMARY KEY (`emp_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Table structure for table `tbl_employee_list`
--

DROP TABLE IF EXISTS `tbl_employee_list`;
CREATE TABLE IF NOT EXISTS `tbl_employee_list` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `companycode` text NOT NULL,
  `usercode` text NOT NULL,
  `fullname` text NOT NULL,
  `createdat` text NOT NULL,
  `status` text NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


--
-- Table structure for table `tbl_hr`
--

DROP TABLE IF EXISTS `tbl_hr`;
CREATE TABLE IF NOT EXISTS `tbl_hr` (
  `hr_id` int(11) NOT NULL AUTO_INCREMENT,
  `hr_code` text NOT NULL,
  `hr_username` text NOT NULL,
  `hr_password` text NOT NULL,
  `hr_first` text NOT NULL,
  `hr_last` text NOT NULL,
  `position` text NOT NULL,
  PRIMARY KEY (`hr_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_leave`
--

DROP TABLE IF EXISTS `tbl_leave`;
CREATE TABLE IF NOT EXISTS `tbl_leave` (
  `lv_id` int(11) NOT NULL AUTO_INCREMENT,
  `lv_title` int(11) NOT NULL,
  `lv_datefrom` text NOT NULL,
  `lv_dateto` text NOT NULL,
  PRIMARY KEY (`lv_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Table structure for table `tbl_salary`
--

DROP TABLE IF EXISTS `tbl_salary`;
CREATE TABLE IF NOT EXISTS `tbl_salary` (
  `sal_id` int(11) NOT NULL AUTO_INCREMENT,
  `emp_code` int(11) NOT NULL,
  `department` text NOT NULL,
  `title` text NOT NULL,
  `location` text NOT NULL,
  `salary` double(11,2) NOT NULL,
  `action` text NOT NULL,
  `date_created` text NOT NULL,
  `status` text NOT NULL,
  PRIMARY KEY (`sal_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Table structure for table `tbl_settings`
--

DROP TABLE IF EXISTS `tbl_settings`;
CREATE TABLE IF NOT EXISTS `tbl_settings` (
  `settings_id` int(11) NOT NULL AUTO_INCREMENT,
  `C_Server` text NOT NULL,
  `C_Username` text NOT NULL,
  `C_Password` text NOT NULL,
  `C_Database` text NOT NULL,
  `C_Port` text NOT NULL,
  PRIMARY KEY (`settings_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Table structure for table `tbl_user_logs`
--

DROP TABLE IF EXISTS `tbl_user_logs`;
CREATE TABLE IF NOT EXISTS `tbl_user_logs` (
  `log_id` int(11) NOT NULL AUTO_INCREMENT,
  `srv_localregdate` text NOT NULL,
  `srv_companyname` text NOT NULL,
  `srv_devicename` text NOT NULL,
  `srv_usercode` text NOT NULL,
  `srv_address` text NOT NULL,
  `srv_logtype` text NOT NULL,
  `srv_logdesc` text NOT NULL,
  `srv_longitude` text NOT NULL,
  `srv_latitude` text NOT NULL,
  `srv_image` text NOT NULL,
  `srv_createdat` text NOT NULL,
  `srv_status` text NOT NULL,
  `date_created` text NOT NULL,
  PRIMARY KEY (`log_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Table structure for table `triggers_tbl_employee_list`
--

DROP TABLE IF EXISTS `triggers_tbl_employee_list`;
CREATE TABLE IF NOT EXISTS `triggers_tbl_employee_list` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `companycode` text NOT NULL,
  `usercode` text NOT NULL,
  `fullname` text NOT NULL,
  `createdat` text NOT NULL,
  `status` text NOT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
--
-- Triggers `triggers_tbl_employee_list`
--
DROP TRIGGER IF EXISTS `Copy_to_user_list`;
DELIMITER $$
CREATE TRIGGER `Copy_to_user_list` AFTER INSERT ON `triggers_tbl_employee_list` FOR EACH ROW INSERT INTO tbl_employee_list(`companycode`, `usercode`, `fullname`, `createdat`, `status`)
SELECT  `user_id`, `companycode`, `usercode`, `fullname`, `createdat`, `status`
  FROM triggers_tbl_employee_list
 WHERE NOT EXISTS(SELECT `user_id`, `companycode`, `usercode`, `fullname`, `createdat`, `status` FROM tbl_employee_list WHERE tbl_employee_list.usercode = triggers_tbl_employee_list.usercode )
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `triggers_tbl_user_logs`
--

DROP TABLE IF EXISTS `triggers_tbl_user_logs`;
CREATE TABLE IF NOT EXISTS `triggers_tbl_user_logs` (
  `log_id` int(11) NOT NULL AUTO_INCREMENT,
  `srv_localregdate` text NOT NULL,
  `srv_companyname` text NOT NULL,
  `srv_devicename` text NOT NULL,
  `srv_usercode` text NOT NULL,
  `srv_address` text NOT NULL,
  `srv_logtype` text NOT NULL,
  `srv_logdesc` text NOT NULL,
  `srv_longitude` text NOT NULL,
  `srv_latitude` text NOT NULL,
  `srv_image` text NOT NULL,
  `srv_createdat` text NOT NULL,
  `srv_status` text NOT NULL,
  `date_created` text NOT NULL,
  PRIMARY KEY (`log_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Triggers `triggers_tbl_user_logs`
--
DROP TRIGGER IF EXISTS `Copy_to_user_logs`;
DELIMITER $$
CREATE TRIGGER `Copy_to_user_logs` AFTER INSERT ON `triggers_tbl_user_logs` FOR EACH ROW INSERT INTO tbl_user_logs( `srv_localregdate`, `srv_companyname`, `srv_devicename`, `srv_usercode`, `srv_address`, `srv_logtype`, `srv_logdesc`, `srv_longitude`, `srv_latitude`, `srv_image`, `srv_createdat`, `srv_status`, `date_created`)
SELECT  `srv_localregdate`, `srv_companyname`, `srv_devicename`, `srv_usercode`, `srv_address`, `srv_logtype`, `srv_logdesc`, `srv_longitude`, `srv_latitude`, `srv_image`, `srv_createdat`, `srv_status`, `date_created`
  FROM triggers_tbl_user_logs
 WHERE NOT EXISTS(SELECT  `srv_localregdate`, `srv_companyname`, `srv_devicename`, `srv_usercode`, `srv_address`, `srv_logtype`, `srv_logdesc`, `srv_longitude`, `srv_latitude`, `srv_image`, `srv_createdat`, `srv_status`, `date_created`FROM tbl_user_logs WHERE tbl_user_logs.srv_localregdate = triggers_tbl_user_logs.srv_localregdate )
$$
DELIMITER ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
