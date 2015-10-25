USE [SysAnalyze]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[HR_ОТЧЕТЫ_ФАКТИЧЕСКИЙ_РАСХОД_ТОПЛИВА]
		@dateMonth = N'10-01-2012'

SELECT	@return_value as 'Return Value'

GO
