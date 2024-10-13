/*
SQLyog Community v13.3.0 (64 bit)
MySQL - 8.0.39 : Database - carrental
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`carrental` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `carrental`;

/*Table structure for table `tblanalytics` */

DROP TABLE IF EXISTS `tblanalytics`;

CREATE TABLE `tblanalytics` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `date` date DEFAULT NULL,
  `totalSales` decimal(10,2) DEFAULT NULL,
  `customerCount` int DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tblanalytics` */

/*Table structure for table `tblcar` */

DROP TABLE IF EXISTS `tblcar`;

CREATE TABLE `tblcar` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `brand` varchar(50) DEFAULT NULL,
  `model` varchar(50) DEFAULT NULL,
  `pricePerDay` decimal(10,2) DEFAULT NULL,
  `availability` bit(1) DEFAULT NULL,
  `imagePath` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tblcar` */

insert  into `tblcar`(`ID`,`brand`,`model`,`pricePerDay`,`availability`,`imagePath`) values 
(1,'Toyota','Corolla',800.00,'',''),
(2,'Honda2','Civic',55000.00,'\0',NULL),
(3,'Ford','Mustang',800.00,'','C:\\Users\\donla\\Pictures\\Downloads\\mustang.jpg'),
(5,'Chevrolet','Malibu',1200.00,'','C:\\Users\\donla\\Pictures\\Downloads\\malibu.jpg');

/*Table structure for table `tblcustomer` */

DROP TABLE IF EXISTS `tblcustomer`;

CREATE TABLE `tblcustomer` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `firstname` varchar(100) DEFAULT NULL,
  `lastname` varchar(100) DEFAULT NULL,
  `middlename` varchar(100) DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `contactinfo` varchar(100) DEFAULT NULL,
  `emailaddress` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tblcustomer` */

insert  into `tblcustomer`(`ID`,`firstname`,`lastname`,`middlename`,`gender`,`contactinfo`,`emailaddress`) values 
(9,'ads','asd','asd','Male','3243243244',''),
(10,'adasd','qweeqwe','asdaasd','Female','3123123213',''),
(11,'adsad','asdasd','asdasd','Male','2342342344',''),
(12,'Lance','Limbaro','Ondoy','Female','09700651307',''),
(13,'Jaco','Mulit','A','Male','1231231233',''),
(14,'Something','Somethingz','S','Female','1231231233',''),
(15,'ads','asd','asd','Male','3243243244','');

/*Table structure for table `tblinquiry` */

DROP TABLE IF EXISTS `tblinquiry`;

CREATE TABLE `tblinquiry` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `customerId` int NOT NULL,
  `carId` int NOT NULL,
  `status` varchar(20) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `customerId` (`customerId`),
  KEY `carId` (`carId`),
  CONSTRAINT `tblinquiry_ibfk_1` FOREIGN KEY (`customerId`) REFERENCES `tblcustomer` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `tblinquiry_ibfk_2` FOREIGN KEY (`carId`) REFERENCES `tblcar` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tblinquiry` */

insert  into `tblinquiry`(`ID`,`customerId`,`carId`,`status`,`date`) values 
(9,11,1,'Rented','2024-10-09 01:28:07'),
(10,12,2,'Inquired','2024-10-09 01:30:42'),
(11,13,5,'Rented','2024-10-10 10:24:16'),
(12,14,5,'Rented','2024-10-10 10:26:15'),
(13,15,1,'Inquired','2024-10-11 01:24:09');

/*Table structure for table `tblrental` */

DROP TABLE IF EXISTS `tblrental`;

CREATE TABLE `tblrental` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `carID` int DEFAULT NULL,
  `customerID` int DEFAULT NULL,
  `startDate` date DEFAULT NULL,
  `endDate` date DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL,
  `totalAmount` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `carID` (`carID`),
  KEY `customerID` (`customerID`),
  CONSTRAINT `tblrental_ibfk_1` FOREIGN KEY (`carID`) REFERENCES `tblcar` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `tblrental_ibfk_2` FOREIGN KEY (`customerID`) REFERENCES `tblcustomer` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tblrental` */

/*Table structure for table `tbluser` */

DROP TABLE IF EXISTS `tbluser`;

CREATE TABLE `tbluser` (
  `userID` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`userID`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tbluser` */

