DROP TABLE IF EXISTS `record`;

CREATE TABLE `record` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `date_created` datetime NOT NULL,
  `date_deleted` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL,
  `deleted` bit(1) NOT NULL,
  `description` varchar(255) NOT NULL,
  `patient_id` bigint(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_record_patient` (`patient_id`)
);

INSERT INTO `record` (`id`, `description`, `deleted`, `date_created`, `date_deleted`, `date_updated`, `patient_id`) VALUES
('1', 'Some description about patient 1', 0, '2011-11-11 00:00:00','2011-11-11 00:00:00', '2011-11-11 00:00:00', 1),
('2', 'Some description about patient 2', 0, '2011-11-11 00:00:00','2011-11-11 00:00:00', '2011-11-11 00:00:00', 1),
('3', 'Some description about patient 3', 0, '2011-11-11 00:00:00','2011-11-11 00:00:00', '2011-11-11 00:00:00', 1);