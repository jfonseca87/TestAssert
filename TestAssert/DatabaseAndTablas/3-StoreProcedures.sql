USE [TestAssert]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateFlight]    Script Date: 20/04/2019 12:22:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Fonseca
-- Create date: 20/04/2019
-- Description:	Store procedure to create flights
-- =============================================
CREATE PROCEDURE [dbo].[SP_CreateFlight]
	@SourceCity VARCHAR(100),
	@DestinationCity VARCHAR(100),
	@DepartureDateTime DATETIME,
	@PlaneNumber VARCHAR(10),
	@PilotName VARCHAR(100),
	@IdFlight INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Flight
	(
		SourceCity
		,DestinationCity
		,DepartureDateTime
		,PlaneNumber
		,PilotName
	) 
	VALUES
	(
		@SourceCity
		,@DestinationCity
		,@DepartureDateTime
		,@PlaneNumber
		,@PilotName
	)

	SET @IdFlight = @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[SP_CreateUser]    Script Date: 20/04/2019 12:22:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Fonseca
-- Create date: 20/04/2019
-- Description:	Store prcedure to create users
-- =============================================
CREATE PROCEDURE [dbo].[SP_CreateUser]
	@DocumentType VARCHAR(3),
	@DocumentNumber INT,
	@UserName VARCHAR(100),
	@Email VARCHAR(100),
	@PhoneNumber VARCHAR(15),
	@IdUser INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO UserFlight
	(
		DocumentType
		,DocumentNumber
		,UserName
		,Email
		,PhoneNumber
	) 
	VALUES
	(
		@DocumentType
		,@DocumentNumber
		,@UserName
		,@Email
		,@PhoneNumber
	)

	SET @IdUser = @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[SP_CreateUserFlightRegister]    Script Date: 20/04/2019 12:22:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Fonseca
-- Create date: 20/04/2019
-- Description:	Store procedure to create user-flight records
-- =============================================
CREATE PROCEDURE [dbo].[SP_CreateUserFlightRegister]
	@IdFlight INT,
	@UserDocumentNumber INT,
	@IdUserFlightRegister INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @UserId int = 0

	SELECT @UserId = IdUser
	FROM UserFlight 
	WHERE DocumentNumber = @UserDocumentNumber

	IF(@UserId > 0)
	BEGIN
		INSERT INTO UserFlightRegister
		(
			IdUser
			,IdFlight
		) 
		VALUES
		(
			@UserId
			,@IdFlight
		)

		SET @IdUserFlightRegister = @@IDENTITY
	END
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetFlight]    Script Date: 20/04/2019 12:22:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Fonseca
-- Create date: 20/04/2019
-- Description:	Store procedure to obtain a flight filtered by id
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetFlight]
	@IdFlight INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	IdFlight
			,SourceCity
			,DestinationCity
			,DepartureDateTime
			,PlaneNumber
			,PilotName
	FROM	Flight
	WHERE	IdFlight = @IdFlight
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetUserFlight]    Script Date: 20/04/2019 12:22:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Fonseca
-- Create date: 20/04/2019
-- Description:	Store procedure to obtain a user filtered by document number
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetUserFlight]
	@DocumentNumber INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	IdUser
			,DocumentType
			,DocumentNumber
			,UserName
			,Email
			,PhoneNumber
	FROM	UserFlight
	WHERE	DocumentNumber = @DocumentNumber
END

GO
