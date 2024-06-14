WITH ProfessionalRoleMentions AS (
    SELECT 
        pr.Name AS ProfessionalRoleName,
        COUNT(prvl.VacancyId) AS MentionCount
    FROM 
        ProfessionalRoleVacancyLinks prvl
    JOIN 
        ProfessionalRoles pr ON pr.ProfessionalRoleId = prvl.ProfessionalRoleId
    GROUP BY 
        pr.Name
),
TotalVacancies AS (
    SELECT COUNT(DISTINCT VacancyId) AS TotalCount
    FROM ProfessionalRoleVacancyLinks
)
SELECT
    pm.ProfessionalRoleName,
    pm.MentionCount,
    ROUND((pm.MentionCount * 100.0 / tv.TotalCount), 2) AS MentionPercentage
FROM ProfessionalRoleMentions pm
CROSS JOIN TotalVacancies tv
ORDER BY 
    pm.MentionCount DESC
LIMIT 10;
