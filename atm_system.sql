-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 25, 2022 at 12:02 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `atm_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `add_from_card`
--

CREATE TABLE `add_from_card` (
  `account_type` varchar(20) NOT NULL,
  `username` varchar(30) NOT NULL,
  `transaction_id` varchar(30) NOT NULL,
  `amount` varchar(30) NOT NULL,
  `card_no` varchar(30) NOT NULL,
  `name_on_card` varchar(30) NOT NULL,
  `expiry` varchar(30) NOT NULL,
  `cvv_cvc` varchar(20) NOT NULL,
  `date` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `add_money`
--

CREATE TABLE `add_money` (
  `account_type` varchar(30) NOT NULL,
  `username` varchar(30) NOT NULL,
  `number` varchar(30) NOT NULL,
  `amount` varchar(30) NOT NULL,
  `wallet_type` varchar(30) NOT NULL,
  `transaction_id` varchar(30) NOT NULL,
  `date` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `admin_id` varchar(20) NOT NULL,
  `pin` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`admin_id`, `pin`) VALUES
('admin', 1234);

-- --------------------------------------------------------

--
-- Table structure for table `bill_history`
--

CREATE TABLE `bill_history` (
  `username` varchar(30) NOT NULL,
  `bill_id` varchar(30) NOT NULL,
  `amount` varchar(30) NOT NULL,
  `date` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `blocked_ac`
--

CREATE TABLE `blocked_ac` (
  `name` varchar(30) NOT NULL,
  `phone` varchar(30) NOT NULL,
  `permanent_ad` varchar(30) NOT NULL,
  `present_ad` varchar(30) NOT NULL,
  `gender` int(30) NOT NULL,
  `nid` int(30) NOT NULL,
  `occupation` varchar(30) NOT NULL,
  `monthly_income` varchar(30) NOT NULL,
  `username` varchar(30) NOT NULL,
  `pin` int(20) NOT NULL,
  `ac_no` varchar(20) NOT NULL,
  `date` varchar(20) NOT NULL,
  `balance` int(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `blocked_card`
--

CREATE TABLE `blocked_card` (
  `name` varchar(30) NOT NULL,
  `phone` varchar(30) NOT NULL,
  `permanent_ad` varchar(30) NOT NULL,
  `present_ad` varchar(30) NOT NULL,
  `gender` int(30) NOT NULL,
  `nid` int(30) NOT NULL,
  `occupation` varchar(30) NOT NULL,
  `monthly_income` int(30) NOT NULL,
  `username` varchar(30) NOT NULL,
  `pin` int(30) NOT NULL,
  `card_no` varchar(30) NOT NULL,
  `date` varchar(30) NOT NULL,
  `balance` int(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `crypto_history`
--

CREATE TABLE `crypto_history` (
  `username` varchar(30) NOT NULL,
  `account_type` varchar(30) NOT NULL,
  `sender_address` varchar(50) NOT NULL,
  `reciever_ad` varchar(30) NOT NULL,
  `amount_bought` varchar(30) NOT NULL,
  `currency` varchar(30) NOT NULL,
  `transaction_id` varchar(30) NOT NULL,
  `date` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `crypto_history`
--

INSERT INTO `crypto_history` (`username`, `account_type`, `sender_address`, `reciever_ad`, `amount_bought`, `currency`, `transaction_id`, `date`) VALUES
('Kabbo45', 'Bank', 'miYNKf3KGgo1Mtrggkw4MjdSjPQihF6zdr', 'sdjsihfusduzikjd', '0.000004771902206063941', 'Bitcoin', 'CRYATM6379421238', '07-23-2022');

-- --------------------------------------------------------

--
-- Table structure for table `crypto_price`
--

CREATE TABLE `crypto_price` (
  `btc` varchar(30) NOT NULL,
  `eth` varchar(30) NOT NULL,
  `ada` varchar(30) NOT NULL,
  `sol` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `crypto_price`
--

INSERT INTO `crypto_price` (`btc`, `eth`, `ada`, `sol`) VALUES
('2095600.3640000003', '144012.4442', '46.0894', '3793.4398');

-- --------------------------------------------------------

--
-- Table structure for table `demand_bill`
--

CREATE TABLE `demand_bill` (
  `username` varchar(30) NOT NULL,
  `bill_id` varchar(30) NOT NULL,
  `amount` varchar(30) NOT NULL,
  `status` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `donation`
--

CREATE TABLE `donation` (
  `username` varchar(30) NOT NULL,
  `donated_to` varchar(60) NOT NULL,
  `amount` varchar(30) NOT NULL,
  `name` varchar(30) NOT NULL,
  `phone_number` varchar(30) NOT NULL,
  `date` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `payment_history`
--

CREATE TABLE `payment_history` (
  `account_type` varchar(30) NOT NULL,
  `username` varchar(30) NOT NULL,
  `payment_id` varchar(30) NOT NULL,
  `amount` varchar(30) NOT NULL,
  `transaction_id` varchar(30) NOT NULL,
  `date` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `ratings`
--

CREATE TABLE `ratings` (
  `name` varchar(40) NOT NULL,
  `email` varchar(30) NOT NULL,
  `username` varchar(10) NOT NULL,
  `queries` varchar(400) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ratings`