insert  into `tbluser`(`userID`,`username`,`password`,`role`) values 
(1,'lansilot','Lansilot@123','Admin');

/*Table structure for table `tbluserrental` */

DROP TABLE IF EXISTS `tbluserrental`;

CREATE TABLE `tbluserrental` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `userID` int NOT NULL,
  `rentalID` int NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `userID` (`userID`),
  KEY `rentalID` (`rentalID`),
  CONSTRAINT `tbluserrental_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `tbluser` (`userID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `tbluserrental_ibfk_2` FOREIGN KEY (`rentalID`) REFERENCES `tblrental` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `tbluserrental` */

/* Procedure structure for procedure `AddCar` */

/*!50003 DROP PROCEDURE IF EXISTS  `AddCar` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `AddCar`(
    in `p_brand` varchar(50),
    in `p_model` varchar(50),
    in `p_pricePerDay` decimal(10, 2),
    in `p_availability` boolean,
    in `p_imagePath` varchar(255)
)
begin 
    insert into tblcar (brand, model, pricePerDay, availability, imagePath) 
        values (p_brand, p_model, p_pricePerDay, p_availability, p_imagePath); 
end */$$
DELIMITER ;

/* Procedure structure for procedure `AddCustomer` */

/*!50003 DROP PROCEDURE IF EXISTS  `AddCustomer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `AddCustomer`(IN p_firstName varchar(100), IN p_lastName varchar(100),
                                                   IN p_middleName varchar(100), IN p_gender varchar(10),
                                                   IN p_contactInfo varchar(100), IN p_emailAddress varchar(100))
begin
    insert into tblcustomer (firstname, lastname, middlename, gender, contactinfo, emailaddress)
    values (p_firstName, p_lastName, p_middleName, p_gender, p_contactInfo, p_emailAddress);

    SELECT LAST_INSERT_ID() AS CustomerId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `AddInquiry` */

/*!50003 DROP PROCEDURE IF EXISTS  `AddInquiry` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `AddInquiry`(IN p_customerId int, IN p_carId int, IN p_status varchar(20),
                                                  IN p_date datetime)
begin
    insert into tblinquiry(customerID, carID, status, date)
    values (p_customerId, p_carId, p_status, p_date);
    select last_insert_id() as InquiryId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `AddRental` */

/*!50003 DROP PROCEDURE IF EXISTS  `AddRental` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `AddRental`(
    in `p_carId` int,
    in `p_customerId` int,
    in `p_startDate` date,
    in `p_endDate` date,
    in `p_status` varchar(20),
    in `p_totalAmount` decimal(10, 2)
)
begin 
    insert into tblrental (
                           carID, 
                           customerID, 
                           startDate, 
                           endDate, 
                           status, 
                           totalAmount
    )
        values (
                p_carId,
                p_customerId,
                p_startDate,
                p_endDate,
                p_status,
                p_totalAmount
                );
end */$$
DELIMITER ;

/* Procedure structure for procedure `AddUser` */

/*!50003 DROP PROCEDURE IF EXISTS  `AddUser` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `AddUser`(
    IN `p_username` VARCHAR(50),
    IN `p_password` VARCHAR(255),
    IN `p_role` VARCHAR(20)
)
BEGIN
    INSERT INTO tbluser (username, password, role)
    VALUES (p_username, p_password, p_role);
END */$$
DELIMITER ;

/* Procedure structure for procedure `AddUserRental` */

