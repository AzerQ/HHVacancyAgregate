WITH SkillMentions AS (
    SELECT 
        ks.Name AS SkillName,
        COUNT(ksvl.VacancyId) AS MentionCount
    FROM 
        KeySkillVacancyLinks ksvl
    JOIN 
        KeySkills ks ON ks.KeySkillId = ksvl.KeySkillId
    WHERE  ks.Name IN ('1С программирование', 'Python', 'Java', 'C++', 'JavaScript', 'C#', 'PHP', 'Swift', 'Ruby', 'Go', 'Kotlin', 'R', 'Objective-C', 'TypeScript', 'Scala', 'Perl', 'Haskell', 'Lua', 'MATLAB', 'Rust', 'Dart', 'Groovy', 'Elixir', 'Clojure', 'F#', 'VB.NET', 'Assembly', 'Shell', 'SQL', 'HTML', 'CSS')
    GROUP BY 
        ks.Name
),
TotalVacancies AS (
    SELECT COUNT(DISTINCT VacancyId) AS TotalCount
    FROM KeySkillVacancyLinks
)
SELECT
    sm.SkillName,
    sm.MentionCount,
    ROUND((sm.MentionCount * 100.0 / tv.TotalCount), 2) AS MentionPercentage
FROM SkillMentions sm
CROSS JOIN TotalVacancies tv
ORDER BY 
    sm.MentionCount DESC
