-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 23, 2019 at 04:52 PM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `blog_site`
--
CREATE DATABASE IF NOT EXISTS `blog_site` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `blog_site`;

-- --------------------------------------------------------

--
-- Table structure for table `blogs`
--

CREATE TABLE `blogs` (
  `id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `about` text NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `blogs`
--

INSERT INTO `blogs` (`id`, `title`, `about`, `username`, `password`) VALUES
(1, 'Hello', 'This is something', 'lana', '111'),
(3, 'My Awesome Blog', 'bla', 'blabla', '1111'),
(4, 'My Awesome Blog', 'lol', 'vitalii', '1'),
(5, 'Just Chilling', 'Sup. I’m Dwight. I skateboard, game, make youtube videos, and make youtube videos about skating and gaming. Yeah, that’s pretty much it. Oh, and my favorite color is green ;)\r\n', 'D-Wight', 'password'),
(6, 'My Crazy Life With Kitties', 'Welcome current and aspiring cat moms and dads! I made this blog to chronicle my adventures in kitty care,  and to share advice with other cat lovers in the community. Thanks for reading! \r\n', 'CatLuvr143', 'password'),
(7, 'Haters Gonna Hate', 'This is a place for me to vent because I can’t trust anyone not to snitch on me except my bff Jessica who knows about this blog lol\r\n', 'IH8Work', 'password');

-- --------------------------------------------------------

--
-- Table structure for table `blogs_communities`
--

CREATE TABLE `blogs_communities` (
  `id` int(11) NOT NULL,
  `blog_id` int(11) NOT NULL,
  `community_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `communities`
--

CREATE TABLE `communities` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `communities`
--

INSERT INTO `communities` (`id`, `name`, `description`) VALUES
(1, 'Cats', 'If you’re a friend to felines, you’re a friend of ours!'),
(2, 'Skateboarding', 'Come talk gear, techniques, competition and anything else skateboarding related'),
(3, 'Food & Cooking ', 'Do you like to cook? Do you like to eat? Check us out'),
(4, 'Books', 'Help us keep the lost art of reading alive. Enter a giveaway, start a book club, or search for recommendations!'),
(5, 'Technology', 'All’s fair in hardware and software');

-- --------------------------------------------------------

--
-- Table structure for table `posts`
--

CREATE TABLE `posts` (
  `id` int(11) NOT NULL,
  `blog_id` int(11) NOT NULL,
  `title` varchar(255) NOT NULL,
  `content` text NOT NULL,
  `date` datetime NOT NULL,
  `file` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `posts`
--

INSERT INTO `posts` (`id`, `blog_id`, `title`, `content`, `date`, `file`) VALUES
(9, 5, 'Hey dudes', 'Wassup internet, if you’re not here from my channel I’m D-WightSk8s on youtube. Check it out. I’ve been skating since I was a kid and have been told I could be the next Tony Hawk. People even say I kinda look like him haha.\r\n', '2019-05-23 09:19:38', NULL),
(10, 5, '150 subscriber special', 'Actually it’s 153 now, just sayin. If you take a pic of your board with D-WightSk8s written on the bottom I’ll enter you in a giveaway to get one of my old boards. I was gonna sell it but since you guys have supported me so much I wanted to do something just for y’all.\r\n', '2019-05-23 09:36:23', NULL),
(11, 5, 'Update on where I’ve been', 'Yeah so I busted my ankle up pretty bad. I was trying a pretty high jump and going for a record. Got pretty close but I wiped out.  Had to go to the E.R. and everything. It’s chill though because I’ve kinda been wanting to focus on my gaming career anyways but It sucks to not be able to skate.\r\n', '2019-05-23 09:36:45', NULL),
(12, 6, 'Hello Cat Community!', 'It’s so nice to meet like minded people, I’m really happy that I have found a place to talk about my kitties and hear about the adventures of other kitties! I have four cats: Tiger, Puma, Simba, and Mittens.\r\n', '2019-05-23 09:38:01', NULL),
(13, 7, 'Blah', 'I don’t want to get sued or anything so I won’t say where I work but it rhymes with BarSucks. Almost all my coworkers are lame and have never broken a rule in their life. I don’t see why I can’t just make myself a smoothie if there’s only a short line. How am I supposed to work without any energy?\r\n', '2019-05-23 09:39:38', NULL),
(14, 7, 'Everything Sucks', 'Turns out that two faced lying snake Jessica got me fired. On. Purpose. Our manager even let her get free lunch as a reward and she had the nerve to reserve one of the last of the good salads we had left. So I dumped it in the compost bin. I did what I had to do. Jessica, I hope you’re reading this. I hope you starved.  I hope you know karma is coming for you.\r\n', '2019-05-23 09:40:00', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `session_blogs`
--

CREATE TABLE `session_blogs` (
  `id` int(11) NOT NULL,
  `blog_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `blogs`
--
ALTER TABLE `blogs`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `blogs_communities`
--
ALTER TABLE `blogs_communities`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `communities`
--
ALTER TABLE `communities`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `posts`
--
ALTER TABLE `posts`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `session_blogs`
--
ALTER TABLE `session_blogs`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `blogs`
--
ALTER TABLE `blogs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `blogs_communities`
--
ALTER TABLE `blogs_communities`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `communities`
--
ALTER TABLE `communities`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `posts`
--
ALTER TABLE `posts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `session_blogs`
--
ALTER TABLE `session_blogs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