/*!50003 DROP PROCEDURE IF EXISTS  `AddUserRental` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `AddUserRental`(
    IN `p_userID` INT,
    IN `p_rentalID` INT
)
BEGIN
    INSERT INTO tbluserrental (userID, rentalID)
    VALUES (p_userID, p_rentalID);
END */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteCar` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteCar` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteCar`(in `p_carId` int)
begin 
    delete from tblcar where ID = p_carId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteCustomer` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteCustomer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteCustomer`(in `p_customerId` int)
begin 
    delete from tblcustomer where id = p_customerId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteInquiry` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteInquiry` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteInquiry`(in `p_inquiryId` int)
begin 
    delete from tblinquiry where ID = p_inquiryId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteRental` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteRental` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteRental`(in `p_rentalId` int)
begin 
    delete from tblrental where ID = p_rentalId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteRentedInquiry` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteRentedInquiry` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteRentedInquiry`()
begin 
    -- Delete all inquiries where the status is `Rented`
    delete from tblinquiry where status = 'Rented';
end */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteUser` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteUser` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteUser`(IN p_userId INT)
BEGIN
    DELETE FROM tbluser WHERE userID = p_userId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `DeleteUserRental` */

/*!50003 DROP PROCEDURE IF EXISTS  `DeleteUserRental` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteUserRental`(IN `p_UserRentalId` INT)
BEGIN
    DELETE FROM tbluserrental WHERE ID = p_UserRentalId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `GetAllCars` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetAllCars` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllCars`()
begin 
    select * from tblcar;
end */$$
DELIMITER ;

/* Procedure structure for procedure `GetAllCustomers` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetAllCustomers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllCustomers`()
begin 
    select * from tblcustomer;
end */$$
DELIMITER ;

/* Procedure structure for procedure `GetAllCustomersWithInquiryAndRental` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetAllCustomersWithInquiryAndRental` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllCustomersWithInquiryAndRental`()
begin 
    select
        c.ID as customerId,
        c.firstname as customerFirstName,
        c.lastname as customerLastName,
        c.contactinfo as contactInfo,
        c.emailaddress as emailAddress,
        i.ID as inquiryId,
        i.carId as inquiryCarId,
        i.status as inquiryStatus,
        r.ID as rentalId,
        r.carId as rentalCarId,
        r.startDate as rentalStartDate,
        r.endDate as rentalEndDate,
        r.status as rentalStatus,
        r.totalAmount as rentalTotalAmount
        from tblcustomer c
    left join tblinquiry i on c.ID = i.customerId
    left join tblrental r on c.ID = r.customerID;
end */$$
DELIMITER ;

/* Procedure structure for procedure `GetAllInquiries` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetAllInquiries` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllInquiries`()
begin 
    select * from tblinquiry;
end */$$
DELIMITER ;

/* Procedure structure for procedure `GetAllRentals` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetAllRentals` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllRentals`()
begin 
    select * from tblrental;
end */$$
DELIMITER ;

/* Procedure structure for procedure `GetAllUserRentals` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetAllUserRentals` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllUserRentals`()
BEGIN
    SELECT * FROM tbluserrental;
END */$$
DELIMITER ;

/* Procedure structure for procedure `GetAllUsers` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetAllUsers` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAllUsers`()
BEGIN
    SELECT * FROM tbluser;
END */$$
DELIMITER ;

/* Procedure structure for procedure `GetAvailableCars` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetAvailableCars` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAvailableCars`()
begin
    select *
    from tblcar
    where availability = 1;
end */$$
DELIMITER ;

/* Procedure structure for procedure `GetCarById` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetCarById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetCarById`(in `p_carId` int)
begin 
    select * from tblcar where ID = p_carId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `GetCustomerById` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetCustomerById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetCustomerById`(in `p_customerId` int)
begin 
    select * from tblcustomer where ID = p_customerId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `GetDailySalesAndCustomerAnalytics` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetDailySalesAndCustomerAnalytics` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetDailySalesAndCustomerAnalytics`()
begin 
    select 
        sum(tblrental.totalAmount) as totalSales,
        count(distinct tblrental.customerID) as customerCount
        from tblrental
            where date(startDate) = CURDATE();
end */$$
DELIMITER ;

