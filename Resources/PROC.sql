USE [ERP-Recruiting]
GO

CREATE PROC SP_JOBDESCRIPTION_GET_PAGING
AS 
	BEGIN
		SELECT JOB.Title,
			JOB.JobId,
			JOB.Description,
			JOB.Endow,
			JOB.Benefit,
			JOB.SkillId,
			JOB.OfferFrom,
			JOB.OfferTo,
			JOB.RequestJob,
			JOB.Status,
			CAT.Name,
			JOB.TimeStart,
			JOB.TimeEnd,
			JOB.CategoryId,
			JOB.Quatity,
			JOB.Type,
			JOB.CreateDate
		FROM DBO.JobDescriptions AS JOB,
			DBO.JobCategories AS CAT
			WHERE 
				JOB.CategoryId = CAT.CategoryId AND
				JOB.Deleted = 0
			ORDER BY JOB.JobId
	END;
GO

CREATE PROC SP_SKILL_GET_ALL
AS
	BEGIN
		SELECT SKILL.SkillId, SKILL.Name FROM DBO.Skills AS SKILL WHERE SKILL.Deleted = 0
	END
GO

CREATE PROC SP_CATEGORY_GET_ALL
AS
	BEGIN
		SELECT JC.CategoryId,JC.Name,COUNT(JOB.JobId) AS Total
		FROM DBO.JobCategories AS JC,DBO.JobDescriptions AS JOB 
		WHERE JC.Deleted = 0 AND JC.CategoryId = JOB.CategoryId
		GROUP BY JC.CategoryId,JC.Name
	END
GO

CREATE PROC SP_JOBDESCRIPTION_GET_ALL
AS 
	BEGIN
		SELECT JOB.Title,
			JOB.JobId,
			JOB.Description,
			JOB.Endow,
			JOB.Benefit,
			JOB.SkillId,
			JOB.OfferFrom,
			JOB.OfferTo,
			JOB.RequestJob,
			JOB.Status,
			CAT.Name,
			JOB.TimeStart,
			JOB.TimeEnd,
			JOB.Quatity,
			JOB.CategoryId,
			JOB.Type,
			JOB.CreateDate
		FROM DBO.JobDescriptions AS JOB,
			DBO.JobCategories AS CAT
			WHERE 
				JOB.CategoryId = CAT.CategoryId AND
				JOB.Deleted = 0
	END;
GO

CREATE PROC SP_JOBDESCRIPTION_GET_SIMILAR
@CATEGORIID INT
AS 
	BEGIN
		SELECT JOB.Title,
			JOB.JobId,
			JOB.Quatity,
			JOB.Type
		FROM DBO.JobDescriptions AS JOB,
			DBO.JobCategories AS CAT
			WHERE 
				JOB.CategoryId = CAT.CategoryId AND
				JOB.Deleted = 0 AND
				CAT.CategoryId = @CATEGORIID
	END;
GO


CREATE PROC SP_JOBDESCRIPTION_GET_ALL_NEW
AS 
	BEGIN
		SELECT TOP(8) JOB.Title,
			JOB.JobId,
			JOB.Description,
			JOB.Endow,
			JOB.Benefit,
			JOB.SkillId,
			JOB.OfferFrom,
			JOB.OfferTo,
			JOB.RequestJob,
			JOB.Status,
			CAT.Name,
			JOB.TimeStart,
			JOB.TimeEnd,
			JOB.CategoryId,
			JOB.Quatity,
			JOB.Type,
			JOB.CreateDate
		FROM DBO.JobDescriptions AS JOB,
			DBO.JobCategories AS CAT
			WHERE 
				JOB.CategoryId = CAT.CategoryId AND
				JOB.Deleted = 0
			ORDER BY JOB.CreateDate DESC
	END;
GO

CREATE PROC SP_JOBDESCRIPTION_GET_DETAIL
@ID INT
AS 
	BEGIN
		SELECT JOB.Title,
			JOB.JobId,
			JOB.Description,
			JOB.Endow,
			JOB.Benefit,
			JOB.SkillId,
			JOB.OfferFrom,
			JOB.OfferTo,
			JOB.RequestJob,
			JOB.Status,
			CAT.Name,
			JOB.TimeStart,
			JOB.Quatity,
			JOB.TimeEnd,
			JOB.CategoryId,
			JOB.Type,
			JOB.CreateDate
		FROM DBO.JobDescriptions AS JOB,
			DBO.JobCategories AS CAT
			WHERE 
				JOB.CategoryId = CAT.CategoryId AND
				JOB.Deleted = 0
				AND JOB.JobId = @ID
			ORDER BY JOB.CreateDate DESC
	END;
GO

CREATE PROC SP_CADIDATE_CREATE
(
@NAME NVARCHAR(100),
@EMAIL VARCHAR(200),
@ADDRESS NVARCHAR(250),
@PHONE NVARCHAR(20),
@DOB DATETIME,
@GENDER INT,
@DEGREE NVARCHAR(20),
@APPLYDATE DATETIME= GETDATE,
@JOBID INT
)
AS
	BEGIN
		INSERT DBO.Cadidates(Name,Email,Address,Phone,Dob,Gender,Degree,ApplyDate,JobId)
		VALUES (@NAME,@EMAIL,@ADDRESS,@PHONE,@DOB,@GENDER,@DEGREE,@APPLYDATE,@JOBID)
	END;
GO

CREATE PROC SP_CADIDATE_REGRISTER
(
@CREATEDATE DATETIME = GETDATE,
@DELETED BIT,
@USERNAME NVARCHAR(MAX),
@PASSWORD NVARCHAR(MAX)
)
AS
	BEGIN
		INSERT DBO.Cadidates(CreateDate,Deleted,Username,Password)
		VALUES (@CREATEDATE,@DELETED,@USERNAME,@PASSWORD)
	END;
GO

CREATE PROC SP_CADIDATE_LOGIN
(
@USERNAME NVARCHAR(MAX),
@PASSWORD NVARCHAR(MAX)
)
AS
	BEGIN
		SELECT Cadidates.CadidateId, Cadidates.Username FROM DBO.Cadidates WHERE Cadidates.Username = @USERNAME AND Cadidates.Password = @PASSWORD
	END;
GO

CREATE PROC SP_FILE_CREATE
(
@CREATEDATE DATETIME = GETDATE,
@DELETED BIT,
@FILENAME NVARCHAR(200),
@FILEPATH NVARCHAR(200),
@FILETYPE NVARCHAR(100),
@FILESIZE INT,
@CADIDATEID INT
)
AS
	BEGIN
		INSERT DBO.Files(CreateDate,Deleted,FileName,FilePath,FileType,FileSize,CadidateId)
		VALUES (@CREATEDATE,@DELETED,@FILENAME,@FILEPATH,@FILETYPE,@FILESIZE,@CADIDATEID)
	END;
GO

exec SP_JOBDESCRIPTION_GET_SIMILAR 2