drop procedure SP_InsertDonors;
drop procedure SP_UpdateDonor;
drop procedure SP_GetDonorByID;
drop procedure SP_GetAllDonors;

drop table Donor;

create table Donor
(
	DonorID int identity, 
	FirstName varchar(255),
	LastName varchar(255),
	Email varchar(255),
	Donation money
);

insert into Donor
values
	('Carol', 'Danvers', 'captainmarvel@marvel.com', 420),
	('Anthony', 'Stark', 'ironman@marvel.com', 1000000),
	('Clinton', 'Barton', 'hawkey@marvel.com', 700),
	('Steven', 'Rogers', 'captainamerica@marvel.com', 300),
	('Natalia', 'Romanova', 'blackwidow@marvel.com', 900),
	('Scott', 'Lang', 'antman@marvel.com', 5),
	('Pietro', 'Maximof', 'quicksilver@marvel.com', 50),
	('Sammuel', 'Wilson', 'falcon@marvel.com', 150)
;


select * from Donor order by FirstName;