/* Procedure structure for procedure `GetInquiryById` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetInquiryById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetInquiryById`(in `p_inquiryId` int)
begin 
    select * from tblinquiry where ID = p_inquiryId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `GetMonthlySalesAndCustomerAnalytics` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetMonthlySalesAndCustomerAnalytics` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetMonthlySalesAndCustomerAnalytics`()
begin 
    select 
        sum(tblrental.totalAmount) as totalSales,
        count(distinct tblrental.customerID) as customerCount
        from tblrental
            where MONTH(startDate) = MONTH(curdate()) and YEAR(startDate) = YEAR(curdate());
end */$$
DELIMITER ;

/* Procedure structure for procedure `GetRentalById` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetRentalById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetRentalById`(in `p_rentalId` int)
begin 
    select * from tblrental where ID = p_rentalId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `GetUserById` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetUserById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetUserById`(IN `p_userId` INT)
BEGIN
    SELECT * FROM tbluser WHERE userID = p_userId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `GetUserByUsername` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetUserByUsername` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetUserByUsername`(
    in `p_username` varchar(50)
)
begin 
    select * from tbluser where username = p_username;
end */$$
DELIMITER ;

/* Procedure structure for procedure `GetUserRentalById` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetUserRentalById` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetUserRentalById`(IN `p_UserRentalId` INT)
BEGIN
    SELECT * FROM tbluserrental WHERE ID = p_UserRentalId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `GetWeeklySalesAndCustomerAnalytics` */

/*!50003 DROP PROCEDURE IF EXISTS  `GetWeeklySalesAndCustomerAnalytics` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `GetWeeklySalesAndCustomerAnalytics`()
begin 
    select 
        sum(tblrental.totalAmount) as totalSales,
        count(distinct tblrental.customerID) as customerCount
        from tblrental
            where YEARWEEK(startDate, 1) = YEARWEEK(CURDATE(), 1);
end */$$
DELIMITER ;

/* Procedure structure for procedure `ResetAutoIncrement` */

/*!50003 DROP PROCEDURE IF EXISTS  `ResetAutoIncrement` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `ResetAutoIncrement`()
begin
    -- Disable foreign key checks
    SET FOREIGN_KEY_CHECKS = 0;

    -- Truncate all the relevant tables
    TRUNCATE TABLE tblcustomer;
    TRUNCATE TABLE tblcar;
    TRUNCATE TABLE tblinquiry;
    TRUNCATE TABLE tblrental;
    TRUNCATE TABLE tbluser;
    TRUNCATE TABLE tbluserrental;
    
    -- Reset AUTO_INCREMENT for tblcustomer
    alter table tblcustomer auto_increment = 1;

    -- Reset AUTO_INCREMENT for tblcar
    alter table tblcar auto_increment = 1;

    -- Reset AUTO_INCREMENT for tblinquiry 
    alter table tblinquiry auto_increment = 1;

    -- Reset AUTO_INCREMENT for tblrental  
    alter table tblrental auto_increment = 1;

    -- Reset AUTO_INCREMENT for tbluser
    alter table tbluser auto_increment = 1;

    -- Reset AUTO_INCREMENT for tbluserrental
    alter table tbluserrental auto_increment = 1;
    
    -- Enable foreign key checks
    set foreign_key_checks = 1;
end */$$
DELIMITER ;

/* Procedure structure for procedure `SearchCustomerWithFilter` */

/*!50003 DROP PROCEDURE IF EXISTS  `SearchCustomerWithFilter` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `SearchCustomerWithFilter`(
    in `p_column` varchar(50),
    in `p_searchTerm` varchar(100)
)
begin
    set @query = concat(
            'SELECT c.ID AS customerId, c.firstname AS customerFirstName, c.lastname AS customerLastName, c.contactinfo AS contactInfo, c.emailaddress AS emailAddress, i.ID AS inquiryId, i.carID AS inquiryCarId, i.status AS inquiryStatus, r.ID AS rentalId, r.carID AS rentalCarId, r.startDate AS rentalStartDate, r.endDate AS rentalEndDate, r.totalAmount AS rentalTotalAmount FROM tblcustomer c LEFT JOIN tblinquiry i ON c.ID = i.customerID LEFT JOIN tblrental r ON c.ID = r.customerID WHERE ',
            p_column, ' LIKE ?searchTerm');
    
    prepare stmt from @query;
    set @searchTerm = concat('%', p_searchTerm, '%');
    execute stmt using @searchTerm;
    deallocate prepare stmt;
end */$$
DELIMITER ;

