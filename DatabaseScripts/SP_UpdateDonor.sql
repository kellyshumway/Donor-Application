create procedure SP_UpdateDonor
(
	@DonorID int = 0,
	@FirstName varchar(255)='',
	@LastName varchar(255)='',
	@Email varchar(255)='',
	@Donation money= 0.0
)
as
BEGIN
	update Donor set FirstName = @FirstName, 
	                 LastName = @LastName, 
					 Email = @Email, 
					 Donation = @Donation where DonorID = @DonorID
END