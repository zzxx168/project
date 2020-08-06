-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- 主機： momodadb:3306
-- 產生時間： 2019 年 10 月 29 日 08:26
-- 伺服器版本： 10.1.41-MariaDB
-- PHP 版本： 5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 資料庫： `domain_check`
--

-- --------------------------------------------------------

--
-- 資料表結構 `domain`
--

CREATE TABLE `domain` (
  `id` int(11) NOT NULL,
  `domain` varchar(255) NOT NULL,
  `web` varchar(255) NOT NULL,
  `expiry_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 傾印資料表的資料 `domain`
--

INSERT INTO `domain` (`id`, `domain`, `web`, `expiry_date`) VALUES
(1, 'GoDaddy', 'cf.8iim.com', '2021-08-21'),
(2, 'GoDaddy', '8iim.com', '2021-08-21'),
(14, 'Namecheap', 'wankavn.com', '2020-03-07'),
(15, 'Namecheap', 'wanka16888.com', '2020-04-22'),
(16, 'Namecheap', 'ftr168.com', '2020-06-27'),
(17, 'Namecheap', 'gogamer168.com', '2019-12-07'),
(18, 'Namecheap', 'cngamer168.com', '2019-12-07'),
(19, 'Namecheap', '9i777.com', '2020-05-08'),
(20, 'Namecheap', '9iin.com', '2020-05-08'),
(21, 'Namecheap', 'haojutop1.com', '2020-03-29'),
(22, 'Namecheap', 'longrui-tw.com', '2020-06-15'),
(23, 'Namecheap', 'ezcard168.com', '2020-03-13'),
(24, 'Namecheap', 'dd-in.com', '2020-07-07'),
(25, 'Namecheap', 'gamer16888.com', '2020-06-13'),
(30, 'HiNet域名註冊', 'solgar.com.tw', '2021-08-12');

--
-- 已傾印資料表的索引
--

--
-- 資料表索引 `domain`
--
ALTER TABLE `domain`
  ADD PRIMARY KEY (`id`);

--
-- 在傾印的資料表使用自動遞增(AUTO_INCREMENT)
--

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `domain`
--
ALTER TABLE `domain`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