/* Procedure structure for procedure `UdpateRental` */

/*!50003 DROP PROCEDURE IF EXISTS  `UdpateRental` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `UdpateRental`(
    in `p_rentalId` int,
    in `p_carId` int,
    in `p_customerId` int,
    in `p_startDate` date,
    in `p_endDate` date,
    in `p_status` varchar(20),
    in `p_totalAmount` decimal(10, 2)
)
begin 
    update tblrental
        set carID = p_carId,
            customerID = p_customerId,
            startDate = p_startDate,
            endDate = p_endDate,
            `status` = p_status,
            totalAmount = p_totalAmount
    where ID = p_rentalId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateCar` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateCar` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateCar`(IN p_carId int, IN p_brand varchar(50), IN p_model varchar(50),
                                                 IN p_pricePerDay decimal(10, 2), IN p_availability bit(1),
                                                 IN p_imagePath varchar(255))
begin
    update tblcar
    set brand = p_brand, model = p_model, pricePerDay = p_pricePerDay, availability = p_availability, imagePath = p_imagePath
    where ID = p_carId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateCarAvailability` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateCarAvailability` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateCarAvailability`(
    in `p_carId` int
)
begin
    update tblcar
    set availability = 0
    where ID = p_carId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateCustomer` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateCustomer` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateCustomer`(
    in `p_customerId` int,
    in `p_firstName` varchar(100),
    in `p_lastName` varchar(100),
    in `p_middleName` varchar(100),
    in `p_gender` varchar(10),
    in `p_contactInfo` varchar(100),
    in `p_emailAddress` varchar(100)
)
begin 
    update tblcustomer
        set firstname = p_firstName,
            lastname = p_lastName,
            middlename = p_middleName,
            gender = p_gender,
            contactinfo = p_contactInfo,
            emailaddress = p_emailAddress
    where ID = p_customerId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateInquiry` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateInquiry` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateInquiry`(
    in `p_inquiryId` int,
    in `p_customerId` int,
    in `p_carId` int,
    in `p_status` varchar(20)
)
begin 
    update tblinquiry
        set customerID = p_customerId,
            carID = p_carId,
            status = p_status
    where ID = p_inquiryId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateInquiryStatus` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateInquiryStatus` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateInquiryStatus`(
    in p_inquiryId int,
    in p_newStatus varchar(20)
)
begin 
    update tblinquiry set status = p_newStatus where ID = p_inquiryId;
end */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateUser` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateUser` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateUser`(
    IN p_userId INT,
    IN `p_username` VARCHAR(50),
    IN `p_password` VARCHAR(255),
    IN `p_role` VARCHAR(20)
)
BEGIN
    UPDATE tbluser
    SET username = p_username, password = p_password, role = p_role
    WHERE userID = p_userId;
END */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateUserPassword` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateUserPassword` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateUserPassword`(
    in `p_userID` int,
    in `p_password` varchar(255)
)
begin
    update tbluser set password = p_password where userID = p_userID;
end */$$
DELIMITER ;

/* Procedure structure for procedure `UpdateUserRental` */

/*!50003 DROP PROCEDURE IF EXISTS  `UpdateUserRental` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateUserRental`(
    IN `p_UserRentalId` INT,
    IN `p_userID` INT,
    IN `p_rentalID` INT
)
BEGIN
    UPDATE tbluserrental
    SET userID = p_userID, rentalID = p_rentalID
    WHERE ID = p_UserRentalId;
END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
