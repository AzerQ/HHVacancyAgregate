WITH SalaryGroups AS (
    SELECT
        CASE
            WHEN SalaryFrom IS NULL AND SalaryTo IS NULL THEN 'Unknown'
            WHEN SalaryFrom IS NOT NULL AND SalaryTo IS NOT NULL THEN
                (SalaryFrom + SalaryTo) / 2
            WHEN SalaryFrom IS NOT NULL THEN SalaryFrom
            ELSE SalaryTo
        END AS AvgSalary,
        VacancyId
    FROM Vacancies
),
GroupedSalaries AS (
    SELECT
        CASE
            WHEN AvgSalary < 50000 THEN '0-50k'
            WHEN AvgSalary BETWEEN 50000 AND 100000 THEN '50k-100k'
            WHEN AvgSalary BETWEEN 100000 AND 150000 THEN '100k-150k'
            WHEN AvgSalary BETWEEN 150000 AND 200000 THEN '150k-200k'
            WHEN AvgSalary BETWEEN 200000 AND 250000 THEN '200k-250k'
            WHEN AvgSalary BETWEEN 250000 AND 300000 THEN '250k-300k'
            WHEN AvgSalary BETWEEN 300000 AND 350000 THEN '300k-350k'
            WHEN AvgSalary BETWEEN 350000 AND 400000 THEN '350k-400k'
            WHEN AvgSalary BETWEEN 400000 AND 450000 THEN '400k-450k'
            ELSE '450k+'
        END AS SalaryRange,
        COUNT(VacancyId) AS VacancyCount
    FROM SalaryGroups
    GROUP BY SalaryRange
),
TotalVacancies AS (
    SELECT COUNT(*) AS TotalCount
    FROM Vacancies
)
SELECT
    g.SalaryRange,
    g.VacancyCount,
    ROUND((g.VacancyCount * 100.0 / t.TotalCount), 2) AS VacancyPercentage
FROM GroupedSalaries g
CROSS JOIN TotalVacancies t
ORDER BY g.VacancyCount DESC

