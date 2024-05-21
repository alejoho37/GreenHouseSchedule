go
use "SowScheduleDB";

go
insert into "Provinces" values
	('Pinar del Río'),
	('Artemisa'),
	('La Habana'),	
	('Mayabeque'),
	('Matanzas'),
	('Cienfuegos'),
	('Villa Clara'),
	('Sancti Spíritus'),
	('Ciego de Ávila'),
	('Camagüey'),
	('Las Tunas'),
	('Granma'),
	('Holguín'),
	('Santiago'),
	('Guantánamo'),
	('Isla de la Juventud'),
	('N.I.');

go
insert into "TypesOfOrganization" values
	('CCS'),
	('CPA'),
	('ECV'),
	('GU'),
	('UBPC'),
	('UM'),
	('N.I.');

go
insert into "Municipalities" values
	('Quivicán', 4),
	('Batabanó', 4),
	('San José de las Lajas', 4),
	('Melena del Sur', 4),
	('San Antonio de las Vegas', 4),
	('Mantanzas', 5),
	('Guira de Melena', 3),
	('Bejucal', 4),
	('San Antonio de los Baños', 3),
	('Buena Ventura', 4),
	('Bauta', 3),
	('Guines', 4),
	('Calvario', 2),
	('N.I.', 17);

go
insert into "Organizations" values
	('Mártires de Barbados', 1, 1),
	('Jose Luis Tacende', 14, 1),
	('Jose Antonio Echevería', 14, 1);

go
insert into "Clients" values
	('Alberto Martínez', null, '52368566', null, 1),
	('Yesdel Acosta Pérez', null, '55423113', null, 2),
	('Manuel Rodríguez', null, null, 47425145, 1),
	('Alberto Espinosa', null, '52556650', null, 3),
	('Jose Carlos', null, '53742114', null, 1);

--------------------------------------------------------------------------------------------

go 
insert into "Species" values
	('Tomate', 30, 750, 35000, 25.25),
	('Col', 30, 840, 30000, 25.20),
	('Pimiento', 45, 810, 33000, 26.73);

go
insert into "Products" values
	(1,'Vyta Mariela'),
	(1,'HA-3019'),
	(1,'N.I.'),
	(2,'KK-Cross'),
	(2,'Globe Master'),
	(2,'King of King Cross'),
	(2, 'N.I. '),
	(3,'California'),
	(3,'N.I.');

----------------------------------------------------------------------------------

