WITH CityVacancies AS (
    SELECT
        a.Name AS City,
        COUNT(*) AS VacancyCount
    FROM Vacancies v
    JOIN Areas a ON v.AreaId = a.AreaId
    GROUP BY a.Name
),
TotalVacancies AS (
    SELECT COUNT(*) AS TotalCount
    FROM Vacancies
)
SELECT
    c.City,
    c.VacancyCount,
    ROUND((c.VacancyCount * 100.0 / t.TotalCount), 2) AS VacancyPercentage
FROM CityVacancies c
CROSS JOIN TotalVacancies t
ORDER BY c.VacancyCount DESC
LIMIT 10;