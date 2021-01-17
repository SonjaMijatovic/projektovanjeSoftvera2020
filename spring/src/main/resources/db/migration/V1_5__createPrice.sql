DROP TABLE IF EXISTS `price`;

CREATE TABLE `price` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `date_created` datetime NOT NULL,
  `date_deleted` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL,
  `deleted` bit(1) NOT NULL,
  `description` varchar(255) NOT NULL,
  `price` double NOT NULL,
  `clinic_id` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_price_clinic` (`clinic_id`)
);

INSERT INTO `price` (`id`, `description`, `price`, `deleted`, `date_created`, `date_deleted`, `date_updated`, `clinic_id`) VALUES
('1', 'Service 1', 150, 0, '2011-11-11 00:00:00','2011-11-11 00:00:00', '2011-11-11 00:00:00', 1),
('2', 'Service 2', 157, 0, '2011-11-11 00:00:00','2011-11-11 00:00:00', '2011-11-11 00:00:00', 1),
('3', 'Service 3', 200, 0, '2011-11-11 00:00:00','2011-11-11 00:00:00', '2011-11-11 00:00:00', 1);