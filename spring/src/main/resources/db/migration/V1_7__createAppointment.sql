DROP TABLE IF EXISTS `surgery`;

CREATE TABLE `surgery` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `date_created` datetime NOT NULL,
  `date_deleted` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL,
  `deleted` bit(1) NOT NULL,
  `date` datetime DEFAULT NULL,
    `description` varchar(255) NOT NULL,
    `patient_id` bigint(20) DEFAULT NULL,
    `hall_id` bigint(20) NOT NULL,
    `doctor_id` bigint(20) NOT NULL,
    `clinic_id` bigint(20) NOT NULL,
    PRIMARY KEY (`id`),
    KEY `FK_app_patient` (`patient_id`),
    KEY `FK_app_hall` (`hall_id`),
    KEY `FK_doctor_patient` (`doctor_id`),
    KEY `FK_clinic_patient` (`clinic_id`)
);

INSERT INTO `surgery` (`id`, `date`, `description`, `deleted`, `date_created`, `date_deleted`, `date_updated`, `clinic_id`, `patient_id`, `hall_id`, `doctor_id`) VALUES
('1', '2020-05-01 12:20:00', 'Description 1', 0, '2011-11-11 00:00:00','2011-11-11 00:00:00', '2011-11-11 00:00:00', 1, 2, 1, 3),
('2', '2020-05-01 13:40:00', 'Description 2', 0, '2011-11-11 00:00:00','2011-11-11 00:00:00', '2011-11-11 00:00:00', 1, 2, 2, 3),
('3', '2020-05-01 15:00:00',  'Description 2', 0, '2011-11-11 00:00:00','2011-11-11 00:00:00', '2011-11-11 00:00:00', 1, 1, 3, 4);

