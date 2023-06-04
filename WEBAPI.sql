Create table tbl_Employee(
ID int identity primary Key,
Email nvarchar(200),
Emp_Name nvarchar(200),
Designation nvarchar(200),
Created_date date default getdate()
)

--select * from tbl_Employee

Create PROC Sp_Employee
@ID int,
@Email nvarchar(200),
@Emp_Name nvarchar(200),
@Designation nvarchar(200),
@type nvarchar(50)
AS
BEGIN
IF(@type='insert')
BEGIN
INSERT INTO tbl_Employee
(
	Email,
	Emp_Name,
	Designation
)
VALUES
(
	@Email,
	@Emp_Name,
	@Designation
)
END
ELSE IF(@type='get')
BEGIN
SELECT * FROM tbl_Employee ORDER BY ID desc
END
ELSE IF (@type='getid')
BEGIN
SELECT * FROM tbl_Employee WHERE ID=@ID
END
ELSE IF(@type='update')
BEGIN
UPDATE tbl_Employee SET
	Email=@Email,
	Emp_Name=@Emp_Name,
	Designation=@Designation
WHERE ID=@ID
END
ELSE IF(@type='delete')
BEGIN
	DELETE FROM tbl_Employee WHERE ID=@ID
END
END