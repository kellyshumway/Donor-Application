create procedure SP_GetAllDonors
as
BEGIN
	select * from Donor order by FirstName;
END