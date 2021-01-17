DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `date_created` datetime NOT NULL,
  `date_deleted` datetime DEFAULT NULL,
  `date_updated` datetime DEFAULT NULL,
  `device_token` varchar(255) DEFAULT NULL,
  `email` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `reset_token` varchar(255) DEFAULT NULL,
  `reset_token_expiration_date` datetime DEFAULT NULL,
  `role` varchar(255) DEFAULT NULL,
  `surname` varchar(255) NOT NULL,
  `clinic_id` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_doctor_clinic` (`clinic_id`)
)