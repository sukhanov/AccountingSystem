USE AccountingSystem
GO

SET DATEFIRST 1
GO

WITH WeeklyBalance ( endOfWeekDate, total, id)
AS
(
SELECT 
MAX(DATEADD(day, 7-DATEPART(dw, AccountDeposits.Date), AccountDeposits.Date)) as endOfWeekDate, 
cast(0 as decimal(18,2))  AS total,
MIN(Id) AS Id
FROM AccountDeposits

UNION ALL
SELECT 
DATEADD(day, 7-DATEPART(dw, dep.Date), dep.Date) as endOfWeekDate, 
cast((WeeklyBalance.total + dep.Amount ) as decimal(18,2)) as total,
(WeeklyBalance.Id + 1) as Id
 
FROM WeeklyBalance, AccountDeposits as dep
 WHERE dep.Id = WeeklyBalance.Id 
)

SELECT endOfWeekDate, max(id) as maxId, max(total) 
FROM WeeklyBalance WHERE endOfWeekDate > DATEADD(month, -3, GetDate()) 
AND id in (SELECT max(id) from WeeklyBalance group by endOfWeekDate)
 group by endOfWeekDate order by endOfWeekDate  desc