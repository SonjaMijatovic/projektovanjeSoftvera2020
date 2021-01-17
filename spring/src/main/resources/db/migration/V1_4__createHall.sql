DROP TABLE IF EXISTS `hall`;

CREATE TABLE `hall` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `date_created` datetime NOT NULL,
  `date_deleted` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL,
  `deleted` bit(1) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `is_reserved` bit(1) DEFAULT 0,
  `clinic_id` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_hall_clinic` (`clinic_id`)
);

INSERT INTO `hall` (`id`, `name`, `is_reserved`, `deleted`, `date_created`, `date_deleted`, `date_updated`, `clinic_id`) VALUES
('1', 'Hall 1', 0, 0, '2011-11-11 00:00:00','2011-11-11 00:00:00', '2011-11-11 00:00:00', 1),
('2', 'Hall 2', 0, 0, '2011-11-11 00:00:00','2011-11-11 00:00:00', '2011-11-11 00:00:00', 1),
('3', 'Hall 3', 0, 0, '2011-11-11 00:00:00','2011-11-11 00:00:00', '2011-11-11 00:00:00', 1);