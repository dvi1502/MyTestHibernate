/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
truncate table Book;
insert into Book 
values
('A','1'),
('B','2'),
('C','3'),
('D','4');


truncate table Cat;
insert into Cat (name,sex,weight)
values
(N'Вася',N'M',5.25),
(N'Барсик',N'M',3.70),
(N'Сема',N'M',8.25),
(N'Мурка',N'Ж',3.125);