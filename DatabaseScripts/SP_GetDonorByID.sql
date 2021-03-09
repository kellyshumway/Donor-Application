create procedure SP_GetDonorByID
(
	@DonorID int
)
as
BEGIN
	select * from Donor where DonorID = @DonorID
END