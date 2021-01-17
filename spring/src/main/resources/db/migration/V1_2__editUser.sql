ALTER TABLE `user`
ADD COLUMN `registration_confirmed` varchar(255) NOT NULL,
ADD COLUMN `registration_token` varchar(255),
ADD COLUMN `address` varchar(255) NOT NULL,
ADD COLUMN `city` varchar(255) NOT NULL,
ADD COLUMN `country` varchar(255) NOT NULL,
ADD COLUMN `phone_number` varchar(255) NOT NULL,
ADD COLUMN `jbo` varchar(255) NOT NULL,
ADD COLUMN `deleted` bit(1) NOT NULL;

INSERT INTO `user` (`id`, `email`, `password`, `name`, `surname`, `registration_confirmed`, `role`, `deleted`, `date_created`, `date_deleted`, `date_updated`,
 `address`, `city`, `country`, `phone_number`, `jbo`, `clinic_id`) VALUES

('1', 'test1@gmail.com', '$2a$10$gDqfRHdeFeiopzJ3MSNiLOdYsTDU/RJWhTr5OJvGHE3355C5OLDDm', 'Pera', 'Peric', 1, 'PATIENT', 0, '2011-11-11 00:00:00','2011-11-11 00:00:00',
'2011-11-11 00:00:00', 'Address 1', 'City 1', 'Country 1', '+3813333333333', '123456789', NULL),

('2', 'test2@gmail.com', '$2a$10$gDqfRHdeFeiopzJ3MSNiLOdYsTDU/RJWhTr5OJvGHE3355C5OLDDm', 'Mika ', 'Mikic', 1, 'PATIENT', 0, '2011-11-11 00:00:00','2011-11-11 00:00:00',
'2011-11-11 00:00:00', 'Address 2', 'City 2', 'Country 2', '+3813333333333', '123456789', NULL),

('3', 'test3@gmail.com', '$2a$10$gDqfRHdeFeiopzJ3MSNiLOdYsTDU/RJWhTr5OJvGHE3355C5OLDDm', 'Doktor', 'Peric', 1, 'DOCTOR', 0, '2011-11-11 00:00:00','2011-11-11 00:00:00',
'2011-11-11 00:00:00', 'Address 3', 'City 2', 'Country 1', '+3813333333333', '123456789', '1'),

('4', 'test4@gmail.com', '$2a$10$gDqfRHdeFeiopzJ3MSNiLOdYsTDU/RJWhTr5OJvGHE3355C5OLDDm', 'Doktor', 'Mikic', 1, 'DOCTOR', 0, '2011-11-11 00:00:00','2011-11-11 00:00:00',
'2011-11-11 00:00:00', 'Address 5', 'City 2', 'Country 1', '+3813333333333', '123456789', '1');

