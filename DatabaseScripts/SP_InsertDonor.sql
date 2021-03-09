create procedure SP_InsertDonor
(
@FirstName varchar(255)='',
@LastName varchar(255)='',
@Email varchar(255)='',
@Donation money= 0.0
)
as
BEGIN
	insert into Donor(FirstName, LastName, Email, Donation)
	values (@FirstName, @LastName, @Email, @Donation)
END