go
insert into "GreenHouses" values
	('    -', 'This is a ghost house to put 
	the dont sown order locations', 1, 1, 1, 1, 1, 0),
	('Casa 1', null, 11.58, 35, 405.3, 306.81, 4, 1),
	('Casa 2', null, 11.58, 34.6, 400.67, 306.72, 4, 1),
	('Casa 3', null, 11.32, 35, 396.2, 256.81, 4, 1),
	('Casa 4', null, 11.58, 35.2, 407.62, 308.77, 4, 1),
	('Casa 5', null, 11.58, 35, 405.3, 305.98, 4, 1),
	('Casa 6', null, 7, 30, 210, 170, 2, 1),
	('Casa 7', null, 7.3, 35, 255.5, 181.61, 2, 1),
	('Casa 8', null, 7.78, 35, 272.3, 181.61, 2, 1);

go
insert into "SeedTrays" values
	('264', 264, 22, 12, 0.62, 0.35, 0.217, 0.217, 2574, 'poliespuma', 3,1,0),
	('260', 260, 20, 13, 0.72, 0.47, 0.3384, 0.3384, 2583, 'poliespuma', 2,1,0),
	('160 negra', 160, 16, 10, 0.52, 0.33, 0.1716, 0.1716, 4722, 'polietileno', 1,1,0),
	('150', 150, 15, 10, 0.56, 0.37, 0.2072, 0.2072, 900, 'polietileno', 4,1,0),
	('160 blanca', 160, 16, 10, 0.52, 0.33, 0.1716, 0.1716, 100, 'poliespuma', 5,1,0),
	('280', 280, 20, 14, 0.52, 0.33, 0.1716, 0.1716, 500, 'poliespuma', 6,1,0);

--------------------------------------------------------------------------------------

go
insert into "Orders" values
	(1, 1, 40000, 48000, '5-8-2023', '2-15-2023', '4-10-2023', '5-8-2023', '4-10-2023', '5-8-2023', 1),
	(5, 2, 30000, 36000, '4-20-2023', '1-10-2023', '3-18-2023', '4-20-2023', '3-18-2023', '4-20-2023', 1),
	(3, 5, 60000, 72000, '6-3-2023', '4-21-2023', '5-4-2023', '6-3-2023', '5-4-2023', '6-3-2023', 1),
	(2, 8, 45000, 54000, '5-24-2023', '3-15-2023', '4-9-2023', '5-24-2023', '4-9-2023', '5-24-2023', 1),
	(4, 3, 18000, 21600, '4-30-2023', '1-11-2023', '3-28-2023', '4-30-2023', '3-28-2023', '4-30-2023', 1),
	(1, 6, 37000, 44400, '7-8-2023', '5-17-2023', '6-8-2023', '7-8-2023', '6-8-2023', null, 1),
	(3, 7, 29000, 34800, '7-18-2023', '3-21-2023', '6-3-2023', '7-20-2023', '6-5-2023', null, 1),
	(5, 8, 33000, 39600, '8-11-2023', '4-27-2023', '6-27-2023', '8-11-2023', null, null, 0),
	(3, 4, 21000, 25200, '8-8-2023', '5-29-2023', '7-9-2023', '8-8-2023', null, null, 0);

go
insert into "OrderLocations" values
	(1, 1, 1, 182, 48048, '4-10-2023', '5-8-2023', '4-10-2023', '5-8-2023'),
	(2, 1, 2, 76, 20064, '3-18-2023', '4-20-2023', '3-18-2023', '4-19-2023'),
	(3, 3, 2, 100, 16000, '3-19-2023', '4-21-2023', '3-19-2023', '4-19-2023'),
	(1, 2, 3, 180, 46800, '5-4-2023', '6-3-2023', '5-4-2023', '6-3-2023'),
	(3, 2, 3, 80, 20800, '5-5-2023', '6-4-2023', '5-5-2023', '6-4-2023'),
	(2, 3, 4, 130, 20800, '4-9-2023', '5-24-2023', '4-9-2023', '5-24-2023'),
	(1, 3, 4, 208, 33280, '4-9-2023', '5-24-2023', '4-9-2023', '5-24-2023'),
	(3, 1, 5, 82, 21648, '3-28-2023', '4-30-2023', '3-28-2023', '4-27-2023'),
	(1, 1, 6, 80, 21120, '6-8-2023', '7-8-2023', '6-8-2023', null),
	(4, 2, 6, 35, 9100, '6-8-2023', '7-8-2023', '6-8-2023', null),
	(4, 6, 6, 51, 14280, '6-10-2023', '7-10-2023', '6-10-2023', null),
	(4, 2, 7, 134, 34840, '6-5-2023', '7-20-2023', '6-5-2023', null),
	(3, 2, 8, 153, 39780, '6-27-2023', '8-11-2023', '6-27-2023', null),
	(2, 2, 9, 25, 6500, null, null, null, null),
	(2, 3, 9, 54, 8640, null, null, null, null),
	(4, 3, 9, 63, 10080, null, null, null, null);

go
insert into "Blocks" values
	(1, 1, 82, 1),
	(1, 1, 40, 2),
	(1, 2, 60, 3),
	(2, 3, 76, 4),
	(3, 4, 25, 5),
	(3, 4, 75, 6),
	(4, 1, 90, 7),
	(4, 4, 90, 8),
	(5, 2, 80, 9),
	(6, 4, 130, 10),
	(7, 4, 100, 11),
	(7, 4, 108, 12),
	(8, 3, 82, 13),
	(9, 2, 80, 14),
	(10, 1, 35, 15),
	(11, 1, 51, 16),
	(12, 4, 134, 17),
	(13, 1, 50, 18),
	(13, 2, 53, 19),
	(13, 1, 24, 20),
	(13, 3, 26, 21);




go
insert into "DeliveryDetails" values
(1, '5-8-2023', 42),
(1, '5-8-2023', 40),
(2, '5-8-2023', 40),
(3, '5-8-2023', 60),
(4, '4-19-2023', 76),
(5, '4-19-2023', 25),
(6, '4-19-2023',75),
(7, '6-3-2023', 90),
(8, '6-5-2023', 90),
(9, '6-4-2023',60),
(9, '6-5-2023',20),
(10, '5-24-2023', 130),
(11, '5-24-2023', 80),
(11, '5-29-2023', 20),
(12, '5-29-2023', 108),
(13, '4-27-2023', 82);






--(1, '5-8-2023', 102),
--(1, '5-10-2023', 80),
--(2, '4-19-2023', 76),
--(3,'4-19-2023',60),
--(3,'4-20-2023',40),
--(4,'6-3-2023',180),
--(5,'6-4-2023',80),
--(6,'5-24-2023',115),
--(7,'5-24-2023',126),
--(7,'5-29-2023',65);