--

INSERT INTO `ratings` (`name`, `email`, `username`, `queries`) VALUES
('test', 'test', 'Guest', 'tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt'),
('test', 'test', 'Guest', 'ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt'),
('Tunazzinur Rahman Kabbo', 'kabbo4545@gmail.com', 'Kabbo45', 'ii');

-- --------------------------------------------------------

--
-- Table structure for table `reg_bank`
--

CREATE TABLE `reg_bank` (
  `name` varchar(30) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `permanent_ad` varchar(100) NOT NULL,
  `present_ad` varchar(100) NOT NULL,
  `gender` int(20) NOT NULL,
  `nid` int(20) NOT NULL,
  `occupation` varchar(20) NOT NULL,
  `monthly_income` int(20) NOT NULL,
  `email` varchar(40) NOT NULL,
  `username` varchar(20) NOT NULL,
  `pin` int(20) NOT NULL,
  `ac_no` varchar(30) NOT NULL,
  `date` varchar(30) NOT NULL,
  `balance` int(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `reg_bank`
--

INSERT INTO `reg_bank` (`name`, `phone`, `permanent_ad`, `present_ad`, `gender`, `nid`, `occupation`, `monthly_income`, `email`, `username`, `pin`, `ac_no`, `date`, `balance`) VALUES
('Tunazzinur Rahman Kabbo', '+8801876787213', 'House No: 71, Road No: 21, Rupnagar, Mirpur-02, Dhaka', 'House No: 71, Road No: 21, Rupnagar, Mirpur-02, Dhaka', 1, 123456789, 'Student', 10000, 'kabbo4545@gmail.com', 'Kabbo45', 1234, 'AC83301120', 'Saturday, July 23, 2022', 390);

-- --------------------------------------------------------

--
-- Table structure for table `reg_card`
--

CREATE TABLE `reg_card` (
  `name` varchar(30) NOT NULL,
  `phone` varchar(20) NOT NULL,
  `permanent_ad` varchar(100) NOT NULL,
  `present_ad` varchar(100) NOT NULL,
  `gender` int(20) NOT NULL,
  `nid` int(20) NOT NULL,
  `occupation` varchar(20) NOT NULL,
  `monthly_income` int(20) NOT NULL,
  `email` varchar(40) NOT NULL,
  `username` varchar(20) NOT NULL,
  `pin` int(20) NOT NULL,
  `card_no` varchar(30) NOT NULL,
  `date` varchar(30) NOT NULL,
  `balance` int(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `transfer_history`
--

CREATE TABLE `transfer_history` (
  `transferer_account_type` varchar(30) NOT NULL,
  `username` varchar(30) NOT NULL,
  `ammount` varchar(30) NOT NULL,
  `transaction_id` varchar(30) NOT NULL,
  `transfer_to` varchar(30) NOT NULL,
  `transfer_type` varchar(30) NOT NULL,
  `date` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `transfer_history`
--

INSERT INTO `transfer_history` (`transferer_account_type`, `username`, `ammount`, `transaction_id`, `transfer_to`, `transfer_type`, `date`) VALUES
('Bank', 'Kabbo45', '100', 'TRASFATM6379421222', 'twyec23793hs', 'Bank', '07-23-2022');

-- --------------------------------------------------------

--
-- Table structure for table `wallet_history`
--

CREATE TABLE `wallet_history` (
  `username` varchar(40) NOT NULL,
  `account_type` varchar(5) NOT NULL,
  `wallet_name` varchar(40) NOT NULL,
  `wallet_address` varchar(50) NOT NULL,
  `wallet_pin` varchar(40) NOT NULL,
  `private_key` varchar(50) NOT NULL,
  `mnemonic` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `wallet_history`
--

INSERT INTO `wallet_history` (`username`, `account_type`, `wallet_name`, `wallet_address`, `wallet_pin`, `private_key`, `mnemonic`) VALUES
('Kabbo45', 'Bank', 'New', 'miYNKf3KGgo1Mtrggkw4MjdSjPQihF6zdr', '1234', 'tprv8fJGbS9Dn2AwX6pp76m4waZKJBNSsHMpx3eewU9KFkPhjV', 'steel insane error asthma rich burden bird insect girl tennis bone drum');

-- --------------------------------------------------------

--
-- Table structure for table `withdraw_history`
--

CREATE TABLE `withdraw_history` (
  `account_type` varchar(20) NOT NULL,
  `username` varchar(20) NOT NULL,
  `ammount` varchar(20) NOT NULL,
  `transaction_id` varchar(30) NOT NULL,
  `date` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
